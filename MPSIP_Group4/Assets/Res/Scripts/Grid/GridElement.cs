using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for every grid element
/// </summary>

public class GridElement : MonoBehaviour 
{
    #region PRIVATE VARS

    private bool _correctElement;
    private int _posX;
    private int _posY;
    private int _id;

    #endregion

    #region PROPERTIES

    public int GridX {
        get {
            return _posX;
        }
        set {
            _posX = value;
        }
    }

    public int GridY {
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

    public bool Correct{ 
        get{
            return _correctElement;
        }
        set{
            _correctElement = true;
        }
    }

    #endregion
}
