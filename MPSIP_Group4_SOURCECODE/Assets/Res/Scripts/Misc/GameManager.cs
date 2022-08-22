using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i = null;

    #region PUBLIC VARS
    //PUZZLES
    public GameObject mazeObj;
    public GameObject gridObj;
    public GameObject lockObj;

    //UI
    public GameObject canvasUI;
    public GameObject canvasHint;
    #endregion

    #region PRIVATE VARS
    private bool _mazeComplete = false;
    private bool _gridComplete = false;
    private bool _lockComplete = false;
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
        if(mazeObj.GetComponentInChildren<IPuzzle>() != null) {
            if(mazeObj.GetComponentInChildren<IPuzzle>().Completed && !_mazeComplete) {
                _mazeComplete = true;
                mazeObj.GetComponentInChildren<IPuzzle>().OnComplete();
            }
        }
        if(gridObj.GetComponentInChildren<IPuzzle>() != null) {
            if(gridObj.GetComponentInChildren<IPuzzle>().Completed && !_gridComplete) {
                _gridComplete = true;
                gridObj.GetComponentInChildren<IPuzzle>().OnComplete();
            }
        }
        if(lockObj.GetComponentInChildren<IPuzzle>() != null && !_lockComplete) {
            if(lockObj.GetComponentInChildren<IPuzzle>().Completed) {
                _lockComplete = true;
                lockObj.GetComponentInChildren<IPuzzle>().OnComplete();
            }
        }
        
        //hiding/unhiding the ui
        if(OVRInput.GetDown(OVRInput.RawButton.X)){ 
            if(canvasUI.activeInHierarchy){
                //if the canvasUI is active, set it to inactive
                canvasUI.SetActive(false);
            }
            else{
                //else set it to active
                canvasUI.SetActive(true);
            }
        }
        if(OVRInput.GetDown(OVRInput.RawButton.Y)){ 
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
}
