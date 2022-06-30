using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for every grid element
/// </summary>

public class Cube : MonoBehaviour
{
    #region PRIVATE VARS
    public int _id;
    public float _posX;
    public float _posY;

    #endregion

    #region PROPERTIES
    public int ID { 
        get{
            return _id;
        }
        set{
            _id = value;
        }
    }

    public float GridX{
        get{
            return _posX;
        }
        set{
            _posX = value;
        }
    }

    public float GridY { 
        get{
            return _posY;
        }
        set{
            _posY = value;
        }
    }

    #endregion
}
