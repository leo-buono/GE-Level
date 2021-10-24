using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingPlatforms : MonoBehaviour
{
    [SerializeField]
    public float maxDist = 50f;
    public FactoryDesign<MonoBehaviour> factory;
    private Camera cam;
    public int objectIndex = 0;
    private void Start() 
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Vector3 mousePos = Input.mousePosition;
            //https://answers.unity.com/questions/366157/mouse-click-to-world-space.html
            //create a ray cast and set it to the mouses cursor position in game
             Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
             RaycastHit hit;
             if (Physics.Raycast (ray, out hit, maxDist)) 
             {
                    print(hit.point);   
                    //print(obj.name);
                    //Instantiate object of choice through command undo/redo   
                    CommandInvoker.AddCommand(new InstatiatePlat(factory, hit.point));
             }    
        }
    }
}