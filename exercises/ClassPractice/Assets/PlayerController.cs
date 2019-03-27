using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 7f;
    float rotateSpeed = 90f;
    float yVelocity = 0;
    public float jumpForce = 2f;
    CharacterController cc;
    bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        //Rotation
        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0);
        cc.Move(transform.forward * vAxis * moveSpeed * Time.deltaTime);
        //Physics and Movement
        Vector3 amountToMove = transform.forward * vAxis * moveSpeed * Time.deltaTime;
        if (cc.isGrounded || onGround)
        {
            Debug.Log("is grounded");
            yVelocity = 0;
            onGround = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpForce;
            }
        }
        else
        {
            onGround = false; 
            Debug.Log("NOT GROUNDED");
            yVelocity += Physics.gravity.y * Time.deltaTime;
            amountToMove.y += yVelocity;
        }
       
        cc.Move(amountToMove);

    }
}
