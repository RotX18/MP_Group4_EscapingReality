using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script gets the game object under the mouse position and changes it to different colours
/// </summary>

public class MouseInput : MonoBehaviour
{
    #region PUBLIC VARS

    //seletion vars
    public Camera cam;

    //grid vars
    public GameObject gridSpawner;

    #endregion

    #region PRIVATE VARS

    //selection vars
    private Ray _camToScreen;
    private RaycastHit _hit;
    private GameObject _hitObj;

    //grid vars
    private  List<GridElement> _elements = new();
    private Dictionary<int, GridElement> _correctEles = new();
    private Dictionary<int, GridElement> _wrongEles = new();

    #endregion

    private void Start() {
        _elements = gridSpawner.GetComponent<GridSpawner>().AllElements;

        //sorting the elements in the grid to correct elements and wrong elements
        foreach(GridElement ele in _elements) {
            if(ele.Correct) {
                _correctEles.Add(ele.ID, ele);
            }
            else {
                _wrongEles.Add(ele.ID, ele);
            }
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            //when the left mouse is pressed
            if(_hitObj != null){
                if(_hitObj.GetComponent<GridElement>().Correct){
                    //if element is correct, set the colour to green
                    _hitObj.GetComponent<Renderer>().material.color = Color.green;
                }
                else{
                    //if element is not correct, reset all current colours
                    ResetColours();             
                }
            }
        }
    }

    private void FixedUpdate() {
        //casting from the main camera to the point on screen where the mouse is
        _camToScreen = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_camToScreen, out _hit)){
            //if the point where the player click contains a gameobject
            _hitObj = _hit.transform.gameObject;
        }
        else{
            _hitObj = null;
        }
    }

    private void ResetColours(){ 
        foreach(GridElement ele in _elements){
            ele.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
