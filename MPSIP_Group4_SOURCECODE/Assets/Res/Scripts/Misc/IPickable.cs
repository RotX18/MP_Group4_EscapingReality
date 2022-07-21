using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPickable
{
    enum Controller {
        LTouch,
        RTouch,
        None
    }

    bool Grabbed{
        get; 
        set;
    }

    Controller CurrentController {
        get;
        set; 
    }

    void OnRelease();
}
