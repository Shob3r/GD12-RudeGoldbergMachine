using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectCollisionActions : MonoBehaviour
{
    public bool enableDebugMessages = false;
    protected virtual void OnCollisionEnter(Collision other)
    {
        
    }
}
