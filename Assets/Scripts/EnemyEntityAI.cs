using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntityAI : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player = null;
    GameObject detectionRadius = null;
    void Start()
    {
        player = GameObject.Find("Player");
        //go tovards the player if its in its detection radius
        detectionRadius = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] currentCollisions = Physics2D.OverlapCircleAll(new Vector2(gameObject.transform.position.x,gameObject.transform.position.y),detectionRadius.GetComponent<CircleCollider2D>().radius);
        foreach(var item in currentCollisions){
            Debug.Log("item : " + item);
            if(item.gameObject == player){
                Debug.Log("player is in detection radius");
            }
        }
    }
}
