using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject Player;

    void Start()
    {
        WinScreen.gameObject.SetActive(false);
        LoseScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Offense > GameManager.MaxOffense)
        {
            LoseScreen.gameObject.SetActive(true);
            Player.gameObject.SetActive(false);
        }
        if (GameManager.Offense < GameManager.MinOffense)
        {
            GameManager.Offense = GameManager.MinOffense;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
        if (transform.position.z < 7)
           {
               transform.Translate(0, 0, 1f);
           }
        else if ((transform.position.x == 0) & (transform.position.z == 7))
          {
              transform.Translate(0, 0, 1f);
          }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (transform.position.z > 0)
            {
                transform.Translate(0, 0, -1f);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.position.z < 0)
            {
                transform.Translate(0, 0, 0);
            }
            else if (transform.position.x > 0)
            {
                transform.Translate(-1f, 0, 0);
            }        
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x < 7)
            {
                transform.Translate(1f, 0, 0);
            }
        }

    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("0"))
        {
            //Debug.Log("Object Entered 0");
            GameManager.Offense = GameManager.Offense - 3f;
            Debug.Log(GameManager.Offense);
        }
        else if (other.gameObject.CompareTag("1"))
        {
            //Debug.Log("Object Entered 1");
            GameManager.Offense = GameManager.Offense - 2f;
            Debug.Log(GameManager.Offense);
        }
        else if (other.gameObject.CompareTag("2"))
        {
            //Debug.Log("Object Entered 2");
            GameManager.Offense = GameManager.Offense - 1f;
            Debug.Log(GameManager.Offense);
        }
        else if (other.gameObject.CompareTag("3"))
        {
            //Debug.Log("Object Entered 3");
            GameManager.Offense = GameManager.Offense - 0f;
            Debug.Log(GameManager.Offense);
        }
        else if (other.gameObject.CompareTag("4"))
        {
            //Debug.Log("Object Entered 4");
            GameManager.Offense = GameManager.Offense + 1f;
            Debug.Log(GameManager.Offense);
        }
        else if (other.gameObject.CompareTag("5"))
        {
            //Debug.Log("Object Entered 5");
            GameManager.Offense = GameManager.Offense + 2f;
            Debug.Log(GameManager.Offense);
        }
        else if (other.gameObject.CompareTag("6"))
        {
            //Debug.Log("Object Entered 6");
            GameManager.Offense = GameManager.Offense + 3f;
            Debug.Log(GameManager.Offense);
        }
        else if (other.gameObject.CompareTag("End"))
        {
            WinScreen.gameObject.SetActive(true);
            Player.gameObject.SetActive(false);
        }
    }
}
