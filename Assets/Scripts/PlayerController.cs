using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera currentCamera;
    //Default value for camera distance is 10m
    private float cameraDistance = -10;
    
    public float characterSpeed = 10;

    private float horizontal = 0;
    private float vertical = 0;

    private Rigidbody2D playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        //setup the default camera distance as the object in the scene, if no object exists it will error anyways
        cameraDistance = currentCamera.transform.position.z;
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Debug.Log("horizontal input: " + horizontal);
        Debug.Log("Vertical input : " + vertical);
    }

    void FixedUpdate() {
        playerRigidBody.velocity = new Vector2(horizontal * characterSpeed, vertical * characterSpeed);
    }

    private void LateUpdate() {
        //Always have the camera focused on player
        currentCamera.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,cameraDistance);
    }
}
