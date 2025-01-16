using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerRespawn : MonoBehaviour
{
 public Vector3 respawnPoint;
    private float speed = 10.0f;
    private Rigidbody2D rb;
    private BoxCollider2D boxColliderPlayer;
    private bool dead = false;
   [SerializeField] private Animator anim;

    private void Awake()
    {

        //=============================Get les References================//
        rb = GetComponent<Rigidbody2D>();
        boxColliderPlayer = GetComponent<BoxCollider2D>();
      

    }
    private void Update()
    {
        teleportAshes();
    }
    
    public void RespawnNow()
    {
     
       
        boxColliderPlayer.enabled = false;
        rb.gravityScale = 0;
        dead = true;
        anim.SetTrigger("IsDead");
        StartCoroutine(EnableCollider());
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "TriggerMort")
        {
           
                RespawnNow();
                
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TriggerSpawn")
        {
            

               
                rb.gravityScale = 1;
                dead = false;

            
        }
    }
    public IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(8);
        boxColliderPlayer.enabled = true;
    }
    private void teleportAshes() { 
     if (dead)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, respawnPoint, step);
        }
    }
}