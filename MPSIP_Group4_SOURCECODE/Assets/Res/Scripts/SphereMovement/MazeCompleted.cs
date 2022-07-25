using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeCompleted : MonoBehaviour
{
    public GameObject ballObj;
    public TextMesh text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ballObj)
        {
            Debug.Log("puzzle completed");
            text.text = "Plot a course by the hours,\n Count the steps every minute.";
        }
    }
}
