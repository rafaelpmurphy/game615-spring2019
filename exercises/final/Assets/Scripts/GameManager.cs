using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int Offense;
    public int MaxOffense;
    public int MinOffense;

    void Start()
    {
        Offense = 0;
        MaxOffense = 15;
        MinOffense = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

}


