using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCraneButtons : MonoBehaviour
{
    [SerializeField]
    CameraController CC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void craneUp()
    {
        
        CC.camY = 1.0f;
    }

    public void craneDown()
    {
        CC.camY = -1.0f;
    }

    public void buttonReleased()
    {
        CC.camY = 0f;
    }
}
