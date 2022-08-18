using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IPickable
{
    #region PUBLIC VARS
    public Animator anim;
    public GameObject door;
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
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        Debug.Log("PLAYING DOOR ANIM");
        anim.SetTrigger(_doorUnlock);
    }
    #endregion
}
