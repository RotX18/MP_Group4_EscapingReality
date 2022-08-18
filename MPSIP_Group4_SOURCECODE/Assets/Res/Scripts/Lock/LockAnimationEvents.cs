using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAnimationEvents : MonoBehaviour
{
    #region PUBLIC VARS
    public Rigidbody lockRb;
    public Animator cabinetAnim;
    #endregion

    #region PRIVATE VARS
    private int _openParam = Animator.StringToHash("Open");
    #endregion

    public void Unlock(){
        lockRb.useGravity = true;
        TriggerCabinetAnimation(_openParam);
    }

    public void TriggerCabinetAnimation(int param) {
        cabinetAnim.SetTrigger(param);
    }
}
