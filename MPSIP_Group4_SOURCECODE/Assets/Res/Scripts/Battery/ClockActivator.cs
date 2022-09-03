using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockActivator : MonoBehaviour
{
    #region PUBLIC VARS
    public GameObject[] clocks;
    public GameObject batteryHolder;
    public TextMeshProUGUI _text;
    public GameObject arrowPointer;
    public GameObject _textObj;
    #endregion

    #region PRIVATE VARS
    private Vector3 _objPos;
    private Quaternion _objRot;
    #endregion

    private void Awake() {
        //disabling the clock setting script for all clocks
        foreach(GameObject ele in clocks){
            ele.GetComponent<ClockTimer>().enabled = false;
        }

        _objPos = gameObject.transform.position;
        _objRot = gameObject.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.name.Equals("Battery")){
            //if the battery has hit this collider, set all clocks
            foreach(GameObject ele in clocks) {
                ele.GetComponent<ClockTimer>().enabled = true;
            }

            //destroy the battery
            Destroy(collision.gameObject);

            //"inserting" the battery into the socket
            Instantiate(batteryHolder, _objPos, _objRot);

            if (!_textObj.activeSelf) {
                _textObj.SetActive(true);
            }
            //setting the player instruction text
            _text.text = "Plot a course by the hours, Count the steps every minute.";

            //destroying this gameobject
            Destroy(gameObject);

            //setting the arrow active
            arrowPointer.SetActive(true);
        }
    }
}
