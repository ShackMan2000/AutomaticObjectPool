using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{


   private Vector3 direction;

    private float destroyTime;


    private void OnEnable()
    {
        direction = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f);
        destroyTime = Random.Range(2f, 5f);
    }






    private void Update()
    {
        transform.position += direction * Time.deltaTime;

        destroyTime -= Time.deltaTime;
        if (destroyTime < 0f)
            Creator.Kill(gameObject);
    
    }

}
