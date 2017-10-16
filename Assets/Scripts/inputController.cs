using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inputController : MonoBehaviour {
    public Button start;
    public InputField nameInput;
    public InputField IPInput;

    // Use this for initialization
    void Start () {
        start.onClick.AddListener(onStartClick);
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void onStartClick() {
        Debug.Log("something kepencet");
        string name = nameInput.text;
        string IP = IPInput.text;
        Debug.Log(name + " " + IP);
        PlayerPrefs.SetString("name", name);
        PlayerPrefs.SetString("ip", IP);
        SceneManager.LoadScene("TestScene");
    }
}
