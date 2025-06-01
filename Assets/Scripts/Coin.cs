using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // how quickly to rotate the coin in each axis 
    public Vector3 rotateSpeed;
    public GameObject coinFloatPoints;

    // local
    Score score;
    AudioSource coinCollect;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
        score.maxDiamonds++;

        coinCollect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime);
    }
    void ShowFloatingText()
    {
      Instantiate(coinFloatPoints, transform.position, Quaternion.LookRotation(transform.position - Camera.main.transform.position));
    }
    private void OnTriggerEnter(Collider other)
    {
        // will only be collected by game objects with the tag "Player"
        if (other.CompareTag("Player"))
        {
            coinCollect.Play();
            score.currentDiamonds++;
            ShowFloatingText();
            Destroy(gameObject, (float).3);
        }
    }
}
