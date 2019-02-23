using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float speed; //boss speed
    public float stoppingDistance; //how close to the player
    public float retreatDistance; //when to retreat

    private float timeBetweenShots; //shots shots shots
    public float startTimeBetweenShots;

    public GameObject projectile;
    public Transform player; //gets location of player

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //if the distance between player and boss is greater then stopping distance, move towards him
        } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
        {
            transform.position = this.transform.position; //if the boss in between stopping and retreat, he will sit on his ass
        } else if ((Vector2.Distance(transform.position, player.position) < retreatDistance))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position /*at bosses position*/, Quaternion.identity /*means no rotation*/);
            timeBetweenShots = startTimeBetweenShots; 
        } else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
