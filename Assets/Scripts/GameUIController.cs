using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

	public Button passButton;
	public Button playButton;
	public Controller controller;
	Player currentPlayer;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindObjectOfType<Controller>();
		currentPlayer = controller.currentPlayer;
		playButton.onClick.AddListener(onPlayBtnClicked);
		passButton.onClick.AddListener(onPassBtnClicked);
	}

	public void onPlayBtnClicked()
	{
		currentPlayer.Play();
		controller.spreadAll();
	}

	public void onPassBtnClicked()
	{
		currentPlayer.Pass();
		controller.spreadAll();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
