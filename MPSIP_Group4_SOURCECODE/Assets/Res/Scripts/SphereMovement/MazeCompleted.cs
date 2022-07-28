using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MazeCompleted : MonoBehaviour, IPuzzle
{
    #region PRIVATE VARS
    [SerializeField]
    private GameObject _ballObj;
    [SerializeField]
    private TextMeshPro _text;
    #endregion

    #region PROPERTIES
    public bool Completed
    {
        get;
        set;
    }
    #endregion

    #region IPuzzle METHODS
    public void OnComplete()
    {
        //ANY ANIMATIONS OR UNLOCK EVENTS TO BE DONE HERE
        Debug.Log("MAZE COMPLETE");
        _text.text = "Plot a course by the hours,\n Count the steps every minute.";

    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _ballObj)
        {
            OnComplete();
            Completed = true;
        }
    }
}
