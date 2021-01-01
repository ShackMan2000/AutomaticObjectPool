using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{

    public PooledObject prefab;

    private List<PooledObject> pooledObjects;


    private void Awake()
    {
        pooledObjects = new List<PooledObject>();
      //  transform.SetParent(GameObject.Find("Pools").transform);
    }


    public PooledObject GetInstance(Transform parent)
    {
        PooledObject obj = null;


        if (pooledObjects.Count > 0)
        {
            obj = pooledObjects[0];
            pooledObjects.RemoveAt(0);

        }
        else
        {
            Transform newParent = parent == null? transform : parent;

            obj = Instantiate(prefab, newParent);
            obj.pool = this;
        }

        obj.Activate();

        return obj;
    }




    public void ReturnObject(PooledObject returnedObject)
    {
        pooledObjects.Add(returnedObject);
        returnedObject.Deactivate();
    }
}
