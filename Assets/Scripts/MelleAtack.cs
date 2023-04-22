using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAtack : MonoBehaviour
{
    public GameObject player;
    public float range = 1f;
    public int nOfAtacks = 1;
    public bool isDirectional = true;
    public int damagePerAtack = 5;
    // Start is called before the first frame update
    private PlayerController pc; 
    void Start()
    {
        if(player == null){
            player = GameObject.Find("Player");
        }
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isDirectional){
            CreateDirectionalCollider();
        }else{
            CreateCircleCollider();
        }
    }

    void CreateDirectionalCollider(){
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
        Vector2 boxSpawnPoint = new Vector2( (range * (direction.x / (direction.x +  direction.y))), (range * (direction.y / (direction.x + direction.y))));
        Collider2D[] collisions = Physics2D.OverlapBoxAll(boxSpawnPoint,boxSpawnPoint,0);
        SearchForEnemiesAndDealDamage(collisions);
    }

    void CreateCircleCollider(){
        Collider2D[] collisions = Physics2D.OverlapCircleAll(new Vector2(player.transform.position.x,player.transform.position.y),range);
        SearchForEnemiesAndDealDamage(collisions);
    }

    void SearchForEnemiesAndDealDamage(Collider2D[] collisions){
        Debug.Log("Collisions: " + collisions);
        foreach(var item in collisions){
            if(item.tag == "Entity-enemy"){
                item.GetComponent<EnetityStats>().TakeDamage(damagePerAtack);
            }
        }
    }
}
