using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{


    [SerializeField]
    private Enemy enemyPrefab;



    [SerializeField]
    private List<Enemy> inactiveEnemies;




    public Enemy CreateEnemy()
    {
        Enemy newEnemy;

        //check if there is an enemy in the pool
        //if yes, activate it and return that
        //if no, create a new one

        if(inactiveEnemies.Count > 0)
        {
            newEnemy = inactiveEnemies[0];
            inactiveEnemies.Remove(newEnemy);
            //  inactiveEnemies.RemoveAt(0);

            return newEnemy;
        }
        else
        {
            newEnemy = Instantiate(enemyPrefab, transform);
            return newEnemy;
        }

    }



    public void KillEnemy(Enemy killedEnemy)
    {
        killedEnemy.gameObject.SetActive(false);
        inactiveEnemies.Add(killedEnemy);
    }




   
}
