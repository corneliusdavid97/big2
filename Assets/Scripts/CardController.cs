using UnityEngine;
using System.Collections;

public class CardController : MonoBehaviour {
	public Card card;
	public Sprite[] faces;
	private Sprite face;
	public Sprite back;
	bool selected;
    Controller controller;
	NetworkController netCon;
	

	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
		netCon = NetworkController.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTouched()
	{
		//Debug.Log(card);
		if (selected == false)
		{
			gameObject.transform.Translate(Vector3.up * 0.5f);
			selected = true;
			controller.onCardSelected(card);
		}
		else
		{
			gameObject.transform.Translate(Vector3.down * 0.5f);
			selected = false;
			controller.onCardUnselected(card);
		}
		Debug.Log(card);
		netCon.UserTouch (card.ToString(), selected);
	}

	public void showFace(bool b,Card c)
	{
		//card suit: 0= diamond, 1= clover, 2= heart, 3=spade
		//card value: 11=jack, 12=queen, 13=king, 14=ace, 15=2
		if (faces.Length == 0)
		{
			faces = Resources.LoadAll<Sprite>("Sprites");
		}
		//Debug.Log(card);
		this.card = c;
		//Debug.Log(this.card);
		gameObject.name = card.ToString();
		int idx = card.Value==15?0:card.Value-2;
		idx += (card.Suit * 14);
		face = faces[idx];

		//if (Card.Suit == 2)
		//{
		//	if (Card.Value == 15)
		//	{
		//		face = faces[0];
		//	}
		//	else
		//	{
		//		face = faces[Card.Value - 2];
		//	}
		//}
		//else if (Card.Suit == 0)
		//{
		//	if (Card.Value == 15)
		//	{
		//		face = faces[13];
		//	}
		//	else
		//	{
		//		face = faces[Card.Value + 11];
		//	}
		//}
		//else if (Card.Suit == 1)
		//{
		//	if (Card.Value == 15)
		//	{
		//		face = faces[26];
		//	}
		//	else
		//	{
		//		face = faces[Card.Value + 24];
		//	}
		//}
		//else
		//{
		//	if (Card.Value == 15)
		//	{
		//		face = faces[39];
		//	}
		//	else
		//	{
		//		face = faces[Card.Value + 37];
		//	}
		//}
		if (b) GetComponent<SpriteRenderer>().sprite = face;
		else GetComponent<SpriteRenderer>().sprite = back;
	}
}
