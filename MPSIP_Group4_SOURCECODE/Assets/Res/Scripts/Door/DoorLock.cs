using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.name.Equals("PlayerKey")){
            //if the triggering object has the name of PlayerKey
            other.GetComponent<Key>().Unlock = true;
        }
    }
}
