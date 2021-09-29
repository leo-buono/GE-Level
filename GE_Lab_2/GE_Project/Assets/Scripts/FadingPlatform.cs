using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPlatform : MonoBehaviour
{
    public float fadeSpeed = 0.33f;
    bool fading = false;
    float amountFaded = 1f;

    Material mat;
    
    void Start()
    {
        mat = this.GetComponent<Renderer>().material;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(fading)
        {
            Color col = mat.color;
            amountFaded -= fadeSpeed * Time.deltaTime;
            col.a = amountFaded;
            mat.color = col;
            //So it doesn't 
            if(amountFaded <= 0)
            {
                fading = false;
                this.GetComponent<MeshCollider>().enable = false;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            fading = true;
        }
    }
}
