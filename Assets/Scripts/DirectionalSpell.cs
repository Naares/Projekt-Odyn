using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalSpell : MonoBehaviour
{
    public float spellSpeed = 1;
    public float detonationTime = 10f;
    public float detonationRadius = 5f;

    public Vector3 direction = new Vector3(0,0,0);

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
    }

    // Update is called once per frame
    void Update()
    {
        if(detonationTime < Time.time){
            //Evaulate damage and make explosion
            Debug.Log("BOOM");
            Destroy(gameObject);
        }
    }
}
