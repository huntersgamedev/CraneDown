using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour {

    public Text PlatDistance;
    public GameObject PlatDistUI;
    public Image UIArrow;
    public Sprite[] Arrows;
    public Color green;
    public Color Orange;
    public Color Red;

    //gameoverscreen
    public GameObject GameOverUI;
    public Text ScoreText;

    //Score UI
    public GameObject ScoreUI;
    public int score;
    public Text ScoreDisplay;
    public Image AddOne;

    float addOneTimer = 0;
    const float AddOneVisibleTime = .5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(addOneTimer >= 0)
        {
            addOneTimer -= Time.deltaTime;

            if (addOneTimer <= 0)
            {
                AddOne.GetComponent<Image>().enabled = false;
            }
        }
        
	}

    public void GetPlatformDistance(float distance)
    {
        
        PlatDistUI.SetActive(true);
        PlatDistance.text =Mathf.RoundToInt(distance).ToString();
    }

    public void setColor(int UIColor)
    {
       

        switch (UIColor)
        {
            case 0:
                UIArrow.sprite=Arrows[0];
                PlatDistance.color = green;
                break;

            case 1:
                UIArrow.sprite = Arrows[1];
                PlatDistance.color = Orange;
                break;

            case 2:
                UIArrow.sprite = Arrows[2];
                PlatDistance.color = Red;
                break;
        }
    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }


    public void SetScore()
    {
        Debug.Log("setscore called");
        score++;
        ScoreDisplay.text = score.ToString();
        AddOne.GetComponent<Image>().enabled = true;
        //StartCoroutine(TogglePopUp());
        addOneTimer = AddOneVisibleTime;

    }

    

    public void SetGameOverScreen()
    {
        GameOverUI.SetActive(true);
        ScoreText.text = "Your Score is: " + score ;
    }



}
