using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalSpell : MonoBehaviour
{
    public int spellSpeed = 10;
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
        bool xIsNegative = direction.x < 0 ? true : false;
        bool yIsNegative = direction.y < 0 ? true : false;
        Debug.Log("algebra x " +(direction.x/(System.Math.Abs(direction.x) + System.Math.Abs(direction.y))));
        Debug.Log("alegbra y " + (direction.y/(direction.x + direction.y)));
        Debug.Log("complete algebra " + ((direction.x/(direction.x + direction.y)) + (direction.y/(direction.x + direction.y))));
        //get gameObject rb
        Rigidbody2D spellRigidBody = gameObject.GetComponent<Rigidbody2D>();
        //calculate velocity
        Vector2 velocity = new Vector2((xIsNegative ? -1 *(System.Math.Abs(direction.x)/(System.Math.Abs(direction.x) + System.Math.Abs(direction.y))) : (System.Math.Abs(direction.x)/(System.Math.Abs(direction.x) + System.Math.Abs(direction.y)))),
                                        ( yIsNegative? -1 * (System.Math.Abs(direction.y)/(System.Math.Abs(direction.x) + System.Math.Abs(direction.y))) : (System.Math.Abs(direction.y)/(System.Math.Abs(direction.x) + System.Math.Abs(direction.y)))));
        Debug.Log("velocity = " + velocity);
        Debug.Log("spell speed is : " + spellSpeed);
        Debug.Log("velocity x multiplyed: " + velocity.x * spellSpeed);
        Debug.Log("velocity y multiplyed: " + velocity.y * spellSpeed);
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
