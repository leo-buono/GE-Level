using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dragable : MonoBehaviour   
{
    public GameObject Panel;
    public List<GameObject> placePanels;
    bool isEnable = false;
    public void mouseEnter()
    {
        isEnable = true;
    }
    public void mouseExit()
    {
        isEnable = false;
    }
    void Update() 
    {
        if(isEnable && Input.GetKey(KeyCode.Mouse0))
        {
            Panel.transform.position = Input.mousePosition;
        }
        foreach(GameObject go in placePanels)
        {
            if(rectOverlaps(Panel.GetComponent<RectTransform>(), go.GetComponent<RectTransform>()))
            {
                print("Is it on?");
                if(go.tag == Panel.tag)
                {
                    print("Proof Of concept");
                    //resets
                }
                //Take damage
                else
                {
                    //damidge
                }
            }
        }
    }
    //https://stackoverflow.com/questions/42043017/check-if-ui-elements-recttransform-are-overlapping
    //Thanks stack overflow
    bool rectOverlaps(RectTransform rectTrans2, RectTransform rectTrans1)
    {
        Rect rect1 = new Rect(rectTrans1.localPosition.x, rectTrans1.localPosition.y, rectTrans1.rect.width, rectTrans1.rect.height);
        Rect rect2 = new Rect(rectTrans2.localPosition.x, rectTrans2.localPosition.y, rectTrans2.rect.width, rectTrans2.rect.height);

        return rect1.Overlaps(rect2);
    }
}
