using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteractions : MonoBehaviour {

    Camera Cam;

    
    


    
	// Use this for initialization
	void Start () {
        Cam = GetComponent<Camera>();
       
	}
	
	// Update is called once per frame
	void Update () {
        // MouseRay();

        if (Input.GetButtonDown("Fire1"))
        {
            MouseRay();
        }
	}

  



    public void MouseRay()
    {
        Vector3 CursorOrigin = Cam.ScreenToWorldPoint(Input.mousePosition);
        
        RaycastHit Hit;
        Debug.DrawRay(CursorOrigin, Cam.transform.forward, Color.red);

        GetComponent<LineRenderer>().SetPosition(0, CursorOrigin);
        GetComponent<LineRenderer>().SetPosition(1, new Vector3(CursorOrigin.x,CursorOrigin.y,CursorOrigin.z+100));




        if (Physics.Raycast(CursorOrigin, Cam.transform.forward, out Hit, 100))
        {
            print(Hit.collider.gameObject);
        }






        


    }

 
}
