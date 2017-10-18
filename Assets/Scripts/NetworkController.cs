using UnityEngine;
using System.Collections;
using SocketIO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class NetworkController : MonoBehaviour
{

	public static NetworkController instance;
	public SocketIOComponent socket;
	public Player currentPlayer;
	public LobbyController lobCon;
	// Use this for initialization

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
			DontDestroyOnLoad(gameObject);
		}
	}

	void Start()
	{
	}

	public void Connect()
	{
		string ip = PlayerPrefs.GetString("ip");
		Debug.Log("ip " + ip);
		socket.url = "ws://" + ip + ":3000/socket.io/?EIO=4&transport=websocket";
		socket.Awake();
		socket.On("USER_CONNECTED", OnUserConnected);
		socket.On("JOIN_LOBBY", onJoinLobby);
		socket.Connect();
		StartCoroutine(ConnectToServer());
	}

	private void onJoinLobby(SocketIOEvent obj)
	{
		Debug.Log(obj);
		List<string> names = new List<string>();
		for(int i = 0; i < obj.data.Count; i++)
		{
			names.Add(obj.data.GetField("client" + i).ToString());
			names[i] = Regex.Split(names[i], "\"")[1];
		}
		if (lobCon == null)
		{
			lobCon = GameObject.FindObjectOfType<LobbyController>();
		}
		lobCon.onUserConnected(names);
	}

	public void userJoinLobby(Player player)
	{
		Dictionary<string, string> data = new Dictionary<string, string>();
		data.Add("name", player.playerName);
		Debug.Log("JOIN_LOBBY");
		socket.Emit("JOIN_LOBBY", new JSONObject(data));
	}

	void OnUserConnected(SocketIOEvent evt)
	{
		Debug.Log(evt.data.GetField("name").ToString() + " Joined the lobby");
	}

	IEnumerator ConnectToServer()
	{
		yield return new WaitForSeconds(0.5f);
		Dictionary<string, string> data = new Dictionary<string, string>();
		data.Add("name", currentPlayer.playerName);
		socket.Emit("USER_CONNECT",new JSONObject(data));
		Debug.Log("connecting");
	}

	public void UserTouch(string card, bool selected)
	{
		Dictionary<string, string> data = new Dictionary<string, string>();
		data.Add("name", currentPlayer.playerName);
		data.Add("card", card);
		data.Add("selected", selected ? "selected" : "unselected");
		socket.Emit("TOUCH", new JSONObject(data));
	}

	public void OnUserTouch(SocketIOEvent data)
	{
		//Debug.Log()
	}

	// Update is called once per frame
	void Update()
	{

	}
}