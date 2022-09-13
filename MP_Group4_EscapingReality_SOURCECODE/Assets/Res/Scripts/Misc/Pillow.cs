using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour, IPickable
{
    #region PUBLIC VARS
    public GameObject lCon;
    public GameObject rCon;
    public float throwForce = 1;
    #endregion

    #region PRIVATE VARS
    private Rigidbody _rb;
    private Vector3 _lConLastPos;
    private Vector3 _rConLastPos;
    private float _lConSpeed;
    private float _rConSpeed;
    #endregion

    #region PROPERTIES
    public bool Grabbed {
        get;
        set;
    } = false;

    public IPickable.Controller CurrentController {
        get;
        set;
    } = IPickable.Controller.None;
    #endregion

    public void OnRelease() {
        Throw();
    }

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = false;
    }

    private void Start() {
        _lConLastPos = lCon.transform.position;
        _rConLastPos = rCon.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Grabbed) {
            //if battery is being held
            _rb.isKinematic = true;
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
        if(CurrentController == IPickable.Controller.LTouch) {
            //if the left controller is holding
            _rb.AddForce(lCon.transform.right * _lConSpeed * throwForce, ForceMode.VelocityChange);
        }
        if(CurrentController == IPickable.Controller.RTouch) {
            //if the left controller is holding
            _rb.AddForce(-rCon.transform.right * _rConSpeed * throwForce, ForceMode.VelocityChange);
        }
    }
}
