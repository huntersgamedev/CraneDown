using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Winch : MonoBehaviour {
   //winch
    Vector3 ClickPos;
    public float MoveSensitivity;
    public float MoveRate;
    //door
    private bool Closed = false;
    public float doorMoveRate;
    public float CloseLocation;
    public GameObject Door;
    public GameObject Arrow;
    public Material completeColor;


    // Use this for initialization
    void Start ()
    {
        //makes platform ignore this objects collider
        gameObject.layer = 9;
        Arrow.transform.parent = null;
        Arrow.SetActive(false);
    }
	
	
	// Update is called once per frame
	void Update () {
        if (Door.transform.position.x <= CloseLocation)
        {
            Closed = true;
            Arrow.SetActive(false);
            GetComponent<MeshRenderer>().material = completeColor;
        }

        
    }


    private void OnMouseOver()
    {
        if (Closed == false)
        {
            Arrow.SetActive(true);
        }
        
    }



    private void OnMouseExit()
    {
        Arrow.SetActive(false);
    }

    private void OnMouseDown()
    {
        
        ClickPos = Input.mousePosition;

    }


    private void OnMouseDrag()
    {
        if (Closed == false)
        {
            DragControls();
        }
       
    }


    void DragControls()
    {
        //gets the mouse's  position x drag length
        float dragY = Input.mousePosition.y - ClickPos.y;

     




        //if drag length is mouse is dragged downward enough rotate by the move rate

        if (dragY < -MoveSensitivity)
            {
               
                transform.Rotate(new Vector3(0, -MoveRate, 0));
                Door.transform.position=new Vector3(Door.transform.position.x-doorMoveRate, Door.transform.position.y, Door.transform.position.z);
                
                ClickPos = Input.mousePosition;



            }
   

    }

}

