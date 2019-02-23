using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController: MonoBehaviour {

    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalModifier;

    private Rigidbody2D myRigidbody;
    private Animator anim;

    private bool playerMoving;
    private Vector2 lastMove;

    private bool attacking; //is the player attacking?
    public float attackTime; //how long does the player attack for
    public float attackTimeCounter; //counter till the next attack




    
    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update() {

        playerMoving = false;

        if (!attacking)
        {
            //pohyb doleva a doprava
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, 0f);
            }
            //zastaveni na miste
            else
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            }
            //pohyb nahoru a dolu
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical") * moveSpeed);
            }
            //zastaveni na miste
            else
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }

            //detecting attacks

            if (Input.GetKeyDown(KeyCode.Space))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
            }

            if (Mathf.Abs (Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = moveSpeed * diagonalModifier; //sets the movespeed to be same when diagnol
            } else
            {
                currentMoveSpeed = moveSpeed;
            }


        }
        

        if(attackTimeCounter >= 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if(attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }

     //nastaveni animaci, aby kdyz se player zastavi, tak aby divali smerem kudy sel  
     anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
     anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
     anim.SetBool("PlayerMoving", playerMoving);
     anim.SetFloat("LastMoveX", lastMove.x);
     anim.SetFloat("LastMoveY", lastMove.y);    
    }
}

