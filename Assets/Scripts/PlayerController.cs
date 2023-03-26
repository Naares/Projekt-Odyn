using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera currentCamera;
    //Default value for camera distance is 10m
    private float cameraDistance = -10;
    
    public float characterSpeed = 10;

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
    }

    void FixedUpdate() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0){
            if(horizontal > 0){
                transform.Translate(Vector3.right * Time.deltaTime * characterSpeed);
            }else if(horizontal < 0){
                transform.Translate(Vector3.left * Time.deltaTime * characterSpeed);
            }
        }
        if(vertical != 0){
            if(vertical > 0){
                transform.Translate(Vector3.up * Time.deltaTime * characterSpeed);
            }else if(vertical < 0){
                transform.Translate(Vector3.down * Time.deltaTime * characterSpeed);
            }
        }
    }

    private void LateUpdate() {
        //Always have the camera focused on player
        currentCamera.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,cameraDistance);
    }
}
