using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public new string name;
	public int id;
	public DeckController deck;
    public List<Card> selectedCard = new List<Card>();

	public Player(string name,int id){
		this.name = name;
		this.id = id;
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

    public bool isValid(List<Card> output)
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

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input)
	}

}
