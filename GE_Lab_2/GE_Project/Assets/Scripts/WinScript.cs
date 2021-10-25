using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public GameObject winText;
    public Text textTimer;
    private float startTime;
    private bool theEnd = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (theEnd)
            return;


        float t = Time.time - startTime;

        string min = ((int)t / 60).ToString();
        string sec = (t % 60).ToString("f2");

        textTimer.text = min + ":" + sec;


    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            winText.GetComponent<TextMesh>().text = "You win!!!";
            theEnd = true;
        }
    }
}
