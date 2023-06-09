using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalSpell : MonoBehaviour
{
    public int spellSpeed = 10;
    public float detonationTime = 10f;
    public float detonationRadius = 5f;
    public int spellId = 1001;
    public float damage = 10f;
    private float timeOfInstantination = 0f;

    private float lenghtOfAudio = 0f;

    private AudioSource finisher = null;
    private GameObject player = null;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        finisher = gameObject.GetComponent<AudioSource>();
        timeOfInstantination = Time.time;
        detonationTime += Time.time;
        lenghtOfAudio = detonationTime - finisher.clip.length ;
        gameObject.transform.position = player.transform.position;
        //calculate the direction to the target
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
        bool xIsNegative = direction.x < 0 ? true : false;
        bool yIsNegative = direction.y < 0 ? true : false;
        Rigidbody2D spellRigidBody = gameObject.GetComponent<Rigidbody2D>();
        //calculate velocity
        Vector2 velocity = new Vector2((xIsNegative ? -1 *(System.Math.Abs(direction.x)/(System.Math.Abs(direction.x) + System.Math.Abs(direction.y))) : (System.Math.Abs(direction.x)/(System.Math.Abs(direction.x) + System.Math.Abs(direction.y)))),
                                        ( yIsNegative? -1 * (System.Math.Abs(direction.y)/(System.Math.Abs(direction.x) + System.Math.Abs(direction.y))) : (System.Math.Abs(direction.y)/(System.Math.Abs(direction.x) + System.Math.Abs(direction.y)))));
        //calculate rotation
        float angle = Mathf.Atan2(velocity.y, velocity.x)*180 / Mathf.PI;
        gameObject.transform.eulerAngles = new Vector3(0,0,angle);
        spellRigidBody.velocity = velocity * spellSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(lenghtOfAudio < Time.time && !finisher.isPlaying){
            finisher.Play();
        }

        if(detonationTime < Time.time){
            Destroy(gameObject);
        }
    }
    private void FixedUpdate() {
        //TODO: create another circle collider and check if it triggers with enemy, if so dall detonation instantly
    }

    private void OnDestroy() {
        //search all triggers if those are enemy deal damage to them
        //activate the circle
        Collider2D[] targets = Physics2D.OverlapCircleAll(new Vector2(gameObject.transform.position.x,gameObject.transform.position.y),this.detonationRadius);
        Debug.Log("colliders lengts: " + targets.Length);
        foreach(var item in targets){
            Debug.Log("item is :" + item.gameObject);
            if(item.gameObject.tag == "Entity-Enemy"){
                EnetityStats entity = item.gameObject.GetComponent<EnetityStats>();
                entity.TakeDamage(10);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collidingObject) {
        Debug.Log("Collision with another object");
        Destroy(gameObject);        
    }
}
