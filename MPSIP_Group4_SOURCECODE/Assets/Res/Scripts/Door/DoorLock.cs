using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.name.Equals("Key")){
            other.GetComponent<Key>().Unlock = true;
        }
    }
}
