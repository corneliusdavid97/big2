using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviour {
	
	public NetworkController netCon;
	public List<PlayerLobby> list = new List<PlayerLobby>();
	PlayerLobby curPlayer;
	Player playerTemp;

	// Use this for initialization
	void Start () {
		netCon = GameObject.FindObjectOfType<NetworkController>();
		playerTemp = GameObject.FindObjectOfType<Player>();

		Debug.Log(netCon);
		netCon.Connect();
		
		netCon.currentPlayer = playerTemp;
		netCon.userJoinLobby(playerTemp.GetComponent<Player>());

		List<Player> players = new List<Player>();
		players.Add(playerTemp);

		for (int i = 0; i < players.Count; i++)
		{
			list[i].transform.gameObject.SetActive(true);
			list[i].nameText.text = players[i].playerName;
			if (players[i] != playerTemp)
			{
				list[i].readyBtn.gameObject.SetActive(false);
			}
			else
			{
				list[i].readyBtn.onClick.AddListener(onReadyClicked);
				curPlayer = list[i];
			}
		}

	}

	private void onReadyClicked()
	{
		curPlayer.readyBtn.interactable = false;
	}



	// Update is called once per frame
	void Update () {
		
	}

	public void onUserConnected(List<Player> players)
	{
		for (int i = 0; i < players.Count; i++)
		{
			list[i].transform.gameObject.SetActive(true);
			list[i].nameText.text = players[i].playerName;
			if (players[i] != playerTemp)
			{
				list[i].readyBtn.gameObject.SetActive(false);
			}
			else
			{
				list[i].readyBtn.onClick.AddListener(onReadyClicked);
				curPlayer = list[i];
			}
		}
	}


}
