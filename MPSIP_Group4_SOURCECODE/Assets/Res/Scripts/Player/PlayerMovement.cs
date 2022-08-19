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

            //setting the direction of movement
            Vector3 normalisedCenterEye = centerEyeAnchor.transform.forward.normalized;
            Vector3 move = new Vector3(normalisedCenterEye.x * Normalise(_stickInput.x) * speed, 0, normalisedCenterEye.z * Normalise(_stickInput.y) * speed);
            _rb.AddForce(move, ForceMode.VelocityChange);
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, maxSpeed);
        }
        else{
            _isMoving = false;
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
        }
    }

    private int Normalise(float f){ 
        if(f < 0){
            //if f is less than 0 return -1
            return -1;
        }
        else if(f > 0){
            //if f is more than 0, return 1
            return 1;
        }
        else{
            //if f is not less than nor more than 0, f == 0
            return 0;
        }
    }
}
