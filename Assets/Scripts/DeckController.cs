using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DeckController : MonoBehaviour {
	Deck deck=new Deck();
	List<Card> cards;
	public GameObject cardPrefab;
	public Deck Deck
	{
		get
		{
			return deck;
		}

		set
		{
			deck = value;
		}
	}

	// Use this for initialization
	void Start () {
		deck = new Deck();
		cards = deck.Cards;
	}

	public void Spread(float y, bool facePosition)
	{
		cards = deck.Cards;
		cards.Sort();
		Debug.Log(cards.Count);
		for (int i = 0; i < cards.Count; i++)
		{
			GameObject card=Instantiate(cardPrefab, new Vector3(countX(cards.Count), y, 0), Quaternion.identity) as GameObject;
			card.transform.Translate(new Vector3(0.4f*i,0,0));
			card.transform.Translate(Vector3.back * i * 0.1f);
			card.GetComponent<CardController>().card= new Card(cards[i].Suit,cards[i].Value);
			card.name = card.GetComponent<CardController>().card.ToString();
			card.GetComponent<CardController>().showFace(facePosition,cards[i]);

		}
	}

	public float countX(int numOfCard)
	{
		float totalCardW = (numOfCard - 1) * 0.4f;
		return totalCardW / -2;
	}

    /**
     * 0= tidak valid
     * 1= single card
     * 2= pair
     * 3= straight
     * 4= flush
     * 5= full house
     * 6= bomb (4 of a kind)
     * 7= straight flush 
     */
    public static int checkTypeOfPacket(List<Card> packet)
	{
		//List<Card> packet = new List<Card>();
		//packet.Add(new Card(0, 3));
		//packet.Add(new Card(0, 4));
		//packet.Add(new Card(0, 5));
		//packet.Add(new Card(0, 6));
		//packet.Add(new Card(0, 8));


		if (packet.Count == 0)
		{
			return 0;
		}
		else if (packet.Count == 1)
		{
			return 1;
		}
		else if (packet.Count == 2 && packet[0].Value == packet[1].Value)
		{
			return 2;
		}
		else if (packet.Count == 5)
		{
			int suitCheck = 1;
			int sortCheck = 1;

			packet.Sort(new ValueComparator());
			int startValue = packet[0].Value;
			int startValue2 = packet[0].Value;
			int aValue = 0;
			int bValue = 0;
			int a = 0;
			int b = 0;
			for (int i = 0; i < packet.Count; i++)
			{
				//Debug.Log(packet[i].ToString());
				if (startValue != packet[i].Value)
				{
					sortCheck = 0;
				}
				if (aValue == packet[i].Value)
				{
					a++;
				}
				else if (bValue == 0)
				{
					b++;
				}
				startValue++;


				if (packet[0].Suit != packet[i].Suit)
				{
					suitCheck = 0;
				}
			}

			if (suitCheck == 1)
			{
				if (sortCheck == 1)
				{
					return 7;
				}
				return 4;
			}
			else if (sortCheck == 1)
			{
				return 3;
			}
			else if ((a == 2 && b == 3) || (b == 2 && a == 3))
			{
				return 5;
			}
			else if ((a == 4 || b == 4))
			{
				return 6;
			}
		}
		return 0;
	}

	// Update is called once per frame
	void Update () {
	
	}

	class ValueComparator : IComparer<Card>
	{
		public int Compare(Card x, Card y)
		{
			return x.Value - y.Value;
		}
	}
}
