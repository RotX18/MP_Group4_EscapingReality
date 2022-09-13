using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager i = null;

    #region PUBLIC VARS
    //PUZZLES
    public GameObject[] puzzles;

    //UI
    public Animator UIanimation;
    public GameObject canvasUI;
    public GameObject canvasHint;
    #endregion

    #region PRIVATE VARS
    private bool _runCheckCompletes = true;
    #endregion

    private void Awake() {
        //singleton pattern
        if(i == null){
            i = this;
        }
        else if(i != this){
            Destroy(gameObject);
        }
    }

    private void Update() {
        //run CheckCompletes coroutine when the previous check completes
        if(_runCheckCompletes) {
            _runCheckCompletes = false;
            StartCoroutine(CheckCompletes());
        }
        
        //hiding/unhiding the ui
        if(OVRInput.GetDown(OVRInput.RawButton.Y)){

            UIanimation.SetTrigger("ButtonTrigger");

        }
        if(OVRInput.GetDown(OVRInput.RawButton.X)){ 
            if(canvasHint.activeInHierarchy){
                //if the canvasHint is active, set it to inactive
                canvasHint.SetActive(false);
            }
            else{
                //else set it to active
                canvasHint.SetActive(true);
            }
        }

    }

    private IEnumerator CheckCompletes(){ 
        foreach(GameObject ele in puzzles){ 
            //iterating through IPuzzles in puzzles
            if(ele.GetComponent<IPuzzle>().Completed && ele.GetComponent<IPuzzle>().RunOnComplete){
                //if the puzzle is completed and its corresponding RunOnComplete is true
                ele.GetComponent<IPuzzle>().RunOnComplete = false;
                ele.GetComponent<IPuzzle>().OnComplete();
            }
        }
        yield return new WaitForEndOfFrame();
        _runCheckCompletes = true;
    }

    public void GameOver(){
        Debug.Log("GAMEOVER");
    }
}
