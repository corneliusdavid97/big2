﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class homeController : MonoBehaviour {

    public Button play;
    public Button exit;
    public Button playOnClicked;
	// Use this for initialization

	void Start () {
        play.onClick.AddListener(toDataInput);
        exit.onClick.AddListener(exitGame);
       
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void toDataInput()
    {
        SceneManager.LoadScene("inputDetail");
    }

    void ChangeSprite(GameObject button)
    {
        button.GetComponent<Image>().sprite = Resources.Load("NewImage", typeof(Sprite)) as Sprite;
    }


    public void exitGame() {
        Application.Quit();
    }
}
