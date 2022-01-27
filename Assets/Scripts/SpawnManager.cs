using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemy;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 RandomPositionGenerator()
    {
        float randomPosX = Random.Range(-3, 4);
        float randomPosz = Random.Range(-3, 4);
        Vector3 randomPos = new Vector3(randomPosX, 0.6f, randomPosz);
        return randomPos;
    }

    private void EnemySpawner()
    {
        for (int i = 0; i < numberOfEnemy; i++)
        {
            GameObject temp = Instantiate(enemyPrefab, RandomPositionGenerator(), enemyPrefab.transform.rotation);
            //temp.GetComponent<Enemy>().InstializeEnemy(gameManager.GetComponent<GameManager>());
            //gameManager.GetComponent<GameManager>().PassEnemy(temp.GetComponent<Enemy>());
        }
    }
   
}
