using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneTransition : MonoBehaviour
{
    private int _completedPuzzles = 0;

<<<<<<< Updated upstream
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            foreach (GameObject ele in GameManager.i.puzzles)
            {
                if (ele.GetComponent<IPuzzle>().Completed)
                {
=======
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Player")){
            foreach(GameObject ele in GameManager.i.puzzles){ 
                if(ele.GetComponent<IPuzzle>().Completed){
>>>>>>> Stashed changes
                    _completedPuzzles++;
                }
            }

<<<<<<< Updated upstream
            if (_completedPuzzles == GameManager.i.puzzles.Length)
            {
                //if the colliding object has the tag of Player, load the end scenes
                SceneManager.LoadScene("EndScene");
            }
            else
            {
=======
            if(_completedPuzzles == GameManager.i.puzzles.Length){
                //if the colliding object has the tag of Player, load the end scenes
                SceneManager.LoadScene("EndScene");
            }
            else{
>>>>>>> Stashed changes
                _completedPuzzles = 0;
            }
        }
    }
}
