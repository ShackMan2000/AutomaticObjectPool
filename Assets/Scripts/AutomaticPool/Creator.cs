using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Creator : MonoBehaviour
{

    private static Dictionary<PooledObject, Pool> pools = new Dictionary<PooledObject, Pool>();



    public static GameObject Create(GameObject prefab, Transform parent = null)
    {
        GameObject newInstance = null;


        //component of the prefab to check wether it should be pooled
        //could use a list instead
        PooledObject pooledPrefab = prefab.GetComponent<PooledObject>();

     

        //check if it is a pooled object
        if (pooledPrefab != null)
        {
            Pool pool = GetObjectPool(pooledPrefab);
            PooledObject pooledInstance = pool.GetInstance(parent);

            return pooledInstance.gameObject;
        }
        else
        {
            newInstance = Instantiate(prefab, parent);
        }



        return newInstance;
    }



    public static T Create<T>(T prefab, Transform parent = null) where T : Component
    {

        T newInstance = null;


        //component of the prefab to check wether it should be pooled
        PooledObject pooledPrefab = prefab.GetComponent<PooledObject>();



        //check if it is a pooled object
        if (pooledPrefab != null)
        {
            Pool pool = GetObjectPool(pooledPrefab);
            PooledObject pooledInstance = pool.GetInstance(parent);

            return pooledInstance.GetComponent<T>();
        }
        else
        {
            newInstance = Instantiate(prefab, parent);
        }


        return newInstance;
    }










    public static void Kill(GameObject killedObject)
    {
        PooledObject pooledObject = killedObject.GetComponent<PooledObject>();


        //problem is that what if it was an instance in the scene, so it wasn't created through the creator == doesn't have a pool assigned     

        if (pooledObject != null && pooledObject.pool != null)
        {
            pooledObject.pool.ReturnObject(pooledObject);
        }
        else
            Destroy(killedObject);
    }



    private static Pool GetObjectPool(PooledObject pooledPrefab)
    {
        Pool pool = null;

        if (pools.ContainsKey(pooledPrefab))
        {
            pool = pools[pooledPrefab];
        }
        else
        {
            var poolContainer = new GameObject(pooledPrefab.gameObject.name + " Pool");
            pool = poolContainer.AddComponent<Pool>();
            pool.prefab = pooledPrefab;
            pools.Add(pooledPrefab, pool);
        }


        return pool;
    }













}
