using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;


    [SerializeField]
    private SpriteRenderer bodySprite;



    public StageManager stageMan;




    private void OnEnable()
    {
        direction = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f);
        destroyTime = Random.Range(2f, 5f);


    }




    public void SetUpEnemy(Color newColor)
    {
        bodySprite.color = newColor;
    }



    private Vector3 direction;

    private float destroyTime;




    private void Update()
    {
        transform.position += direction * Time.deltaTime;

        destroyTime -= Time.deltaTime;
        if (destroyTime < 0f)
            Creator.Kill(gameObject);

    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        Creator.Kill(gameObject);
    }





}
