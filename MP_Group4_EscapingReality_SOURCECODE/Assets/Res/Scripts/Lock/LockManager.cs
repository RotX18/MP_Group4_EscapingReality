using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockManager : MonoBehaviour, IPickable, IPuzzle
{
    #region PUBLIC VARS
    public GameObject key;
    public LockDial[] lockDials;
    public Animator lockAnim;
    public int correctCombination;
    public TextMeshProUGUI text;
    #endregion

    #region PRIVATE VARS
    private bool _doCombinationCheck = true;
    private bool _unlocked = false;
    private Vector3 _initialPos;
    private Quaternion _initialRot;
    private int _unlockAnim = Animator.StringToHash("Unlock");
    #endregion

    #region PROPERTIES
    #region IPickable PROPERTIES
    public IPickable.Controller CurrentController {
        get;
        set;
    } = IPickable.Controller.None;

    public bool Grabbed {
        get;
        set;
    } = false;
    #endregion

    #region IPuzzle PROPERTIES
    public bool Completed {
        get;
        set;
    } = false;
    public bool RunOnComplete {
        get;
        set;
    } = true;
    #endregion
    #endregion

    #region INTERFACE METHODS
    #region IPickable METHODS
    public void OnRelease(){
        foreach(LockDial ele in lockDials){
            ele.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
        }
        if(!Completed){
            gameObject.transform.SetPositionAndRotation(_initialPos, _initialRot);
        }
    }
    #endregion

    #region IPuzzle METHODS
    public void OnComplete(){
        TriggerLockAnimation(_unlockAnim);
        key.SetActive(true);
        text.text = "Escape the room";
    }
    #endregion
    #endregion

    private void Awake() {
        _initialPos = gameObject.transform.position;
        _initialRot = gameObject.transform.rotation;
    }

    private void Update() {
        
        if(_doCombinationCheck && !_unlocked){
            _doCombinationCheck = false;
            //checking for the correct correctCombination via coroutine
            StartCoroutine(CheckCombination());
        }
    }

    private IEnumerator CheckCombination(){
        string dialCombination = "";
        string correctCom = correctCombination.ToString();
        string addedZeros = "";

        //for loop to concatenate numbers of the current lock dials
        for(int i = 0; i < lockDials.Length; i++){
            dialCombination += lockDials[i].CurrentNumber;
        }
        
        //accounting for correctCombinations starting with 0
        if(correctCom.Length < lockDials.Length){
            //if the correct combination has fewer digits than the number of lockDials
            for(int i = 0; i < (lockDials.Length - correctCom.Length); i++){
                addedZeros += "0";
            }
            //adding 0s to the front
            correctCom = $"{addedZeros}{correctCom}";
            
        }
        //accounting for correctCombinations > number of lockDials
        if(correctCom.Length > lockDials.Length){
            //if the correct combination has more digits than the number of lock dials
            correctCom = "";
            for(int i = 0; i < lockDials.Length; i++){
                //resetting correctCom to use only until the lockDials.Length-th digit
                correctCom += correctCombination.ToString()[i];
            }
        }

        //checking for a match between current combination and correct combination
        if(dialCombination.Equals(correctCom) && _unlocked == false) {
            //if the combination matches and the lock has not been unlocked
            _unlocked = true;
            Completed = true;
        }
        yield return new WaitForEndOfFrame();
        _doCombinationCheck = true;
    }

    public void TriggerLockAnimation(int id){
        lockAnim.SetTrigger(id);
    }
}
