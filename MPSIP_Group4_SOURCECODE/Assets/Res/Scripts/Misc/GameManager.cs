using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i = null;

    #region PUBLIC VARS
    public GameObject mazeObj;
    public GameObject gridObj;
    public GameObject lockObj;
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
        
    }
}
