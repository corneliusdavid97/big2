using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{

	public NetworkController netCon;
	public List<PlayerLobby> list;
	public Button button0;
	public GameObject playerPrefab;
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
		button0.onClick.AddListener(onClick);
	}


	// Update is called once per frame
	void Update()
	{

	}

	public void onUserConnected(List<string> names)
	{
		for (int i = 0; i < names.Count; i++)
		{
			list[i].gameObject.SetActive(true);
			list[i].nameText.text = names[i];
			Debug.Log(names[i]);
			if (names[i] == playerTemp.playerName)
			{
				curPlayer = list[i];
				//button0.gameObject.SetActive(true);
			}
		}

		if (names.Count == 2)
		{
			for (int i = 0; i < names.Count; i++)
			{
				if (names[i] != playerTemp.playerName)
				{
					GameObject player = Instantiate(playerPrefab, new Vector3(), Quaternion.identity);
					player.name = player.GetComponent<Player>().playerName = names[i];
					DontDestroyOnLoadManager.DontDestroyOnLoad(player);
				}
			}
			Debug.Log("beres");
			StartCoroutine(gameStart());
		}
	}
	public void onClick()
	{
		Debug.Log("clicked");
	}

	public IEnumerator gameStart()
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("playRoom");
	}


}