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

    //BATTERY VARS
    [SerializeField]
    private GameObject _battery;
    [SerializeField]
    private GameObject _battSpawner;
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

        //spawn the battery
        _battery.transform.SetPositionAndRotation(_battSpawner.transform.position, _battSpawner.transform.rotation);
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _ballObj)
        {
            Completed = true;
        }
    }
}
