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
