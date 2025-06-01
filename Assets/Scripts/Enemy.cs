using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.WSA;

public class Enemy : MonoBehaviour
{
    public float AlertDistance;
    public float moveSpeed;
    public GameObject stopThis; // drag a GameObject into slot in Enemy inspector in Unity

    // local
    Score score;
    GameObject TargetObject;                // reference to player or target
    Vector3 moveVector;                     // current movement 
    CharacterController EnemyController;    // character controller for movement 
    bool bAlive;                            // is enemy alive
    AudioSource destroySound;

    // Start is called before the first frame update
    void Start()
    {
        TargetObject = GameObject.FindGameObjectWithTag("Player");
        EnemyController = GetComponent<CharacterController>();
        bAlive = true; 

        score = GameObject.FindObjectOfType<Score>();
        score.maxEnemies++;
        score.currentEnemies++;

        destroySound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float TargetDistance = Vector3.Distance(this.transform.position, TargetObject.transform.position);

        // stay at location until Player moves into AlertDistance
        if (TargetDistance <= AlertDistance)
        {
            // look at target X & Z, but enemy's Y
            Vector3 myLookVec = TargetObject.transform.position;    
            myLookVec.y = transform.position.y;
            transform.LookAt(myLookVec);

            // set forward/backward movement based on input
            moveVector = new Vector3(0, 0, moveSpeed * Time.deltaTime);
            // adjust the Y movement based on gravity
            moveVector.y = Physics.gravity.y * Time.deltaTime;
            // move forward or backward based on rotation direction, up or down with gravity
            moveVector = transform.rotation * moveVector; // multiply by rotation

            // move in the forward facing direction (already rotated toward player), by moveSpeed
            EnemyController.Move(moveVector);   
        }
    }

    private void OnDestroy()
    {
        score.currentEnemies--;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Player") && bAlive)
        {
            hit.gameObject.GetComponent<Player>().moveSpeed = 0.0f; // stop the player from moving
            stopThis.GetComponent<Shoot>().enabled = false; //disable the check box for the Shoot.cs with the choosen GameObject
            bAlive = false;
        
            destroySound.Play();

            Invoke("Reload", 2.25f); // wait 1/4 seconds, then reload level
        }
    }

    void Reload()
    {
        stopThis.GetComponent<Shoot>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
