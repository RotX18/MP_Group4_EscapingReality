using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject pointerOrigin;

    private Ray _pointerRay;
    private RaycastHit _hit;
    private GameObject _hitObj;
    private bool _doRaycast = false;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)){
            //if the right index trigger is pressed, set hit obj to null and do raycast
            _hitObj = null;
            _doRaycast = true;
        }
        else {
            _doRaycast = false;
        }

        //hit obj handling
        if (_hitObj != null && _hitObj.GetComponentInChildren<Button>() != null) {
            char[] remove = { 'b', 't', 'n' };
            SceneManager.LoadScene(_hit.collider.name.TrimStart(remove));
        }
    }

    private void FixedUpdate()
    {
        if (_doRaycast)
        {
            //casting from the main camera to the point on screen where the mouse is
            _pointerRay = new Ray(pointerOrigin.transform.position, pointerOrigin.transform.forward);

            if (Physics.Raycast(_pointerRay, out _hit))
            {
                //if the point where the player click contains a gameobject
                _hitObj = _hit.transform.gameObject;
            }
        }
    }
}
