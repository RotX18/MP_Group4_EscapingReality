using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MazeCompleted : MonoBehaviour, IPuzzle
{
    public GameObject maze;

    #region PRIVATE VARS
    [SerializeField]
    private GameObject _ballObj;

    //BATTERY VARS
    [SerializeField]
    private GameObject _battery;
    [SerializeField]
    private GameObject _battSpawner;
    [SerializeField]
    private TextMeshProUGUI _text;
    #endregion

    #region PROPERTIES
    public bool Completed
    {
        get;
        set;
    }

    public bool RunOnComplete {
        get;
        set;
    } = true;
    #endregion

    #region IPuzzle METHODS
    public void OnComplete()
    {
        //spawn the battery
        _battery.transform.SetPositionAndRotation(_battSpawner.transform.position, _battSpawner.transform.rotation);

        //when the maze is completed, set the maze to inactive
        maze.SetActive(false);

        _text.text = "Charge the clocks";
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
