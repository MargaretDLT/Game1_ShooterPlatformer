using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().moveSpeed = 0.0f; //stop the player from moving
            Invoke("Reload", 0.25f); //wait 1/4 seconds, then reload level
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
