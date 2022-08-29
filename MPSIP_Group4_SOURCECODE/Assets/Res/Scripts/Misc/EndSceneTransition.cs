using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneTransition : MonoBehaviour
{
    private int _completedPuzzles = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            foreach (GameObject ele in GameManager.i.puzzles)
            {
                if (ele.GetComponent<IPuzzle>().Completed)
                {
                    _completedPuzzles++;
                }
            }

            if (_completedPuzzles == GameManager.i.puzzles.Length)
            {
                //if the colliding object has the tag of Player, load the end scenes
                SceneManager.LoadScene("EndScene");
            }
            else
            {
                _completedPuzzles = 0;
            }
        }
    }
}
