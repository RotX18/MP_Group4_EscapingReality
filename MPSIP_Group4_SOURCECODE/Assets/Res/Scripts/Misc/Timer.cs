using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    #region PUBLIC VARS
    public TextMeshProUGUI txtTimer;
    #endregion

    #region PRIVATE VARS
    private float _minutes;
    private float _seconds = 0;
    #endregion

    private void Update() {
        _seconds += Time.deltaTime;

        //updating the counter every minute
        if(_seconds > 59){
            _seconds = 0;
            _minutes += 1;
        }

        //updating the timer text in the scene
        txtTimer.text = $"{LessThanTen(_minutes)}:{LessThanTen(Mathf.Round(_seconds))}";

        //saving the current value into PlayerPrefs
        PlayerPrefs.SetFloat("minutes", _minutes);
        PlayerPrefs.SetFloat("seconds", _seconds);
    }

    private string LessThanTen(float f){ 
        if(f < 10){
            return $"0{f}";
        }
        else{
            return f.ToString();
        }
    }
}
