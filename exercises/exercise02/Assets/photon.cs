using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photon : MonoBehaviour
{
    bool GoLuke = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            Rigidbody rbp = gameObject.GetComponent<Rigidbody>();
            rbp.useGravity = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ExhaustTube")
        {
            GoLuke = true;
        }
    }
}

