using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public Card(CardType suit, int rank, GameObject image)
    {
        this.Suit = suit;
        this.Rank = rank;
        this.Image = image;
    }

    public CardType Suit { get; }
    public int Rank { get; }
    public GameObject Image { get; }

}

public enum CardType
{
    C,    //0
    D, //1
    H,   //2
    S    //3

}
