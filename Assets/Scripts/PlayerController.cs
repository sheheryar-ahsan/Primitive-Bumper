using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private GameObject gameObjectRefered;
    private CameraManager cameraManager;
    public float speed;
    public bool isOnFloor = true;
    public bool isEnemy = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        PlayerKeyboardMovement();
    }

    private void PlayerKeyboardMovement()
    {
        float rightInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(focalPoint.transform.forward * rightInput * speed);
        playerRb.AddForce(focalPoint.transform.right * horizontalInput * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerGettingReference(collision.gameObject);
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

    public void PlayerGettingReference(GameObject gameObjectReferedIs) // Store the collided game object reference for later
    {
        gameObjectRefered = gameObjectReferedIs;
    }

    public void IncreaseOthersSize()
    {
        float newSizeX = gameObjectRefered.transform.localScale.x + 1;
        float newSizeY = gameObjectRefered.transform.localScale.y + 1;
        float newSizeZ = gameObjectRefered.transform.localScale.z + 1;
        gameObjectRefered.transform.localScale = new Vector3(newSizeX, newSizeY, newSizeZ);
        Debug.Log("Enemy Size Increased");
    }
    private void PlayerMouseMovement() /* For the mouse based input to controll the player */ /*Not in USE*/
    {
        float forwardInput = Input.GetAxis("Mouse Y");
        float sideInput = Input.GetAxis("Mouse X");
        playerRb.AddForce(Vector3.forward * speed * -forwardInput);
        playerRb.AddForce(Vector3.right * speed * -sideInput);
    }
}
