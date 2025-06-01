using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.WSA;

public class Shoot : MonoBehaviour
{
    public Rigidbody bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Launch();
        }
    }

    // code to emit the projectiles 
    void Launch()
    {
        // launch bullet object from transform.position. offset 1.5f forward, of this script with a velocity of 10
        Vector3 EmitterPos = transform.position + transform.forward * 2f;
        Rigidbody bulletObject = Instantiate(bulletPrefab, EmitterPos, transform.rotation);
        bulletObject.velocity = transform.TransformDirection(Vector3.forward * 10);
    }
}
