using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour { 

    public int playerMaxHealth;
    public int playerCurrentHealth;

    public float waitToReload = 3; //Time to revival
    public bool reloading; //if level is reloading

    private bool flashActive; //for damage taking stuff
    public float flashLength; //how long does it take to flash
    private float flashCounter; //flashinng time

    private SpriteRenderer flashy; //via this we can manipulate the sprite to flash

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        flashy = GetComponent<SpriteRenderer>();
        reloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCurrentHealth <= 0) //manages death and reloading
        {
            gameObject.SetActive(false);
            reloading = true;
            // waitToReload -= Time.deltaTime;
                //if (waitToReload <= 0f)
                //{
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reloading the current level
                    gameObject.SetActive(true);
                //}
        }

        if (flashActive) //manages damage flashing
        {
            if (flashCounter > flashLength * .66f)
            {
                flashy.color = new Color(flashy.color.r, flashy.color.g, flashy.color.b, 0f);
            } else if (flashCounter > flashLength * .33f)
            {
                flashy.color = new Color(flashy.color.r, flashy.color.g, flashy.color.b, 1f);
            } else if(flashCounter > 0f)
            {
                flashy.color = new Color(flashy.color.r, flashy.color.g, flashy.color.b, 0f);
            } else
            {
                flashy.color = new Color(flashy.color.r, flashy.color.g, flashy.color.b, 1f);
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;

        }

    }

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;

        flashActive = true;
        flashCounter = flashLength;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
