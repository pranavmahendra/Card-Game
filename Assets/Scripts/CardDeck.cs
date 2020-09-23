using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck
{
    public Card[] cards;

    //Create a initial deck of 52 cards using this constructor.

    public CardDeck()
    {
        int j = 0;
        cards = new Card[52];

        for (CardType suit = 0; suit <= CardType.Spades; suit++)
        {
            for (int rank = 1; rank <= 13; rank++)
            {
                cards[j] = new Card(suit, rank);
                j++;
                //Debug.Log("Card is: " + suit + " " + rank);
            }
        }
        //Debug.Log("----END----");
    }


    // Method for shuffling card n number of times.
    public void ShuffleDeck(int n)
    {
        int num1;
        int num2;

        //Debug.Log("Shuffling the cards.");
        for (int i = 0; i < n; i++)
        {
            num1 = Random.Range(0, 26);
            num2 = Random.Range(27, 51);

            //Debug.Log(num1 + " " + num2);

            Exchange(num1, num2);
        }
    }


    private void Exchange(int card1, int card2)
    {
        //Debug.Log("Exchanging Card " + cards[card1].Suit + " " + cards[card1].Rank + " with " + cards[card2].Rank + " " + cards[card2].Suit);

        Card temp = cards[card1];
        cards[card1] = cards[card2];
        cards[card2] = temp;
    }


    public void PrintNewDeck()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            Debug.Log("Card is: " + cards[i].Suit + " " + cards[i].Rank);
        }
    }

}
