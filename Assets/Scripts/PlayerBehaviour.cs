using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 3;

    public Transform firePoint;
    public GameObject bullet;
    public GameObject explosion;
    public AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float yMove = Input.GetAxis("Vertical");
        Vector3 newPostion = transform.position;
        newPostion.y += yMove * Time.deltaTime * speed;
        transform.position = newPostion;

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            Instantiate(explosion, firePoint.position, firePoint.rotation);
            StartCoroutine(bulletExplosion());

            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(shootSound, camPos);


        }
    }

    public IEnumerator bulletExplosion()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(GameObject.Find("tank_explosion4(Clone)"));
    }
}
