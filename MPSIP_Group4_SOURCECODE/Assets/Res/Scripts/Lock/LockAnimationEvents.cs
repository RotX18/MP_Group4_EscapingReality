using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAnimationEvents : MonoBehaviour
{
    #region PUBLIC VARS
    public Rigidbody lockRb;
    #endregion

    public void Unlock(){
        lockRb.useGravity = true;
    }
}
