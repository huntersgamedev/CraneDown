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


    // Use this for initialization
    void Start ()
    {
        //makes platform ignore this objects collider
        gameObject.layer = 9;
    }
	
	
	// Update is called once per frame
	void Update () {
        if (Door.transform.position.x <= CloseLocation)
        {
            Closed = true;
        }

        
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

        print(dragY);




        //if drag length is mouse is dragged downward enough rotate by the move rate

        if (dragY < -MoveSensitivity)
            {
               
                transform.Rotate(new Vector3(0, -MoveRate, 0));
                Door.transform.position=new Vector3(Door.transform.position.x-doorMoveRate, Door.transform.position.y, Door.transform.position.z);
                
                ClickPos = Input.mousePosition;



            }
   

    }

}

