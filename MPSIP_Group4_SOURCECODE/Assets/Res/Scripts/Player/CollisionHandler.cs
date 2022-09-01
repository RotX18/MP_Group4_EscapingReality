using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler: MonoBehaviour {
    private float _initialY;
    private Quaternion _preRotation;

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.transform.CompareTag("Wall")) {
            //if the object has the tag of Wall
            _preRotation = gameObject.transform.rotation;
            _initialY = gameObject.transform.position.y;

            //set the player's position to of the contact point of collision
            gameObject.transform.position = collision.contacts[0].point;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, _initialY, gameObject.transform.position.z);
        }
    }

    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.transform.CompareTag("Wall")) {
            //resetting the player's rotation to the value before collision
            gameObject.transform.rotation = _preRotation;
        }
    }
}