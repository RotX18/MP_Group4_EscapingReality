using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for every grid element
/// </summary>

public class GridElement : MonoBehaviour 
{
    #region PRIVATE VARS
    private int _posX;
    private int _posY;
    private int _id;
    private bool _correctElement;
    private bool _clickable = false;
    private bool _clicked = false;
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
            _correctElement = value;
        }
    }

    public bool Clickable{ 
        get{
            return _clickable;
        }
        set{
            _clickable = value;
        }
    }

    public bool Clicked{ 
        get{
            return _clicked;
        }
        set{
            _clicked = value;
        }
    }
    #endregion
}
