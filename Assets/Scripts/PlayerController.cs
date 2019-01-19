using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D myRigidbody;
    private Animator anim;

    private bool playerMoving;
    private Vector2 lastMove;


    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {

        playerMoving = false;
        //pohyb doleva a doprava
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
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
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical") * moveSpeed);
        }
        //zastaveni na miste
        else
        {
           myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }
       

        //nastaveni animaci, aby kdyz se player zastavi, tak aby divali smerem kudy sel  
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}

