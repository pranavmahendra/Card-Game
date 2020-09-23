using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    Card(string suit, int rank)
    {
        this.Suit = suit;
        this.Rank = rank;
    }

    public string Suit { get; }
    public int Rank { get; }
}
