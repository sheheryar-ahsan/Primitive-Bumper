using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRB;
    private GameObject player;
    public bool isPlayer = false;
    public bool isOnFloor = true;
    private GameObject gameObjectRefered;

    void Start()
    {
        GetReferences();
    }

    void Update()
    {
        EnemyMovement();
    }

    private void GetReferences()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void EnemyMovement() // For the enemy AI
    {
        if (player != null)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRB.AddForce(lookDirection * speed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyGettingReference(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("OffFloor"))
        {
            if (gameObjectRefered != null)
            {
                IncreaseOthersSize();
            }
            Destroy(this.gameObject);
        }
    }

    public void EnemyGettingReference(GameObject gameObjectReferedIs) // Store the collided game object reference for later
    {
        gameObjectRefered = gameObjectReferedIs;
    }

    public void IncreaseOthersSize()
    {
        float newSizeX = gameObjectRefered.transform.localScale.x + 1;
        float newSizeY = gameObjectRefered.transform.localScale.y + 1;
        float newSizeZ = gameObjectRefered.transform.localScale.z + 1;
        gameObjectRefered.transform.localScale = new Vector3(newSizeX, newSizeY, newSizeZ);
        Debug.Log("Player Size Increased");
    }

}
