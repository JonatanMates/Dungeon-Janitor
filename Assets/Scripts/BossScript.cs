using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossScript : MonoBehaviour
{

    //TIMER SECTION

    public float currentTimer; //general timer for stuff
    public float startingTimer;

    //THIS IS FOR SHOOTING STUFF 

    public float speed; //boss speed
    public float stoppingDistance; //how close to the player
    public float retreatDistance; //when to retreat

    private float timeBetweenShots; //shots shots shots
    public float startTimeBetweenShots;

    public GameObject projectile;
    public Transform player; //gets location of player

    //THIS IS FOR THE RANDOM MOVEMENT

    public float timeBetweenMove; //time between moves
    private float timeBetweenMoveCounter;

    public float timeToMove; //time it takes to move
    private float timeToMoveCounter;

    private Rigidbody2D myRigidbody;
    private bool moving; //checks if the object is moving
    private Vector3 moveDirection; //Determines direction to move

    public float speedRandom; //speed for random movement

    //THIS IS FOR CHARGING SECTION

    private Vector2 target;
    public float timeToCharge;
    private float timeBetweenCharge;

    //FOR CHILLAXING PART
    private bool flashActive; //for damage taking stuff
    public float flashLength; //how long does it take to flash
    private float flashCounter; //flashinng time

    private SpriteRenderer flashy; //via this we can manipulate the sprite to flash


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //
        target = new Vector2(player.position.x, player.position.y); //

        currentTimer = startingTimer;

        timeBetweenShots = startTimeBetweenShots;
        timeToCharge = timeBetweenCharge;

        myRigidbody = GetComponent<Rigidbody2D>(); //Stuff for random moving

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); //Stuff for random moving
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f); //Stuff for random moving

        flashy = GetComponent<SpriteRenderer>(); //the return of FLASHY
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimer <= 0)
        {
            currentTimer = 10;
        }
        currentTimer -= 1 * Time.deltaTime;
        if (currentTimer <= 10 && currentTimer > 7) //timer between 0 and 3 shoots shit
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //if the distance between player and boss is greater then stopping distance, move towards him
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
            {
                transform.position = this.transform.position; //if the boss in between stopping and retreat, he will sit on his ass
            }
            else if ((Vector2.Distance(transform.position, player.position) < retreatDistance))
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            if (timeBetweenShots <= 0)
            {
                Instantiate(projectile, transform.position /*at players position*/, Quaternion.identity /*means no rotation*/); //spawns projectile
                timeBetweenShots = startTimeBetweenShots;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
        else if (currentTimer <= 7 && currentTimer > 4) //je to trochu zkanabilizovany z scriptu pro cervenyho slima
        {
            if (moving)
            {
                timeToMoveCounter -= Time.deltaTime;
                myRigidbody.velocity = moveDirection;

                if (timeToMoveCounter < 0f)
                {
                    moving = false;
                    //timeBetweenMoveCounter = timeBetweenMove;
                    timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                }

            }
            else
            {
                timeBetweenMoveCounter -= Time.deltaTime;
                myRigidbody.velocity = Vector2.zero;

                if (timeBetweenMoveCounter < 0f)
                {
                    moving = true;
                    //timeToMoveCounter = timeToMove;
                    timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                    moveDirection = new Vector3(Random.Range(-1f, 1f) * speedRandom, Random.Range(-1f, 1f) * speedRandom, 0f);

                }
            }
        }
        else if (currentTimer <= 4 && currentTimer > 2) //charging section
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (currentTimer <= 2 && currentTimer > 0)
        {
            transform.position = this.transform.position;

            if (flashActive) //manages damage flashing WIP
            {
                if (flashCounter > flashLength * .66f)
                {
                    flashy.color = new Color(flashy.color.r, flashy.color.g, flashy.color.b, 0f);
                }
                else if (flashCounter > flashLength * .33f)
                {
                    flashy.color = new Color(flashy.color.r, flashy.color.g, flashy.color.b, 1f);
                }
                else if (flashCounter > 0f)
                {
                    flashy.color = new Color(flashy.color.r, flashy.color.g, flashy.color.b, 0f);
                }
                else
                {
                    flashy.color = new Color(flashy.color.r, flashy.color.g, flashy.color.b, 1f);
                    flashActive = false;
                }

                flashCounter -= Time.deltaTime;

            }
        }
        //add if enemy health <= 0, aplication shutdown.
    }
}
