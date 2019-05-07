using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randcolor : MonoBehaviour
{
    GameManager gm;

    public int type;

    string reaction;
    void Start()
    {
        GameObject gmObj = GameObject.Find("GameManager");
        gm = gmObj.GetComponent<GameManager>();

        Renderer rend = GetComponent<Renderer>();
        //type = Random.Range(0, gm.colors.Length);
        Color randColor = gm.colors[type];
        rend.material.color = randColor;

        reaction = gm.reactions[type];
    }

    void Update()
    {

    }
}