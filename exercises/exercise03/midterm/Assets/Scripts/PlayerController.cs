using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private int keyCount;
    public GameObject PillarofLight;
    public bool polight = false;
    public bool Hunting = false;
    public bool Patroling = true;
    public Text countText;
    public Text winText;
    public Text loseText;

    public bool boost = false;
    public int boostCool = 0;
    public bool frozen = false;
    public int frozenCool = 0;
    public bool invisible = false;
    public int invisibleCool = 0;

    private Rigidbody rb;
    float moveSpeed = 6f;
    float rotateSpeed = 70f;

    float jumpForce = .5f;
    float gravityModifier = 0.1f;
    float yVelocity = 0;
    bool previousIsGroundedValue;

    CharacterController cc;

    void Start()
    { 
       
        rb = GetComponent<Rigidbody>();
        keyCount = 3;
        cc = gameObject.GetComponent<CharacterController>();
        previousIsGroundedValue = cc.isGrounded;
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        SetkeyCountText();
        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0);

        if (!cc.isGrounded)
        {
            yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space) && yVelocity > 0)
            {
                yVelocity = 0;
            }
        }
        else
        {
            if (!previousIsGroundedValue)
            {
                yVelocity = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpForce;
            }
        }
        Vector3 amountToMove = transform.forward * vAxis * moveSpeed * Time.deltaTime;
        amountToMove.y = yVelocity;
        cc.Move(amountToMove);
        previousIsGroundedValue = cc.isGrounded;

        if (boost)
        {
            moveSpeed = 12f;
            boostCool = boostCool - 1;

            if (boostCool == 0)
            {
                boost = false;
                moveSpeed = 6f;
            }

        }
        if (frozen)
        {
            jumpForce = 1.5f;
            frozenCool = frozenCool - 1;
            if (frozenCool == 0)
            {
                frozen = false;
                jumpForce = .5f;
            }
        }
    }
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            keyCount = keyCount - 1;
            SetkeyCountText();
        }
        if (other.gameObject.CompareTag("speedBoost"))
        {
            other.gameObject.SetActive(false);
            boost = true;
            boostCool = 300;
        }
        if (other.gameObject.CompareTag("frozen"))
        {
            other.gameObject.SetActive(false);
            frozen = true;
            frozenCool = 300;
        }
        if (other.gameObject.CompareTag("invisible"))
        {
            other.gameObject.SetActive(false);
            invisible = true;
            invisibleCool = 300;
        }
        if (other.gameObject.CompareTag("POL"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
    void SetkeyCountText()
    {
        if (keyCount <= 0)
        {
            countText.text = "Find the Pillar of Light to Escape!";
            PillarofLight.SetActive(true);
            polight = true;
        }
        else
        {
            countText.text = "Cubes Remaining: " + keyCount.ToString();
        }
    }
}