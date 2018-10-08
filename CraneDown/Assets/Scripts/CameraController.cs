using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    //camera movement stats
    private float camY;
    public float CamSpeed;
    public float CraneUpLimit;
    public float CraneDownLimit;
    
    //gameobjects
    public GameObject platform;
    public GameObject UI;
    //UI
    private float PopupDistance=16.2f;
    private bool IndicatorOn = false;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CameraCrane();
        UpdateUI();
      
	}





    private void CameraCrane()
    {


        camY = Input.GetAxis("Vertical");
        //Checks if you're craneing to high and puts it back in bounds
        if (transform.position.y > CraneUpLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y- .1f , transform.position.z);
        }

        // checks to see if your craneing to low and puts it back in bounds
        else if(transform.position.y < CraneDownLimit) 
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
