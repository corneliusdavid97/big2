using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inputController : MonoBehaviour {
    public Button start;
    public InputField nameInput;
    public InputField IPInput;
	public GameObject playerPrefab;

    // Use this for initialization
    void Start () {
        start.onClick.AddListener(onStartClick);
	}
	
	// Update is called once per frame
	void Update () {
       
   

	}

    public void onStartClick() {
        string name = nameInput.text;
        string IP = IPInput.text;
        Debug.Log(name + " " + IP);
        PlayerPrefs.SetString("name", name);
        PlayerPrefs.SetString("ip", IP);
		GameObject player = Instantiate(playerPrefab, new Vector3(), Quaternion.identity);
		player.name = name;
		player.GetComponent<Player>().playerName = name;
		DontDestroyOnLoadManager.DontDestroyOnLoad(player);

		SceneManager.LoadScene("lobby");
	}
}
