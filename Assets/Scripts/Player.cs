using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public List<Card> playerDeck = new List<Card>();
    private int count = 1;

    public void PrintCards()
    {
        for (int i = 0; i < playerDeck.Count; i++)
        {
            Debug.Log("Player has: " + playerDeck[i].Rank + " " + playerDeck[i].Suit + " " + count);
            count++;
        }
    }
}
