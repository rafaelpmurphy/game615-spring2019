using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static float  Offense;
    public static float  MaxOffense;
    public static float  MinOffense;
    public static float OffenseRatio;

    public OffenseBar offenseBar;

    public string[] reactions;
    public Color[] colors;


    void Start()
    {

        Offense = 0f;
        MaxOffense = 10f;
        MinOffense = 0f;

        reshuffle(reactions);
        reshuffleColors(colors);
    }

    // Update is called once per frame
    void Update()
    {

        OffenseRatio = Offense / MaxOffense;
        offenseBar.SetSize(OffenseRatio);
    }

    public void reshuffle(string[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            string tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }

    public void reshuffleColors(Color[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            Color tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }
}


