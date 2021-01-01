using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerAutomaticObjectPool : MonoBehaviour
{


    [SerializeField]
    private Enemy enemyPrefab;

    [SerializeField]
    private GameObject heroPrefab;

    [SerializeField]
    private List<Enemy> inactiveEnemies;


    [SerializeField]
    private List<Color> colors;

    [SerializeField]
    private float minSpawnTime, maxSpawnTime;

    [SerializeField]
    private float spawnCounter;

    [SerializeField]
    private float spawnRange;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        spawnCounter = Random.Range(minSpawnTime, maxSpawnTime);
      //  Enemy newEnemy = Creator.Create(enemyPrefab.gameObject).GetComponent<Enemy>();
    }



    private void Update()
    {
        spawnCounter -= Time.deltaTime;

        if (spawnCounter <= 0f)
        {
            spawnCounter = Random.Range(minSpawnTime, maxSpawnTime);

            Enemy newEnemy = CreateEnemy();
            newEnemy.transform.position = Random.insideUnitCircle * spawnRange;
            Color newColor = colors[Random.Range(0, colors.Count)];
            newEnemy.SetUpEnemy(newColor);

            GameObject newHero = Creator.Create(heroPrefab, transform);
            newHero.transform.position = Random.insideUnitCircle * spawnRange;

        }
    }








    public Enemy CreateEnemy()
    {
        Enemy newEnemy;

        newEnemy = Creator.Create(enemyPrefab);

        return newEnemy;
    }



    public void KillEnemy(Enemy killedEnemy)
    {
        killedEnemy.gameObject.SetActive(false);
        inactiveEnemies.Add(killedEnemy);
    }



}
