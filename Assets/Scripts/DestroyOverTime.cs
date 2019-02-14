using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    //program that kills effects so they dont add up and slow down the game
    public float countToDestroy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countToDestroy -= Time.deltaTime;

        if(countToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
