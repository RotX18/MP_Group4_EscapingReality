using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IPickable
{
    #region PUBLIC VARS
    public Animator anim;
    #endregion

    #region PRIVATE VARS
    private bool _unlock = false;
    private int _doorUnlock = Animator.StringToHash("DoorUnlock");
    #endregion

    #region PROPERTIES
    #region IPickable PROPERTIES
    public IPickable.Controller CurrentController {
        get;
        set;
    }

    public bool Grabbed {
        get;
        set;
    } = false;
    #endregion

    public bool Unlock {
        get {
            return _unlock;
        }
        set {
            _unlock = value;
        }
    }
    #endregion

    #region INTERFACE METHODS
    public void OnRelease(){ 
        if(_unlock){
            //if the door has changed _unlock to true
            Destroy(gameObject);
        }
    }
    #endregion


    private void OnDestroy() {
        //playing the animation as the key gets de
        anim.SetTrigger(_doorUnlock);
    }
}
