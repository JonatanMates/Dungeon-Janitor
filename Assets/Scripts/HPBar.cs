using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class HPBar : MonoBehaviour
    { 
    
    public Slider someHealthBars;
    public Text healthSMS;
    public PlayerHealthManager mitochondria;

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
        someHealthBars.maxValue = mitochondria.playerMaxHealth; //thats a lot of health
        someHealthBars.value = mitochondria.playerCurrentHealth; //thats no health
        healthSMS.text = "HP: " + mitochondria.playerCurrentHealth + "/" + mitochondria.playerMaxHealth;
    }
}
