using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnetityStats : MonoBehaviour
{
    public int level = 1;
    public int health = 100;
    //additional health will be altered by items
    public int constitution = 5;
    public int inteligence = 2;
    public int strength = 12;
    // Start is called before the first frame update
    void Start()
    {
        constitution = constitution * (level  / 2 );
        strength = strength * (level / 2);
        inteligence = inteligence * (level / 2);
        health = (constitution * 3) + health;
        Debug.Log("constitution is : " + constitution);
        Debug.Log("strength is : " + strength);
        Debug.Log("inteligence is : " + inteligence);
        Debug.Log("entity hp is : " + health);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            //death
            Destroy(gameObject);
            if(gameObject.tag == "Entity-Enemy"){
                //Drop some loot to player?
            }
        }        
    }

    public void TakeDamage(int damage){
        //calculates the entity hitpoints
        health = health - (damage - strength);
        Debug.Log("enety took damage, current health is : " + health);
    }
}
