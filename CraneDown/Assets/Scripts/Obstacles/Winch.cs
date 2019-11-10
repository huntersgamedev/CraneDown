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

    public LerpInfo lerpVWinch;
    public LerpInfo lerpVDoor;
    public DragHealth dragValues;



    // Use this for initialization
    void Start ()
    {
        //makes platform ignore this objects collider
        gameObject.layer = 9;
        Arrow.transform.parent = null;
        Arrow.SetActive(false);
        lerpVDoor.StartPoint = Door.transform.position.x;
        
    }
	
	
	// Update is called once per frame
	void Update () {
        if (Door.transform.position.x <= CloseLocation && Closed==false)
        {
            Closed = true;
            Arrow.SetActive(false);
            GetComponent<MeshRenderer>().material = completeColor;
            FindObjectOfType<PlayerUI>().SetScore();
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

    private void OnMouseUp()
    {
        dragValues.currentDragHealth = dragValues.newDragHealth;
        dragValues.dragValue = 0;
    }



    void DragControls()
    {
        //gets the mouse's  position x drag length
        float rawDragY = Input.mousePosition.y - ClickPos.y;
       
        float dragY=rawDragY;





        //if drag length is mouse is dragged downward enough rotate by the move rate

        if (dragY < -MoveSensitivity)
            {

            //transform.Rotate(new Vector3(0, -MoveRate, 0));
            //Door.transform.position=new Vector3(Door.transform.position.x-doorMoveRate, Door.transform.position.y, Door.transform.position.z);

            dragValues.dragValue += dragY;

            ClickPos = Input.mousePosition;
            turnnWinch(Mathf.Abs(dragValues.dragValue));


            }
   

    }



    void turnnWinch(float dragAmt)
    {
        dragValues.newDragHealth = dragValues.currentDragHealth + dragAmt;


        float DragTotal = dragValues.newDragHealth / dragValues.dragHealth;

        if (DragTotal >= 1 && Closed==false )
        {
            Closed = true;
            Arrow.SetActive(false);
            GetComponent<MeshRenderer>().material = completeColor;
            FindObjectOfType<PlayerUI>().SetScore();

        }

        else if (Closed == false)
        {
            //LERP the block
            lerpDoor(DragTotal);
            //LerpBlock(DragTotal);
        }



    }

    void lerpDoor(float perc)
    {
        transform.Rotate(new Vector3(0, Mathf.Lerp(lerpVWinch.StartPoint,lerpVWinch.endPoint,perc), 0));
        Door.transform.position = new Vector3(Mathf.Lerp(lerpVDoor.StartPoint, lerpVDoor.endPoint, perc), Door.transform.position.y, Door.transform.position.z);
    }

}

