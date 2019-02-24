using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float currentTimer; //general timer for stuff
    public float startingTimer;

    public float speed; //boss speed
    public float stoppingDistance; //how close to the player
    public float retreatDistance; //when to retreat

    private float timeBetweenShots; //shots shots shots
    public float startTimeBetweenShots;

    public float timeToCharge; //time for charge duration
    private float timeBetweenCharge; //pause between charge
    public float timeToChargeTimer; //time for the whole charge thing
    public float chargeSpeed; //speed for charging
    
    public float pauseTime; //pauses between shooting and charging

    public GameObject projectile;
    public Transform player; //gets location of player

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        currentTimer = startingTimer;

        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
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
        else if (currentTimer <= 7 && currentTimer > 4)
        {

        }
        else if (currentTimer <= 4 && currentTimer > 2)
        {

        }
        else if (currentTimer <= 2 && currentTimer > 0)
        {

        }
    }
}
