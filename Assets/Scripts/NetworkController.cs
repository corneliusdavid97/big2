using UnityEngine;
using System.Collections;
using SocketIO;
using System;
using System.Collections.Generic;

public class NetworkController : MonoBehaviour {

	public static NetworkController instance;
	public SocketIOComponent socket;
	public Player currentPlayer;
	// Use this for initialization

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		} else if (instance != this)
		{
			Destroy(gameObject);
			DontDestroyOnLoad(gameObject);
		}
	}

	void Start () {
		Connect();
	}

	void Connect()
	{
		//Debug.Log("ip: " + PlayerPrefs.GetString("ip"));
		string ip = PlayerPrefs.GetString("ip");
		socket.url = "ws://" + ip + ":3000/socket.io/?EIO=4&transport=websocket";
		socket.Awake();
		StartCoroutine(ConnectToServer());
		socket.On("USER_CONNECTED", OnUserConnected);
	}

	void OnUserConnected(SocketIOEvent evt)
	{
		Debug.Log(evt.data.GetField("name").ToString()+" Joined the lobby");
	}

	IEnumerator ConnectToServer()
	{
		yield return new WaitForSeconds(0.5f);
		socket.Emit("USER_CONNECT");
		Debug.Log("connecting");
	}

	public void UserTouch(string card,bool selected)
	{
		Dictionary<string, string> data = new Dictionary<string, string>();
		data.Add("name",currentPlayer.playerName);
		data.Add("card",card);
		data.Add("selected", selected ? "selected" : "unselected");
		socket.Emit("TOUCH", new JSONObject(data));
	}

	public void OnUserTouch(SocketIOEvent data)
	{
		//Debug.Log()
	}

	// Update is called once per frame
	void Update () {
	
	}
}
