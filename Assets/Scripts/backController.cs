using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backController : MonoBehaviour {

    public Button restart;
    public Button menu;

	// Use this for initialization
	void Start () {
        restart.onClick.AddListener(restartClick);
        menu.onClick.AddListener(menuClick);
	}

    public void restartClick() {
        SceneManager.LoadScene("inputDetail");
    }

    public void menuClick() {
        SceneManager.LoadScene("home");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
