using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineWeakPoint : MonoBehaviour {

    public GameObject vineMaster;
    public GameObject PopUp;
  

	// Use this for initialization
	void Start () {
        gameObject.layer = 9;
        PopUp.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnMouseOver()
    {
        PopUp.SetActive(true);
    }

    private void OnMouseExit()
    {
        PopUp.SetActive(false);
    }

    private void OnMouseDown()
    {
        vineMaster.GetComponent<VineMaster>().CheckWeakPoints();
        Destroy(gameObject);

    }
}
