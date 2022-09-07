using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score;
    public GameObject[] waypoints;
    public TMP_Text healthText;
    public int health = 3;
    public GameObject[] enemy;
    public string sceneToLoad;
    public int pickEnemy;
    public int spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        healthText.text = "Lives: " + health.ToString();
        InvokeRepeating("SpawnEnemy", 0f, 3f);
        
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            RestartGame();
        }
    }
    public void LoseHealth()
    {
        health--;
        healthText.text = "Lives: " + health.ToString();
        if (health <= 0)
        {
            RestartGame();

        }



    }
    public void SpawnEnemy()
    {
       pickEnemy = Random.Range(0, enemy.Length);
       spawnPoint = Random.Range(0, waypoints.Length);
       Instantiate(enemy[pickEnemy], waypoints[spawnPoint].transform.position, transform.rotation);
    }
    public void IncreaseScore(int amount)
    {

        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }
}
