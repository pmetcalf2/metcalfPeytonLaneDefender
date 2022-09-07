using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemyBehaviour : MonoBehaviour
{
    public int enemyhealth = 5;
    public AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        StartRunning();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemyhealth--;
            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(hitSound, camPos);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            GameController gc = GameObject.FindObjectOfType<GameController>();
            gc.LoseHealth();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(enemyhealth <= 0)
        {
            GameController gc = GameObject.FindObjectOfType<GameController>();
            gc.IncreaseScore(100);
            Destroy(gameObject);
            
        }
    }
    public void StartRunning()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
    }

}
