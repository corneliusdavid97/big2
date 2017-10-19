using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public string playerName;
	public int id;
	public bool canPlay;
	public bool pass;
	public bool isReady;
	public DeckController deck;
	public List<Card> selectedCard;

	public Player(string playerName,int id){
		this.playerName = playerName;
		this.id = id;
		canPlay = false;
		pass = false;
		isReady = false;
	}

    public List<Card> SelectedCard
    {
        get
        {
            return selectedCard;
        }

        set
        {
            selectedCard = value;
        }
    }

    public static bool isValid(List<Card> output)
	{
		DeckController field = GameObject.Find("Controller").GetComponent<Controller>().field;
		List<Card> cards = field.Deck.Cards;
		if (cards.Count == output.Count)
		{
			if (DeckController.checkTypeOfPacket(output) != 0)
			{
				output.Sort();
				cards.Sort();
				Card lastOut = output[output.Count - 1];
				Card lastField = cards[cards.Count - 1];
				return lastOut.CompareTo(lastField) > 0;
			}
		}
		return false;
	}

	public void Play()
	{
		List<Card> cards = deck.Deck.Cards;
		List<Card> fieldCards = GameObject.Find("Controller").GetComponent<Controller>().field.Deck.Cards;
		for (int i = 0; i < this.selectedCard.Count; i++)
		{
			cards.Remove(selectedCard[i]);
		}
		//for (int i = 0; i < cards.Count; i++)
		//{
		//	Debug.Log("cards= "+cards[i]);
		//}
		selectedCard.Clear();
	}

	public void DontDestroy()
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	public void Pass()
	{
		canPlay = false;
		pass = true;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input)
	}

}
