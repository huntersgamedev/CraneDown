using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineWeakPoint : MonoBehaviour {

    public GameObject vineMaster;
  

	// Use this for initialization
	void Start () {
        gameObject.layer = 9;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        vineMaster.GetComponent<VineMaster>().CheckWeakPoints();
        Destroy(gameObject);

    }
}
