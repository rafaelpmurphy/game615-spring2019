using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubescript : MonoBehaviour

{
    float force = 0;
    Vector3 startPosition;
    Quaternion startRotation;

    bool playerWon = false;

            void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKey(KeyCode.Space)) {
            force = force + 3f;
            }
       
        if (Input.GetKeyUp(KeyCode.Space)) {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * force);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Oh no!!!");       
    }
}
