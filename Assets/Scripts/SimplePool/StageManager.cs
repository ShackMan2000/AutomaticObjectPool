using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{


    [SerializeField]
    private Enemy enemyPrefab;


    [SerializeField]
    private List<Enemy> inactiveEnemies;


    [SerializeField]
    private Vector2 spawnPoint;


    [SerializeField]
    private List<Color> colors;

    [SerializeField]
    private float minSpawnTime, maxSpawnTime;

    [SerializeField]
    private float spawnCounter;



    private void Awake()
    {
        spawnCounter = Random.Range(minSpawnTime, maxSpawnTime);
        Enemy newEnemy = Creator.Create(enemyPrefab.gameObject).GetComponent<Enemy>();
    }



    private void Update()
    {
        spawnCounter -= Time.deltaTime;

        if (spawnCounter <= 0f)
        {
            spawnCounter = Random.Range(minSpawnTime, maxSpawnTime);

            Enemy newEnemy = CreateEnemy();

            newEnemy.transform.position = spawnPoint;

            Color newColor = colors[Random.Range(0, colors.Count)];
            newEnemy.SetUpEnemy(newColor);
        }
    }








    public Enemy CreateEnemy()
    {
        Enemy newEnemy;

        //check if there is an enemy in the pool
        //if yes, activate it and return that
        //if no, create a new one

        if (inactiveEnemies.Count > 0)
        {
            newEnemy = inactiveEnemies[0];
            inactiveEnemies.Remove(newEnemy);
            newEnemy.gameObject.SetActive(true);
            //  inactiveEnemies.RemoveAt(0);


            return newEnemy;
        }
        else
        {
            newEnemy = Instantiate(enemyPrefab, transform);
            newEnemy.stageMan = this;
            return newEnemy;
        }

    }



    public void KillEnemy(Enemy killedEnemy)
    {
        killedEnemy.gameObject.SetActive(false);
        inactiveEnemies.Add(killedEnemy);
    }





}
