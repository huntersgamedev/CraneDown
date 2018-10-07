using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFlap : MonoBehaviour {

    Vector3 ClickPos;
    public float MoveSensitivity;
    public float MoveRate;
    //door
    private bool Closed = false;
    private bool BeingInteracted = false;
    public float doorMoveRate;
    private float OpenLocation = 186;
    public float CloseLocation = 355f;
    public float laserOffLocation = 300;
    public GameObject Laser;

    // Use this for initialization
    void Start () {
       
        gameObject.layer = 9;
    }
	
	// Update is called once per frame
	void Update () {
        MoveBackToOrigin();
        LaserChecker();
	}


    private void OnMouseDown()
    {
        print("clicking");
        ClickPos = Input.mousePosition;
        BeingInteracted = true;
    }
    private void OnMouseUp()
    {
        BeingInteracted = false;
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

        if (dragY > MoveSensitivity&&
            transform.eulerAngles.z < CloseLocation)
        {

            transform.Rotate(new Vector3(0, 0, MoveRate));
            //transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);

            ClickPos = Input.mousePosition;



        }
        else if(transform.eulerAngles.z >= CloseLocation)
        {
            print("closed is true");
            Closed = true;
        }


    }

    void MoveBackToOrigin()
    {
        if(BeingInteracted==false &&
           transform.eulerAngles.z> OpenLocation)
        {
            
            Closed = false;
            transform.Rotate(new Vector3(0, 0, -MoveRate));
        }
    }


    void LaserChecker()
    {
        if (transform.eulerAngles.z > laserOffLocation)
        {
            Laser.gameObject.SetActive(false);
        }

        else
        {
            Laser.gameObject.SetActive(true);
        }
    }

}
