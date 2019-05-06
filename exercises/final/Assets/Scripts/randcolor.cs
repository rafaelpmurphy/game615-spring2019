using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randcolor : MonoBehaviour
{
    public Color[] colors;
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        Color randColor = colors[Random.Range (0,colors.Length)];
        rend.material.color = randColor;
    }

    void Update()
    {

    }
}