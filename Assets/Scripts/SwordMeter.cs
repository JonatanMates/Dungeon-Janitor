﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordMeter : MonoBehaviour
{

    public Slider swordBar;
    public Text swordText;
    public PlayerController swordTime;
    //public PlayerHealthManager playerManage;

    private static bool UIExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!UIExists) //sets it to be syncronized when moving scene to scene
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

            // Update is called once per frame
    void Update()
    {
         swordBar.maxValue = swordTime.attackTime; //sets the slider to hold the attack time
         swordBar.value = swordTime.attackTimeCounter; //hold countdown to next attack 

        //if (playerManage.reloading == true)
        {
            
        }
    }
    
}