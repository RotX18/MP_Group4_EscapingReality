using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneTransition : MonoBehaviour
{
    public Animator transition;
    public GameObject pointVisualiser;
    private int _completedPuzzles = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")){
            //if the colliding object has the tag of Player
            foreach(GameObject ele in GameManager.i.puzzles){
                //for every element in the puzzles array
                if (ele.GetComponent<IPuzzle>().Completed){
                    //if the current puzzle is completed
                    _completedPuzzles++;
                }
            }

            if (_completedPuzzles == GameManager.i.puzzles.Length){
                //if the number of completed puzzles = the total number of puzzles, load the end scene
                StartCoroutine(LoadEndScene());
            }
            else{
                //else, reset the completed count
                _completedPuzzles = 0;
            }
        }
    }

    private IEnumerator LoadEndScene() {
        transition.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        pointVisualiser.SetActive(true);
        SceneManager.LoadScene("EndScene");
    }
}
