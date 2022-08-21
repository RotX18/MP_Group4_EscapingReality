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
