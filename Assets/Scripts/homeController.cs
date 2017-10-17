using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class homeController : MonoBehaviour {

    public Button play;
    public Button exit;
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
        SceneManager.LoadScene("input detail");
    }

   public void exitGame() {
        Application.Quit();
    }
}
