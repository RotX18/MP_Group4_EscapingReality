using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneTransition : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Player")){
            //if the colliding object has the tag of Player, load the end scenes
            SceneManager.LoadScene("EndScene");
        }
    }
}
