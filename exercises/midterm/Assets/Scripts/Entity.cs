using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;
    private bool patroling = false;
    private bool rotatingLeft = false;
    private bool rotatingRight = false;
    private bool walking = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (patroling == false)
        {
            StartCoroutine(patrol());
        }
        if (rotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotateSpeed);
        }
        if (rotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotateSpeed);
        }
        if (walking == true)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }

        IEnumerator patrol()
        {
            int rawTime = Random.Range(1, 3);
            int rotateTime = Random.Range(1, 4);
            int rotateDir = Random.Range(1, 4);
            int walkTime = Random.Range(5, 10);
            int walkWait = Random.Range(1, 5);
            yield return new WaitForSeconds(walkWait);
            walking = true;
            yield return new WaitForSeconds(walkTime);
            walking = false;
            yield return new WaitForSeconds(rotateTime);
           
            if (rotateDir == 1) ;
            {
                rotatingLeft = true;
                yield return new WaitForSeconds(rotateTime);
                rotatingRight = false;
            }
            if (rotateDir == 4) ;
            {
                rotatingRight = true;
                yield return new WaitForSeconds(rotateTime);
                rotatingLeft = false;
            }

        }
    }
}


    //patrolCount = patrolCount - 1;
      //  if (int patrolCount = 0)
        //{
          //  float moveHorizontal = Random.Range(-90.0f, 90.0f);
    // float moveVertical = Random.Range(-90.0f, 90.0f);
    // float moveAltitude = Random.Range(-20.0f, 20.0f);
    // Vector3 movement = new Vector3(moveHorizontal, moveAltitude, moveVertical);
    // patrolCount = 600;
       // }
// rb.AddForce(movement* speed);
   // }
    // private void OnTriggerEnter(Collider other)
// {
   // if (other.gameObject.CompareTag("Player"))
    // {
       // other.gameObject.SetActive(false);
    // }
// }