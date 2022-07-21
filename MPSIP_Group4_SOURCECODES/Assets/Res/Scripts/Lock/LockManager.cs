using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour, IPickable
{
    #region PUBLIC VARS
    public int correctCombination;
    public LockDial[] lockDials;
    #endregion

    #region PRIVATE VARS
    private bool _doCombinationCheck = true;
    private bool _unlocked = false;
    #endregion

    #region PROPERTIES
    public bool Grabbed {
        get;
        set;
    } = false;

    public IPickable.Controller CurrentController {
        get;
        set;
    } = IPickable.Controller.None;
    #endregion

    #region PUBLIC METHODS
    public void OnRelease(){ 
        foreach(LockDial ele in lockDials){
            ele.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
        }
    }
    #endregion

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
            Unlock();
        }

        yield return new WaitForEndOfFrame();
        _doCombinationCheck = true;
    }

    private void Unlock(){
        //ANY ANIMATIONS OR UNLOCK EVENTS TO BE DONE HERE
        Debug.Log("LOCK HAS BEEN UNLOCKED");
    }
}
