using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck {

	List<Card> cards;

	public Deck()
	{
		this.cards =new List<Card>();
	}

	public List<Card> Cards
	{
		get
		{
			return cards;
		}

		set
		{
			cards = value;
		}
	}

	// Use this for initialization
	void Start () {
		cards = new List<Card> ();
	}

	public void shuffleCard(){
		for (int i = 0; i < Cards.Count; i++) {
			int numberRandom = Random.Range (0, Cards.Count);
			Card temp = Cards [i];
			Cards [i] = Cards [numberRandom];
			Cards [numberRandom] = temp;
		}
	}

	public List<Card> getcards(){
		return Cards;
	}
	// Update is called once per frame
	void Update () {
	}
}
