using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script gets the game object under the mouse position and changes it to different colours
/// </summary>

public class GridInput : MonoBehaviour {
    #region PUBLIC VARS
    //seletion vars
    public GameObject pointerOrigin;

    //grid vars
    public GameObject gridSpawnerObj;
    public GridManager gridManager;
    #endregion

    #region PRIVATE VARS
    //selection vars
    private Ray _pointerRay;
    private RaycastHit _hit;
    private GameObject _hitObj;

    //grid vars
    private List<GridElement> _elements = new();
    private Dictionary<int, GridElement> _correctEles = new();
    private Dictionary<int, GridElement> _wrongEles = new();
    #endregion

    private void Start() {
        _elements = gridSpawnerObj.GetComponent<GridSpawner>().AllElements;

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
        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) {
            //when the right trigger is pressed
            if(_hitObj != null) {
                //if the raycast hit is not null
                if(_hitObj.GetComponent<GridElement>() != null){
                    //if the hit object has a GridElement component
                    if(_hitObj.GetComponent<GridElement>().Clickable) {
                        //if the element is clickable
                        _hitObj.GetComponent<GridElement>().Clicked = true;

                        //checking whether the element is correct
                        if(_hitObj.GetComponent<GridElement>().Correct) {
                            //if element is correct, set the colour to green
                            _hitObj.GetComponent<Renderer>().material.color = Color.green;
                            gridManager.ClickedCorrects++;
                        }
                        else {
                            //if element is not correct, reset all current colours
                            gridManager.ResetGrid();
                        }
                    }
                }
            }
        }
    }

    private void FixedUpdate() {
        //casting from the main camera to the point on screen where the mouse is
        _pointerRay = new Ray(pointerOrigin.transform.position, pointerOrigin.transform.forward);

        if(Physics.Raycast(_pointerRay, out _hit)) {
            //if the point where the player click contains a gameobject
            _hitObj = _hit.transform.gameObject;
        }
        else {
            _hitObj = null;
        }
    }
}
