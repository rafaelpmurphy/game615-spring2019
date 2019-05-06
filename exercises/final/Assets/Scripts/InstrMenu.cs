using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InstrMenu : MonoBehaviour
{
    public Image fadePanelImg;
    public GameObject instText1;
    public GameObject instText2;
    public GameObject instText3;

    // Start is called before the first frame update
    void Start()
    {
        instText2.gameObject.SetActive(false);
        instText3.gameObject.SetActive(false);
        StartCoroutine(fadeIn());
    }

    IEnumerator fadeIn()
    {
        while (fadePanelImg.color.a > 0)
        {
            float newAlpha = fadePanelImg.color.a - 0.5f * Time.deltaTime;
            fadePanelImg.color = new Color(0, 0, 0, newAlpha);
            yield return null;
        }
        fadePanelImg.gameObject.SetActive(false);
        StartCoroutine(Instruct());
    }
    IEnumerator Instruct()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            instText1.gameObject.SetActive(true);
            yield return new WaitForSeconds(9);
            instText1.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            instText2.gameObject.SetActive(true);
            yield return new WaitForSeconds(9);
            instText2.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            instText3.gameObject.SetActive(true);
            yield return new WaitForSeconds(9);
            instText3.gameObject.SetActive(false);
        }
      

    }


}