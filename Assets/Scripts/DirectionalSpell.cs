using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalSpell : MonoBehaviour
{
    public float spellSpeed = 10f;
    public float detonationTime = 10f;
    public float detonationRadius = 5f;
    public int spellId = 1;
    public float damage = 10f;
    private float timeOfInstantination = 0f;
    // Start is called before the first frame update
    void Start()
    {
        timeOfInstantination = Time.time;
        detonationTime += Time.time;
        Debug.Log("detonation time: " + detonationTime);
        Debug.Log("current time: " + Time.time);
        //calculate the direction to the target
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
        //get gameObject rb
        Rigidbody2D spellRigidBody = gameObject.GetComponent<Rigidbody2D>();
        //calculate velocity
        Vector2 velocity = new Vector2(direction.normalized.x,direction.normalized.y);
        Debug.Log("velocity = " + velocity);
        // set velocity - this doe not multiply --- why??? 
        spellRigidBody.velocity = velocity * spellSpeed;
        Debug.Log("directional velocity: " + spellRigidBody.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        if(detonationTime < Time.time){
            //Evaulate damage and make explosion
            CircleCollider2D collider =  gameObject.AddComponent<CircleCollider2D>();
            collider.isTrigger = true;
            collider.radius = detonationRadius;
            //search all triggers if those are enemy deal damage to them
            
            Destroy(gameObject);
        }
    }
}
