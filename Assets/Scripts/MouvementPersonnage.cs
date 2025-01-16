using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MouvementPersonnage : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Animator anim;
    private BoxCollider2D boxColliderPlayer;
    private float horizontalInput;
    private int jumpsCounter = 3;
    private PlayerRespawn _playerRespawn;
    private bool isItTouchingInteractable;
    private GameObject dernierInteractableTouche;
    private int maxJumps = 3;
    private void Awake()
    {

        //=============================Get les References================//
        rb = GetComponent<Rigidbody2D>();
        _playerRespawn = GetComponent<PlayerRespawn>();
          boxColliderPlayer = GetComponent<BoxCollider2D>();
        transform.localScale = new Vector3(-1, 1, 1);

    }


    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        Walk();

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            jump();
           

        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Kill();
        }

        if (!isGrounded() && !_playerRespawn.isDead)
        {
            anim.SetBool("InTheAir" , true);
        }
        else
        {
            anim.SetBool("InTheAir", false);
        }
        //=============================Flip sprite================//
        if (horizontalInput > 0.01f) // Flip du sprite si tu marche left and right
            transform.localScale = new Vector3(-1, 1, 1);

        if (horizontalInput < -0.01f) // Flip du sprite si tu marche left and right
            transform.localScale = Vector3.one;


        //=============================Set les params du animator================//
          anim.SetBool("IsWalking", horizontalInput != 0);
         anim.SetBool("grounded", isGrounded());
    }

    private void Walk()
    {
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }
    private void jumpCd()
    {
        if(jumpsCounter == 0)
        {
            jumpsCounter = maxJumps ;
        }
    }
    private void Kill()
    {
        anim.SetTrigger("IsDead");
        if (rb != null)
        {
            transform.localScale = Vector3.one;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;


        }
        _playerRespawn.StartCoroutine("AnimationMort");
        if (dernierInteractableTouche != null)
        {
            dernierInteractableTouche.GetComponent<Interactable>().interact();

        }

    }
    private void jump()
    {
        
        if (isGrounded())
        {
            jumpCd();
            Debug.Log("Saut de la terre");
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
             anim.SetTrigger("jump");
            jumpsCounter--;
            Debug.Log(jumpsCounter);
        }

        else if(jumpsCounter >0 &&!isGrounded())
        {
            jumpCd();

            Debug.Log("SautDansLesAirs");
            rb.velocity = new Vector2(rb.velocity.x, jumpPower - 0.5f );
             anim.SetTrigger("doubleJump");
            jumpsCounter--;
            Debug.Log(jumpsCounter);

        }
    }
    //=============================Verifie si le personnage est sur le ground ou dans les airs================//

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColliderPlayer.bounds.center, boxColliderPlayer.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            isItTouchingInteractable = true;
            Debug.Log(isItTouchingInteractable);
            dernierInteractableTouche = collision.gameObject;
        }
        if (collision.gameObject.tag == "PlumeLaTraverse")
        {
            jumpsCounter = 4; 
            maxJumps = 4;
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isItTouchingInteractable = false;
        Debug.Log(isItTouchingInteractable);

    }

}
