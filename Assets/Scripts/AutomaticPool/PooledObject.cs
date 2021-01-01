using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    
    public Pool pool;

    public event Action Activated = delegate { };
    public event Action Deactivated = delegate { };






    public void Activate()
    {
        gameObject.SetActive(true);
        Activated();     
    }


    public void Deactivate()
    {
        gameObject.SetActive(false);
        Deactivated();
    }

}
