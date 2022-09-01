using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour, IPickable
{
    #region PUBLIC VARS
    public GameObject rCon;
    public GameObject lCon;
    public GameObject spawnerLocation;
    public float throwForce = 1;
    #endregion

    #region PRIVATE VARS
    private Rigidbody _rb;
    private Vector3 _lConLastPos;
    private Vector3 _rConLastPos;
    private float _lConSpeed;
    private float _rConSpeed;
    private bool _pickedUp = false;
    #endregion

    #region PROPERTIES
    public bool Grabbed {
        get;
        set;
    } = false;

    public IPickable.Controller CurrentController {
        get;
        set;
    }
    #endregion

    #region INTERFACE METHODS
    public void OnRelease(){
        _rb.isKinematic = false;
        Throw();
    }
    #endregion

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    private void Start() {
        _lConLastPos = lCon.transform.position;
        _rConLastPos = rCon.transform.position;
    }

    private void Update() {
        if(Grabbed){
            //if battery is being held
            _rb.isKinematic = true;
            _pickedUp = true;
        }

        //calculating speed for each controller
        //LEFT CONTROLLER
        _lConSpeed = Vector3.Distance(_lConLastPos, lCon.transform.position) / Time.deltaTime;
        _lConLastPos = lCon.transform.position;
        
        //RIGHT CONTROLLER
        _rConSpeed = Vector3.Distance(_rConLastPos, rCon.transform.position) / Time.deltaTime;
        _rConLastPos = rCon.transform.position;
    }

    private void Throw(){
        _rb.isKinematic = false;
        if(CurrentController == IPickable.Controller.LTouch){
            //if the left controller is holding
            _rb.AddForce(lCon.transform.right * _lConSpeed * throwForce, ForceMode.VelocityChange);
        }
        if(CurrentController == IPickable.Controller.RTouch){
            //if the left controller is holding
            _rb.AddForce(-rCon.transform.right * _rConSpeed * throwForce, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(!collision.collider.CompareTag("ActivateClock") && _pickedUp){
            //if the collided object is not tagged "ActivateClock" and has already been pickup
            _rb.isKinematic = true;
            if(spawnerLocation != null){
                transform.SetPositionAndRotation(spawnerLocation.transform.position, spawnerLocation.transform.rotation);
            }
            _pickedUp = false;
        }
    }
}
