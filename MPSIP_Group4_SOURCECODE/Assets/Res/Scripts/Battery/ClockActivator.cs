using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockActivator : MonoBehaviour
{
    #region PUBLIC VARS
    public GameObject[] clocks;
    #endregion

    private void Awake() {
        //disabling the clock setting script for all clocks
        foreach(GameObject ele in clocks){
            ele.GetComponent<ClockTimer>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.name.Equals("Battery")){
            //if the battery has hit this collider, set all clocks
            foreach(GameObject ele in clocks) {
                ele.GetComponent<ClockTimer>().enabled = true;
            }

            //destroy the battery
            Destroy(collision.gameObject);
        }
    }
}
