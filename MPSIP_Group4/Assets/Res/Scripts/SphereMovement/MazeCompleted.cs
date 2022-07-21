using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCompleted : MonoBehaviour
{
    public GameObject ballObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ballObj)
        {
            Debug.Log("puzzle completed");
        }
    }
}
