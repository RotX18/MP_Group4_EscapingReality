using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehaviour : MonoBehaviour
{
    #region PUBLIC VARS
    public GameObject leftCon;
    public GameObject leftAnchor;
    public GameObject rightCon;
    public GameObject rightAnchor;
    public float grabDistance = 0.02f;
    #endregion

    #region PRIVATE VARS
    //left hand
    private GameObject _leftHandObj;
    private Ray _leftHandRay;
    private RaycastHit _leftHandHit;
    private bool _doLeftRaycast;

    //right hand
    private GameObject _rightHandObj;
    private Ray _rightHandRay;
    private RaycastHit _rightHandHit;
    private bool _doRightRaycast;
    #endregion

    private void Update() {
        //LEFT HAND
        if(OVRInput.Get(OVRInput.RawButton.LHandTrigger)) {
            //if the left hand trigger is pressed more than half, raycast in the +X axis of the controller
            _doLeftRaycast = true;
            if(_leftHandObj != null) {
                //if there is an object below the left hand, set the obj's position to just below the hand
                _leftHandObj.transform.SetParent(leftAnchor.transform);

                //setting the vars if the object implements IPickable
                if(_leftHandObj.GetComponent<IPickable>() != null){
                    _leftHandObj.GetComponent<IPickable>().Grabbed = true;
                    _leftHandObj.GetComponent<IPickable>().CurrentController = IPickable.Controller.LTouch;
                }
            }
        }
        else {
            //When the left hand trigger is let go, reset the vars
            _doLeftRaycast = false;
            try {
                _leftHandObj.transform.parent = null;
                if(_leftHandObj.GetComponent<IPickable>() != null) {
                    _leftHandObj.GetComponent<IPickable>().Grabbed = false;
                    _leftHandObj.GetComponent<IPickable>().OnRelease();
                    _leftHandObj.GetComponent<IPickable>().CurrentController = IPickable.Controller.None;
                }
                _leftHandObj = null;
            }
            catch(System.NullReferenceException) {

            }
        }

        //RIGHT HAND
        if(OVRInput.Get(OVRInput.RawButton.RHandTrigger)){
            //if the right hand trigger is pressed more than half, raycast in the -X axis of the controller
            _doRightRaycast = true;
            if(_rightHandObj != null){
                //if there is an object below the right hand, set the obj's position to just below the hand
                _rightHandObj.transform.SetParent(rightAnchor.transform);

                //setting the vars for the object if it implements IPickable
                if(_rightHandObj.GetComponent<IPickable>() != null) {
                    _rightHandObj.GetComponent<IPickable>().Grabbed = true;
                    _rightHandObj.GetComponent<IPickable>().CurrentController = IPickable.Controller.RTouch;
                }
            }
        }
        else{
            //When the right hand trigger is let go, reset the vars
            _doRightRaycast = false;
            try {
                _rightHandObj.transform.parent = null;
                //resetting the vars for the righthand obj if it implements IPickable
                if(_rightHandObj.GetComponentInChildren<IPickable>() != null) {
                    _rightHandObj.GetComponent<IPickable>().Grabbed = false;
                    _rightHandObj.GetComponent<IPickable>().OnRelease();
                    _rightHandObj.GetComponent<IPickable>().CurrentController = IPickable.Controller.None;
                }
                _rightHandObj = null;
            }
            catch(System.NullReferenceException) {

            }
        }
    }

    private void FixedUpdate() {
        //for LEFT hand
        if(_doLeftRaycast){
            _leftHandRay = new Ray(leftCon.transform.position, leftCon.transform.right);

            if(Physics.Raycast(_leftHandRay, out _leftHandHit, grabDistance)){
                //if the ray hits something
                if(_leftHandHit.collider.CompareTag("PickUp")){
                    //if the object has the tag of PickUp
                    _leftHandObj = _leftHandHit.transform.gameObject;
                }
            }
        }
        
        //for RIGHT hand
        if(_doRightRaycast){
            _rightHandRay = new Ray(rightCon.transform.position, -rightCon.transform.right);

            if(Physics.Raycast(_rightHandRay, out _rightHandHit, grabDistance)){
                //if the ray hits something
                if(_rightHandHit.collider.CompareTag("PickUp")){
                    //if the object has the tag of PickUp
                    _rightHandObj = _rightHandHit.transform.gameObject;
                }
            }
        }
    }
}
