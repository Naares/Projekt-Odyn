using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera currentCamera;
    //Default value for camera distance is 10m
    private float cameraDistance = -10;
    
    public float characterSpeed = 10;
    public float dashSpeed = 3;
    public float dashTime = 0.5f;

    private float horizontal = 0;
    private float vertical = 0;

    public float dashCooldownInSeconds = 5f;

    private float _dashCooldownCounter;
    private float _dashAnimationTimeCounter;
    bool playerDashing = false;

    private Rigidbody2D playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        cameraDistance = currentCamera.transform.position.z;
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        _dashCooldownCounter = Time.time;
        _dashAnimationTimeCounter = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        // TODO : check the timing on this animation
        if(playerDashing){
            if(Time.time > _dashAnimationTimeCounter){
                playerDashing = false;
                playerRigidBody.velocity = Vector2.zero;
            }
            else{
                return;
            }
        }
        if(Input.GetAxisRaw("Dash") != 0 && Time.time > _dashCooldownCounter && (vertical != 0 || horizontal !=0)){
                _dashCooldownCounter = Time.time + dashCooldownInSeconds;
                Dash();
                playerDashing = true;
                _dashAnimationTimeCounter = Time.time + dashTime;
        }else{
            playerRigidBody.velocity = new Vector2(horizontal * characterSpeed, vertical * characterSpeed);
        }
    }

    private void LateUpdate() {
        //Always have the camera focused on player
        currentCamera.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,cameraDistance);
    }

    //Dashes the player to where he is currently facing (player will have to move to dash)
    //TODO: in UI add cooldow for dash (different talents will have diferrent props for dash so probably move it into spell manager)
    private void Dash(){
        Debug.Log("Player is dashing...");
        if(vertical != 0){
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x,vertical * characterSpeed * dashSpeed);
        }
        if(horizontal != 0){
            playerRigidBody.velocity = new Vector2(horizontal * characterSpeed * dashSpeed, playerRigidBody.velocity.y);
        }
    }
}
