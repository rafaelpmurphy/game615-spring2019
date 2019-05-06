using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour


{
    public Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent(Renderer)();
        Color randColor = colors[Random.RandomRange(0, colors.Length)];
        rend.material.color = randColor;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
