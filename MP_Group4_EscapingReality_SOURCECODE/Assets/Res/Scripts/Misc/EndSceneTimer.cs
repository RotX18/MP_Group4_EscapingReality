using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneTimer : MonoBehaviour
{
    public TextMeshProUGUI txtTimer;

    private void Start() {
        txtTimer.text = $"Completed in {LessThanTen(PlayerPrefs.GetFloat("minutes"))}min {LessThanTen(Mathf.Round(PlayerPrefs.GetFloat("seconds")))}s";
        PlayerPrefs.DeleteAll();
    }

    private string LessThanTen(float f) {
        if(f < 10) {
            return $"0{f}";
        }
        else {
            return f.ToString();
        }
    }
}
