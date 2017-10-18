using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviour
{

	public NetworkController netCon;
	public List<PlayerLobby> list;
	PlayerLobby curPlayer;
	Player playerTemp;

	// Use this for initialization
	void Start()
	{
		netCon = GameObject.FindObjectOfType<NetworkController>();
		playerTemp = GameObject.FindObjectOfType<Player>();

		netCon.currentPlayer = playerTemp;
		Debug.Log(netCon);
		netCon.Connect();
	}

	private void onReadyClicked()
	{
		curPlayer.readyBtn.interactable = false;
	}



	// Update is called once per frame
	void Update()
	{

	}

	public void onUserConnected(List<string> names)
	{
		Debug.Log("test");
		for (int i = 0; i < names.Count; i++)
		{
			list[i].gameObject.SetActive(true);
			list[i].nameText.text = names[i];
			Debug.Log(names[i]);
			if (names[i] != playerTemp.playerName)
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