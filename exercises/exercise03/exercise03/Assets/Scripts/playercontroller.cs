using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "Free People from the Democracy!";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
        // Destroy everything that enters the trigger
        void OnTriggerEnter(Collider other)
        {
                if (other.gameObject.CompareTag("Goal"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
            }
        }

    void SetCountText ()
    {
        countText.text = "Democracies Adjusted: " + count.ToString();
        if (count >= 42)
        {
            winText.text = "Is Victory! You Made the Russia Great Again!";
        }

    }
}