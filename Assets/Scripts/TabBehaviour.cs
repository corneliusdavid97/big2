﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TabBehaviour : MonoBehaviour {

    private EventSystem eventSystem;
    public GameObject name;
    public GameObject Ip;
    public Button start;
	// Use this for initialization
	void Start () {
        this.eventSystem = EventSystem.current;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab)) {

            if (eventSystem.currentSelectedGameObject == name)
            {
                Ip.GetComponent<InputField>().Select();
            }
            
            
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
<<<<<<< HEAD
			GameObject.FindObjectOfType<inputController>().onStartClick();
=======
            GameObject.FindObjectOfType<inputController>().onStartClick();
>>>>>>> b987df81251c00bb441760a212d0ef18aa7995f7
        }

        
	}
}
