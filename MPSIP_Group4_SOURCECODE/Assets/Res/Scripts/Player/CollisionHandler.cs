using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.CompareTag("Wall")){
            gameObject.transform.position = collision.contacts[0].normal;
        }
    }
}
