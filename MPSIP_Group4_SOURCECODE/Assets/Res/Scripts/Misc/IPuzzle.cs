using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPuzzle
{
    bool Completed{
        get;
        set;
    }

    void OnComplete();
}
