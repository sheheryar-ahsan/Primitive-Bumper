using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject playerControllerObject;
    private Enemy enemy;
    public Vector3 offSet;
    

    void LateUpdate()
    {
        GetReference();
        transform.position = CenterPoint();
    }

    private void GetReference()
    {
        playerController = playerControllerObject.GetComponent<PlayerController>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }

    public Vector3 CenterPoint()
    {
        float posX;
        float posY;
        float posZ;
        Vector3 playerPos = new Vector3(playerController.transform.position.x,playerController.transform.position.y,transform.position.z);
        Vector3 enemyPos  = new Vector3(enemy.transform.position.x,enemy.transform.position.y,enemy.transform.position.z);
        Vector3 addedPos = (playerPos + enemyPos)/2;
        return addedPos;
    }
}
