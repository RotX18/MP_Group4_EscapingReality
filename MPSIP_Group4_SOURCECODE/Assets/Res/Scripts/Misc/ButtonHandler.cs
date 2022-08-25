using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject pointerOrigin;

    private Ray _pointerRay;
    private RaycastHit _hit;
    private GameObject _hitObj;

    private bool _rIndexTrigger;

    private void Update()
    {
        _rIndexTrigger = OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger);

        if (_rIndexTrigger)
        {
            if (_hitObj == null) return;
            //check if it collides with the gameobject name StartButton
            if (_hitObj.GetComponent<Collider>().name.Equals("StartButton"))
            {
                //loadScene
                SceneManager.LoadScene(1);
                Debug.Log("loadscene");
            }
            else if (_hitObj.GetComponent<Collider>().name.Equals("ReturnButton"))
            {
                //loadScene
                SceneManager.LoadScene(0);
            }
            else return;
        }

    }

    private void FixedUpdate()
    {
        //casting from the main camera to the point on screen where the mouse is
        _pointerRay = new Ray(pointerOrigin.transform.position, pointerOrigin.transform.forward);

        if (Physics.Raycast(_pointerRay, out _hit))
        {
            //if the point where the player click contains a gameobject
            _hitObj = _hit.transform.gameObject;
        }
        else
        {
            _hitObj = null;
        }
    }
}
