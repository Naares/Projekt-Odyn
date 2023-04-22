using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    public float radius = 1f;
    public AuraBuffs type = AuraBuffs.Frost;
    public int value = 1;

    public float tickRate = 1f; //1s

    public GameObject player;
    private float _timeOfNextTick = 0;
    // Update is called once per frame
    void FixedUpdate()
    {  
        if(Time.time < _timeOfNextTick){
            Collider2D[] collisions = Physics2D.OverlapCircleAll(new Vector2(player.transform.position.x,player.transform.position.y),radius);
            _timeOfNextTick = Time.time + tickRate;
            switch (type){
                case AuraBuffs.Frost:
                //TODO slow enemies in this aura
                break;
                case AuraBuffs.Fire:
                // TODO deal heavy damage to the enemies
                break;
            }
        }
    }
}

public enum AuraBuffs{
    Frost,
    Fire,
}
