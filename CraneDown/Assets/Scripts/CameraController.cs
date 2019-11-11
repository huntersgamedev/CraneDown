using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    //camera movement stats
    [HideInInspector]
    public float camY;
    public float CamSpeed;
    public float CraneUpLimit=-32f;
    public float CraneDownLimit=-160f;
    
    //gameobjects
    public GameObject platform;
    public GameObject UI;
    //UI
    private float PopupDistance=50f;
    private bool IndicatorOn = false;
    public Vector3 mousePos;

    private float maxXRange=714.54f, minXRange= 620f;
    private float maxYRange=984.38f, minYRange= 110f;
    bool touchingArea = false;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CameraCrane();
        UpdateUI();

        CraneInput();
      
	}



    public void CraneInput()
    {
       
        if (Input.GetMouseButtonDown(0)&&IsInArea())
        {
            Debug.Log("am i firing");
            mousePos = Input.mousePosition;
            touchingArea = true;
        }

        if (touchingArea)
        {
            CameraDrag();
        }



        if (Input.GetMouseButtonUp(0))
        {
            camY = 0f;
            touchingArea = false;


        }

        
    }
   


    public bool IsInArea()
    {
        bool inZone;

        if(Input.mousePosition.y>minYRange&& Input.mousePosition.y<maxYRange&&
            Input.mousePosition.x>minXRange&& Input.mousePosition.x< maxXRange)
        {
            inZone = true;
        }

        else
        {
            inZone = false;
        }


        return (inZone);

    }
    






    private void CameraDrag()
    {
        float rawDragY = Input.mousePosition.y - mousePos.y;
        float dragY = rawDragY;

        if (dragY > .1)
        {
            camY = 1;
        }
        else if (dragY < -.1)
        {
            camY = -1;
        }
    }

    private void CameraCrane()
    {


        //camY = Input.GetAxis("Vertical");
        //Debug.Log(Input.GetAxis("Vertical"));
        //Checks if you're craneing to high and puts it back in bounds
        float distance = transform.position.y - platform.transform.position.y;
        

        if (distance > CraneUpLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y- .1f , transform.position.z);
        }

        // checks to see if your craneing to low and puts it back in bounds
        else if(distance < CraneDownLimit) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
        }
        
        //Regular translation of the camera "W" to crane up. "S" to crane down
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + camY * CamSpeed * Time.deltaTime, transform.position.z);
        }
        


    }

    private void UpdateUI()
    {
        float platformDistance = Mathf.Abs(platform.transform.position.y - transform.position.y);
        //Debug.Log(platformDistance);


        if (platformDistance > PopupDistance)
        {
            UI.GetComponent<PlayerUI>().GetPlatformDistance(platformDistance);
            IndicatorOn = true;
        }

        else if (platformDistance < PopupDistance&& IndicatorOn==true)
        {
            print("trun offpopup");
            UI.GetComponent<PlayerUI>().PlatDistUI.SetActive(false);
            IndicatorOn = false;
        }
    }
}
