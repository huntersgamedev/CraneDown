using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineMaster : MonoBehaviour {
    public float WeakPointsLeft;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckWeakPoints()
    {
        WeakPointsLeft--;
        if (WeakPointsLeft <= 0)
        {
            Destroy(gameObject);
        }
    }


}
