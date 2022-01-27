using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Enemy enemy;

    void Update()
    {

    }

    public void PassEnemy(Enemy enemyObject)
    {
        enemy = enemyObject;
    }

    //public void ScoreBoard()
    //{
    //    if(enemy == null)
    //    {
    //        Debug.Log("Enemy Destroyed");
    //    }
    //}
}
