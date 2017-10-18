using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SocketIO;

public class Controller : MonoBehaviour {

	public DeckController dealer;
	public List<Player> players=new List<Player>();
    public Player currentPlayer;
	public NetworkController networkController;
	public DeckController field;

	// Use this for initialization
	void Start ()
	{
		initPlayer();
		StartGame();
		testField();
	}

	private void initPlayer()
	{
		currentPlayer.playerName = PlayerPrefs.GetString("name");
		players.Add(currentPlayer);
	}

	void StartGame(){
		Debug.Log(dealer.Deck);
		List<Card> cards = dealer.Deck.Cards;
		for (int i = 3; i <= 15; i++) {
			for (int j = 0; j < 4; j++) {
				cards.Add (new Card(j, i));
			}
		}
		cards.Sort ();
		dealer.Deck.shuffleCard();

		for (int i = 0; i < cards.Count; i++)
		{
			players[i % players.Count].deck.Deck.Cards.Add(cards[i]);
		}
        players[0].deck.Spread(-3.5f, true) ;
	}

	void testField()
	{
		
		List<Card> tmp=field.Deck.Cards = new List<Card>();
		tmp.Add(new Card(0, 3));
		tmp.Add(new Card(0, 4));
		tmp.Add(new Card(0, 5));
		tmp.Add(new Card(0, 6));
		tmp.Add(new Card(0, 7));

		List<Card> output = new List<Card>();
		output.Add(new Card(1, 3));
		output.Add(new Card(1, 4));
		output.Add(new Card(1, 5));
		output.Add(new Card(1, 6));
		output.Add(new Card(1, 7));

		Debug.Log(Player.isValid(output));
	}
	
	public void onCardSelected(Card card)
	{
		if (currentPlayer.selectedCard == null)
		{
			currentPlayer.selectedCard = new List<Card>();
		}
		currentPlayer.selectedCard.Add(card);
		foreach(Card c in currentPlayer.selectedCard)
		{
			Debug.Log(c);
		}
	}

	public void onCardUnselected(Card card)
	{
		currentPlayer.selectedCard.Remove(card);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
