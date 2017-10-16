using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class Card : IComparable{

	private int suit;//0= diamond, 1= clover, 2= heart, 3=spade
	private int value; //11=jack, 12=queen, 13=king, 14=ace, 15=2

	public int Value
	{
		get
		{
			return value;
		}

		set
		{
			this.value = value;
		}
	}

	public int Suit
	{
		get
		{
			return suit;
		}

		set
		{
			suit = value;
		}
	}


	public Card(int suit,int  value){
		this.Suit = suit;
		this.Value = value;
	}

	public int CompareTo(object obj){
		Card other = obj as Card;
		if(this.Value==other.Value){
			return this.Suit - other.Suit;
		}
		return this.Value - other.Value;
	}

	public override string ToString(){
		string valstr = "";
		if(Value<11){
			valstr = Value+"";
		}else{
			valstr = Value == 11 ? "jack" : Value == 12 ? "queen" : Value == 13 ? "king" : Value == 14 ? "ace" : "2";
		}
		return valstr + " " + (Suit == 0 ? "diamond" : Suit == 1 ? "clover" : Suit == 2 ? "heart" : "spade");
	}
}
