using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class HPBar : MonoBehaviour
    { 
    
    public Slider healthBars;
    public Text healthText;
    public PlayerHealthManager playerManager;

    private static bool UIExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBars.maxValue = playerManager.playerMaxHealth; //thats a lot of health
        healthBars.value = playerManager.playerCurrentHealth; //thats no health
        healthText.text = "HP: " + playerManager.playerCurrentHealth + "/" + playerManager.playerMaxHealth;
    }
}
