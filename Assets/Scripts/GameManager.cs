using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Make card deck object which will create deck of 52 objects.

    // Run shuffle on card deck (present in card deck class) to shuffle cards
    // in above created object.

    // Create Player1 and Player2 which will have their own decks using
    // Queue data structure.

    // While player1.deck or player2.deck is not empty continue with 2 things.

    // Call return method from each player1 and player2 objects which return a card.

    // Comparision will be done between 2 returned cards.

    // The winner will enqueue the card of looser in its queue, and loooser will run dequeue.

    private CardDeck CompleteDeck;
    private Player player1;
    private Player player2;

    void Start()
    {

        CompleteDeck = new CardDeck();

        //Creating objects of players.
        player1 = new Player();
        player2 = new Player();

        //Shuffling Deck
        CompleteDeck.ShuffleDeck(25);

        //CompleteDeck.PrintNewDeck();

        // Give cards to players.
        GiveCards();

        Debug.Log("Player 1 cards");
        player1.PrintCards();

        Debug.Log("Player 2 cards");
        player2.PrintCards();

    }

    void Update()
    {
        
    }


    private void GiveCards()
    {
        for (int i = 0; i < 26; i++)
        {
            player1.playerDeck.Add(CompleteDeck.cards[i]);
        }

        for (int i = 26; i < CompleteDeck.cards.Length; i++)
        {
            player2.playerDeck.Add(CompleteDeck.cards[i]);
        }
    }
}
