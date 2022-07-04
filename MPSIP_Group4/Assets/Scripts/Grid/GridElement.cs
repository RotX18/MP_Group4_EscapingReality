using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for every grid element
/// </summary>

public class GridElement : MonoBehaviour {
    #region PRIVATE VARS
    private float _posX;
    private float _posY;
    private int _id;
    #endregion

    #region PROPERTIES
    public float GridX {
        get {
            return _posX;
        }
        set {
            _posX = value;
        }
    }

    public float GridY {
        get {
            return _posY;
        }
        set {
            _posY = value;
        }
    }
    public int ID {
        get {
            return _id;
        }
        set {
            _id = value;
        }
    }
    #endregion
}
