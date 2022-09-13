using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private void Awake() {
        //dont destroy the audio source when transitioning scene to scene
        DontDestroyOnLoad(gameObject);
    }
}
