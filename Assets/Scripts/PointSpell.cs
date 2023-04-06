using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpell : MonoBehaviour
{
    public float spellDuration = 5f;
    public float tickRate = .5f;

    public int spellTickingDamage = 10;

    public bool isDelayed = false;

    private float spellEndTime = 0f;
    private float spellNextTickTime = 0f;
    private CircleCollider2D currentCollider;
    // Start is called before the first frame update
    void Start()
    {   
        Vector3 spellPoisiton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spellPoisiton.z = -1;
        gameObject.transform.position = spellPoisiton;
        currentCollider = gameObject.GetComponent<CircleCollider2D>();
        if(isDelayed){
            spellEndTime = Time.time + spellDuration + tickRate;
            spellNextTickTime = Time.time + tickRate;
        }else{
            spellEndTime = Time.time + spellDuration;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time > spellNextTickTime){
            //Evaulate targets in the area and calulate damage
            CalculateDamage();
            spellNextTickTime = Time.time + tickRate;
        }
        //this will be 2nd due to the last tick damage
        if(Time.time > spellEndTime){
            Destroy(gameObject);
            return;
        }
    }

    void OnDestroy() {
    }

    private void CalculateDamage(){
        Collider2D[] targets = Physics2D.OverlapCircleAll(new Vector2(gameObject.transform.position.x,gameObject.transform.position.y),currentCollider.radius);
        foreach(var item in targets){
            if(item.gameObject.tag == "Entity-Enemy"){
                EnetityStats entity = item.gameObject.GetComponent<EnetityStats>();
                entity.TakeDamage(spellTickingDamage);
            }
        }
    }
}
