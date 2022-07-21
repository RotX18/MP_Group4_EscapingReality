using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDial : MonoBehaviour
{
    #region PRIVATE VARS
    private int _currentNumber = 0;
    #endregion

    #region PROPERTIES
    public int CurrentNumber{ 
        get{
            return _currentNumber;
        }
        set{
            SetNumber(value);
        }
    }
    #endregion

    private void Update() {
        //if the current number is more than 9, set it to 0
        if(_currentNumber > 9){
            _currentNumber = 0;
        }

        //if the current number is < 0, set it to 9
        if(_currentNumber < 0){
            _currentNumber = 9;
        }
    }

    private void SetNumber(int input){
        //Using flipped values (relative to input) for better UX
        _currentNumber -= input;

        //set the rotation to input*36 as 360/10 = 36, input determines the direction
        Vector3 rotation = new Vector3(0, 0, -input * 36);
        gameObject.transform.Rotate(rotation);
    }
}
