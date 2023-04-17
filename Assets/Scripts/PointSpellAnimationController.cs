using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpellAnimationController : MonoBehaviour
{
    //řekněme že jsem to tu pěkně posral.....
    public RuntimeAnimatorController pointSpellMultipleAnims;
    public int ammtOfAnims = 1; // bude se určovat podle levelu spellu (kolik animací by to mělo mít)
    private void Start() {
        GameObject empty = new GameObject("Storm anim");
        empty.AddComponent<SpriteRenderer>();
        // uncomment this line when debugging is complete 
        empty.transform.parent = gameObject.transform;
        CircleCollider2D range = gameObject.GetComponent<CircleCollider2D>();
        empty.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(range.radius * - 1,range.radius),gameObject.transform.position.y + Random.Range(range.radius * - 1 , range.radius),0);
        empty.AddComponent<Animator>();
        Animator anim = empty.GetComponent<Animator>();        
        anim.runtimeAnimatorController = pointSpellMultipleAnims;
        for(int i = 0 ; i < ammtOfAnims - 1; i++){
            GameObject singleStorm = Instantiate<GameObject>(empty,gameObject.transform);
            singleStorm.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(range.radius * - 1,range.radius),gameObject.transform.position.y + Random.Range(range.radius * - 1 , range.radius),0);
            Debug.Log("single strom position = " + singleStorm.transform.position);
        }

    }

    private void Update() {
        
    }
}
