using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingPlatforms : MonoBehaviour
{
    [SerializeField]
    public float maxDist = 50f;
    public List<FactoryDesign<MonoBehaviour>> factory;
    private Camera cam;
    static public int objectIndex = 0;
    GameObject currentlyHolding;
    Vector3 startPos;
    Vector3 startScale;
    private void Start() 
    {
        cam = Camera.main;
        currentlyHolding = new GameObject();   
    }

    void ScaleFunction(float xScale = 0, float yScale = 0, float zScale = 0)
    {
        //Using Game Object in an effort to do all transforms in one file
        startScale = currentlyHolding.transform.localScale;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentlyHolding.transform.localScale = new Vector3(currentlyHolding.transform.localScale.x + xScale, currentlyHolding.transform.localScale.y + yScale, currentlyHolding.transform.localScale.z + zScale);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentlyHolding.transform.localScale = new Vector3(currentlyHolding.transform.localScale.x - xScale, currentlyHolding.transform.localScale.y - yScale, currentlyHolding.transform.localScale.z - zScale);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKey(KeyCode.Tab) && currentlyHolding != null)
        {
            float moveAmount = 0.5f;
            if(Input.GetKey(KeyCode.Mouse4))
            {
                moveAmount = 0.1f;
            }
            if(Input.GetKey(KeyCode.Alpha3))
            {
               ScaleFunction(moveAmount);
            }
            else if(Input.GetKey(KeyCode.Alpha2))
            {
                ScaleFunction(0, moveAmount);
            }
            else if(Input.GetKey(KeyCode.Alpha1))
            {
                ScaleFunction(0, 0, moveAmount);
            }
            else 
            {
                ScaleFunction(moveAmount, moveAmount, moveAmount);
            }
            startScale = currentlyHolding.transform.localScale;
        }
        else if(Input.GetKeyUp(KeyCode.Tab) && currentlyHolding != null)
        {
            CommandInvoker.AddCommand(new ObjectScale(currentlyHolding.transform.localScale, startScale, currentlyHolding));
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            if (currentlyHolding != null) 
            {
            if(currentlyHolding.name != "StartPoint")
                {
                //Using Game Object in an effort to do all transforms in one file
                startPos = currentlyHolding.transform.position;
                currentlyHolding.transform.position -= new Vector3(0, 0.5f, 0);
                CommandInvoker.AddCommand(new ObjectMovement(currentlyHolding.transform.position, startPos, currentlyHolding, factory[objectIndex]));
                }
            }    
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            if (currentlyHolding != null) 
            {
                if(currentlyHolding.name != "StartPoint")
                {
                //Using Game Object in an effort to do all transforms in one file
                startPos = currentlyHolding.transform.position;
                currentlyHolding.transform.position += new Vector3(0, 0.5f, 0);
                CommandInvoker.AddCommand(new ObjectMovement(currentlyHolding.transform.position, startPos, currentlyHolding, factory[objectIndex]));
                }
            }    
        }
        //MOVEMENT
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //https://answers.unity.com/questions/366157/mouse-click-to-world-space.html
            //create a ray cast and set it to the mouses cursor position in game
             Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
             RaycastHit hit;
            if (Physics.Raycast (ray, out hit, maxDist)) 
            {
                if(hit.transform.gameObject.name != "StartPoint")
                {
                //Using Game Object in an effort to do all transforms in one file
                startPos = hit.transform.position;
                currentlyHolding = hit.transform.gameObject;
                }
            }    
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            //Vector3 mousePos = Input.mousePosition;

             Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
             RaycastHit hit;
             if (Physics.Raycast (ray, out hit, maxDist) && (currentlyHolding != null)) 
             {
                 //Fixed moving towards camera issue
                currentlyHolding.transform.position = new Vector3(hit.point.x, currentlyHolding.transform.position.y, hit.point.z);
             }
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            if(currentlyHolding != null)
            {
                //SET THE UNDO HERE
                CommandInvoker.AddCommand(new ObjectMovement(currentlyHolding.transform.position, startPos, currentlyHolding, factory[objectIndex]));
            }
            else 
            {
                currentlyHolding = null;
            }
        }
        //SPAWNING OBJECT
        if(Input.GetKeyDown(KeyCode.Mouse1))
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
                    CommandInvoker.AddCommand(new InstatiatePlat(factory[objectIndex], hit.point));
             }    
        }
        ItemSelection();
    }
    bool isSelected = false;
    void ItemSelection()
    {
        if(currentlyHolding != null)
        {
            if (currentlyHolding.TryGetComponent(out MeshRenderer mesh))
            {
                Color col = mesh.material.color;
            }
        }
    }
    IEnumerator ItemTimer()
    {
        yield return new WaitForSeconds(1f);
    }
}