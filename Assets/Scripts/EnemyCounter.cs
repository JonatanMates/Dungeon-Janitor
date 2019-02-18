using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public int currentEnemies;
    private GameObject[] enemies;
    public Text enemyNumber;

    private static bool UIExists;

    // Start is called before the first frame update
    void Start()
    {
        /*if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
      
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int currentEnemies = enemies.Length;

        enemyNumber.text = "Enemies left: " + currentEnemies ; 
    }
}
