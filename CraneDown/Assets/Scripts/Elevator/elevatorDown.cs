using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorDown : MonoBehaviour {

    public float PlatFormSpeed;
    public float endPoint;
    



	void Start () {
		
	}
	
	
	void Update () {
        PlatformMovement();
        CollisionSensing();
	}



  


    //moves platform down
    private void PlatformMovement()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - PlatFormSpeed, transform.position.z);
    }

    private void CollisionSensing()
    {
        //Origin of the left and right raycasts
        Vector3 LeftSensor = new Vector3(transform.position.x - 7.5f, transform.position.y, transform.position.z);
        Vector3 RightSensor = new Vector3(transform.position.x + 7.5f, transform.position.y, transform.position.z);

        RaycastHit hit;

        //FOR DEBUG TO SEE RAYS
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * 1000, Color.yellow);
        Debug.DrawRay(LeftSensor, transform.TransformDirection(-Vector3.up) * 1000, Color.yellow);
        Debug.DrawRay(RightSensor, transform.TransformDirection(-Vector3.up) * 1000, Color.yellow);

        //checks if the elevator is hitting and will end the game

        if (Physics.Raycast(transform.position,-Vector3.up, out hit, 1.6f,9)||
            Physics.Raycast(LeftSensor, -Vector3.up, out hit, 1.6f,9)||
            Physics.Raycast(RightSensor, -Vector3.up, out hit, 1.6f,9))
        {
            FindObjectOfType<PlayerUI>().GameOverUI.SetActive(true);
            GetComponent<Rigidbody>().isKinematic = false;
            Time.timeScale = 0f;
           
        }
    }
}
