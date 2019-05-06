using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int Offense;
    public int MaxOffense;
    public int MinOffense;

    void Start()
    {

    }

    void Update()
    {
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("0"))
        {
            Offense = Offense - 3;
        }
        if (other.gameObject.CompareTag("1"))
        {
            Offense = Offense - 2;
        }
        if (other.gameObject.CompareTag("2"))
        {
            Offense = Offense - 1;
        }
        if (other.gameObject.CompareTag("3"))
        {
            Offense = Offense - 0;
        }
        if (other.gameObject.CompareTag("4"))
        {
            Offense = Offense + 1;
        }
        if (other.gameObject.CompareTag("5"))
        {
            Offense = Offense + 2;
        }
        if (other.gameObject.CompareTag("6"))
        {
            Offense = Offense + 3;
        }
        if (Offense > MaxOffense)
        {
            Offense = MaxOffense;
        }
        if (Offense < MinOffense)
        {
            Offense = MinOffense;
        }
    }
}
