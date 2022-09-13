using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region PUBLIC VARS
    public GameObject centerEyeAnchor;
    public float speed = 1;
    public float maxSpeed = 1;
    #endregion

    #region PRIVATE VARS
    private Rigidbody _rb;
    private Vector2 _stickInput;
    private static bool _isMoving = false;
    #endregion

    #region PROPERTIES
    public static bool IsMoving{ 
        get{
            return _isMoving;
        }
    }
    #endregion

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //allow the player to move only if the left trigger is held down
        if(OVRInput.Get(OVRInput.RawButton.LIndexTrigger)){
            //if the left index trigger is held down > 50%
            _isMoving = true;

            //getting the left thumb stick input
            _stickInput = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);

            if(_stickInput != Vector2.zero){
                //if there is input with the left thumbstick, move the rigidbody
                _rb.isKinematic = false;
                _rb.AddForce(centerEyeAnchor.transform.right * _stickInput.normalized.x * speed, ForceMode.VelocityChange);
                _rb.AddForce(centerEyeAnchor.transform.forward * _stickInput.normalized.y * speed, ForceMode.VelocityChange);
                _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, maxSpeed);
            }
            else{
                //if there is no input with the thumbstick
                _rb.velocity = Vector3.zero;
                _rb.angularVelocity = Vector3.zero;
                _rb.isKinematic = true;
            }
        }
        else{
            //if the left trigger is released
            _isMoving = false;
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            _rb.isKinematic = true;
        }
    }

}
