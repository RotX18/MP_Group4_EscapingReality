using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockManager : MonoBehaviour, IPickable, IPuzzle
{
    #region PUBLIC VARS
    public int correctCombination;
    public LockDial[] lockDials;
    #endregion

    #region PRIVATE VARS
    private bool _doCombinationCheck = true;
    private bool _unlocked = false;
    private Vector3 _initialPos;
    private Quaternion _initialRot;
    private int _OpenParam = Animator.StringToHash("Open");

    [SerializeField]
    private Animator _cabinetAnim;
    [SerializeField]
    private TextMeshPro _text;
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
    #endregion
    #endregion

    #region INTERFACE METHODS
    #region IPickable METHODS
    public void OnRelease(){ 
        foreach(LockDial ele in lockDials){
            ele.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
        }
        gameObject.transform.SetPositionAndRotation(_initialPos, _initialRot);
    }
    #endregion

    #region IPuzzle METHODS
    public void OnComplete(){
        //ANY ANIMATIONS OR UNLOCK EVENTS TO BE DONE HERE
        Debug.Log("LOCK HAS BEEN UNLOCKED");
        if (_text != null) {
            _text.text = "Congrats now, get the key and leave";
        }
        
        if (_cabinetAnim != null) {
            TriggerAnimation(_OpenParam);
        }
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
        //for loop to concatenate numbers and check against combi
        for(int i = 0; i < lockDials.Length; i++){
            dialCombination += lockDials[i].CurrentNumber;
        }

        if(dialCombination.Equals(correctCombination.ToString()) && _unlocked == false) {
            //if the combination matches and the lock has not been unlocked
            _unlocked = true;
            Completed = true;
        }

        yield return new WaitForEndOfFrame();
        _doCombinationCheck = true;
    }

    public void TriggerAnimation(int param)
    {
        _cabinetAnim.SetTrigger(param);
    }
}
