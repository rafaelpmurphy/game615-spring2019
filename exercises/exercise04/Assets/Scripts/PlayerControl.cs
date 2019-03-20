using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    Vector3 movement;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move (h, v);
    }
    void Move(float h, float v)
    {
        movement.Set (h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition (transform.position + movement);
    }
}

//if (Input.GetKey(KeyCode.W))
        //{
          //  transform.position += Vector3.forward * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
          //  transform.position += Vector3.back * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
          //  transform.position += Vector3.left * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.D)) 
        //{
          //  transform.position += Vector3.right * speed * Time.deltaTime;
        //}