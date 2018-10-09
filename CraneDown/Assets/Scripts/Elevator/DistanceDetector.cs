using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDetector : MonoBehaviour {
    float ObstacleDistance;
    public float OrangeDistace;
    public float RedDistance;
    private int colorSet;
    public GameObject UI;


    private float MidDist;
    private float LeftDist;
    private float RightDist;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ObstacleFinder();
	}




    void ObstacleFinder()
    {
        Vector3 LeftSensor = new Vector3(transform.position.x - 7.5f, transform.position.y, transform.position.z);
        Vector3 RightSensor = new Vector3(transform.position.x + 7.5f, transform.position.y, transform.position.z);


        RaycastHit hitmid;
        RaycastHit hitLeft;
        RaycastHit hitRight;

       
        if (Physics.Raycast(transform.position, -Vector3.up, out hitmid, 1000, 9))
        {
            MidDist = hitmid.distance;
        }

        if (Physics.Raycast(LeftSensor, -Vector3.up, out hitLeft, 1000, 9))
        {
            LeftDist = hitLeft.distance;
        }

        if (Physics.Raycast(RightSensor, -Vector3.up, out hitRight, 1000, 9))
        {
            RightDist = hitRight.distance;
        }


        //compares all rays distances and gets the closest one

        ObstacleDistance = MidDist;

        if (ObstacleDistance > LeftDist )
        {
            ObstacleDistance = LeftDist;
         
        }

        if (ObstacleDistance > RightDist  )
        {
            ObstacleDistance = RightDist;
            
        }



        //Picks the color of indicator based on how far platform is from obstacle
        if (ObstacleDistance > OrangeDistace && colorSet != 0)
        {
            UI.GetComponent<PlayerUI>().setColor(0);
            colorSet = 0;
        }


        else if (ObstacleDistance < OrangeDistace && 
                 ObstacleDistance>RedDistance&& 
                 colorSet != 1)

        {
            UI.GetComponent<PlayerUI>().setColor(1);
            colorSet = 1;
        }


        else if (ObstacleDistance < RedDistance &&
                 colorSet != 2)
        {
            UI.GetComponent<PlayerUI>().setColor(2);
            colorSet = 2;


        }
     }
}
