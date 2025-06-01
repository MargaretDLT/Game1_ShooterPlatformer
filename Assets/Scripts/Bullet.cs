using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    AudioSource pew;

    // Start is called before the first frame update
    void Start()
    {
        pew = GetComponent<AudioSource>();
        pew.Play();
        // kill this bullet after 3-seconds
        Destroy(this.gameObject, 3.0f);
        
    }

    // Update is called once per frame
    void Update()
    {

     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

            player.GetComponent<Shoot>().enabled = false;
            
        }
        // always destroy bullets that collide 
        Destroy(this.gameObject);
    }
}
