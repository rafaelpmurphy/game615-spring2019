using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OffenseBar : MonoBehaviour
{
    private Transform bar;

    private void Start()
    {
        bar = transform.Find("Bar");
    }

    // Update is called once per frame
    public void SetSize (float sizeNormalized)
    {
        bar.localScale = new Vector3(1f, sizeNormalized);        
    }
}
