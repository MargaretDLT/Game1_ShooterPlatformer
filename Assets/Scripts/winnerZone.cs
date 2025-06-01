using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class winnerZone : MonoBehaviour
{
    public AudioSource winnerSound;
    public GameObject winnerEffect;
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        winnerSound = GetComponent<AudioSource>();
        score = GameObject.FindObjectOfType<Score>();
    }
    void ShowWinnerEffect()
    {
        Instantiate(winnerEffect, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && score.currentDiamonds >= score.maxDiamonds)
        {
            winnerSound.Play();
            ShowWinnerEffect();
            Destroy(gameObject, (float)1.5);
            Invoke("Reload", 1.4f);    // wait 1/4 seconds, then load MENU
        }
        else
        {
            Debug.Log("No gameobject with Score.cs script");
        }
    }
    void Reload()
    {
        SceneManager.LoadScene(0);  // loads index=0 scene - should be MENU
    }
}
