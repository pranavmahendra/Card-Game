using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public Card(CardType suit, int rank)
    {
        this.Suit = suit;
        this.Rank = rank;
    }

    public CardType Suit { get; }
    public int Rank { get; }
}

public enum CardType
{
    Clubs,    //0
    Diamonds, //1
    Hearts,   //2
    Spades    //3

}
