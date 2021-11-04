using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEditor : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraForEditor;
    public GameObject MouseManager;
    public GameObject Timer;
    public GameObject DropdownMenu;
    bool isPlaying = true;
    // Start is called before the first frame update
    public void changeMode()
    {
        //switch to playing
        if(isPlaying)
        {
            player.SetActive(true);
            cameraForEditor.SetActive(false);
            MouseManager.SetActive(false);
            Timer.SetActive(true);
            DropdownMenu.SetActive(false);
            isPlaying = false;
        }
        //switch to editor
        else 
        {
            cameraForEditor.SetActive(true);
            player.SetActive(false);
            MouseManager.SetActive(true);
            Timer.SetActive(false);
            DropdownMenu.SetActive(true);
            isPlaying = true;
        }
    }
}
