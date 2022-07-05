using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script gets the game object under the mouse position and changes it to different colours
/// </summary>

public class MouseInput : MonoBehaviour
{
    #region PUBLIC VARS

    public Camera cam;
    public delegate void MouseAction();
    public MouseAction clickAction;

    #endregion

    #region PRIVATE VARS

    private Ray camToScreen;
    private RaycastHit hit;
    private GameObject hitObj;

    #endregion

    private void Update() {
        if(Input.GetKey(KeyCode.Mouse0)){
            //when the left mouse is pressed, run the MouseClick method
            if(hitObj != null){
                //making the object turn red
                Click(clickAction);
            }
        }
    }

    private void FixedUpdate() {
        //casting from the main camera to the point on screen where the mouse is
        camToScreen = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(camToScreen, out hit)){
            //if the point where the player click contains a gameobject
            hitObj = hit.transform.gameObject;
        }
    }

    private void Click(MouseAction action){
        action();
    }
}
