using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealthBar : MonoBehaviour
{

    public Slider healthBars;
    public Text healthText;
    public EnemyHealthManager enemyManager;

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
        healthBars.maxValue = enemyManager.MaxHealth; //thats a lot of health
        healthBars.value = enemyManager.CurrentHealth; //thats no health
        healthText.text = "HP: " + enemyManager.CurrentHealth + "/" + enemyManager.MaxHealth;
    }
}
