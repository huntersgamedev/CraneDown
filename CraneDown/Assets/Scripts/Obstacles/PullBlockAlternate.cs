﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBlockAlternate : MonoBehaviour
{
    public float distance = 25;
    Vector3 ClickPos;
    public float MoveSensitivity;
    public float MoveRate;
    public bool left;
    private bool fallen = false;
    public float FallLocation;
    private Rigidbody rb;

    public GameObject Arrow;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (left == false)
        {
            if (transform.position.x > FallLocation && fallen == false)
            {
                rb.isKinematic = false;
                fallen = true;
                Arrow.SetActive(false);
                FindObjectOfType<PlayerUI>().SetScore();

            }
        }

        else
        {
            if (transform.position.x < FallLocation && fallen == false)
            {
                rb.isKinematic = false;
                fallen = true;
                Arrow.SetActive(false);
                FindObjectOfType<PlayerUI>().SetScore();

            }
        }


    }



    private void OnMouseOver()
    {
        Arrow.SetActive(true);
    }

    private void OnMouseExit()
    {
        Arrow.SetActive(false);
    }



    private void OnMouseDown()
    {
        //sets mouse position when you click on an object
        ClickPos = Input.mousePosition;
        //FindObjectOfType<AudioManager>().Play("test");
    }
    private void OnMouseDrag()
    {
        DragControls();

    }


    void DragControls()
    {
        //gets the mouse's  position x drag length
        float rawDragX = Input.mousePosition.x - ClickPos.x;
        float dragX;

        //allows accurate drag amount wether dragging left or right
        if (rawDragX > 0)
        {
            dragX = Mathf.Abs(rawDragX);
        }

        else
        {
            dragX = Mathf.Abs(rawDragX) * -1;
        }
        Debug.Log("The Drag is" + dragX);


        if (left == false)
        {
            //if drag length is greater then move sensitivy move block to the right
            if (dragX > MoveSensitivity)
            {

                transform.position = new Vector3(transform.position.x + MoveRate, transform.position.y, transform.position.z);
                ClickPos = Input.mousePosition;

            }
        }

        else
        {
            //if drag length is less then mouse sensitivys negative value move left
            if (dragX < -MoveSensitivity)
            {
                transform.position = new Vector3(transform.position.x - MoveRate, transform.position.y, transform.position.z);
                ClickPos = Input.mousePosition;
            }

        }








        //checks if left or right mode


    }
}
