using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonosingletonGeneric<GameManager>
{
    public CardDeck CompleteDeck;

    public List<Player> players;
    public List<Button> buttons;

    public int PlayerTurn = 0;

    //For storing returned cards.
    public List<Card> comparisionCards = new List<Card>();

    void Start()
    {
        // Give cards to players.
        buttons[1].onClick.AddListener(GiveCards);

        buttons[2].gameObject.SetActive(false);
        buttons[3].gameObject.SetActive(false);

    }

    void Update()
    {
        GameBegin();

        //Debug.Log("Count: " + comparisionCards.Count);
    }


    private void GiveCards()
    {
        for (int i = 0; i < 26; i++)
        {
            players[0].playerDeck.Enqueue(CompleteDeck.cards[i]);
        }

        for (int i = 26; i < CompleteDeck.cards.Length; i++)
        {
            players[1].playerDeck.Enqueue(CompleteDeck.cards[i]);
        }

        players[0].InstantiatePlayerDeck();
        players[1].InstantiatePlayerDeck();

        //Deactivate original deck of cards.
        CompleteDeck.gameObject.SetActive(false);

    }


    private void GameBegin()
    {
        //Debug.Log("Game Started");
        Debug.Log(comparisionCards.Count);

        //While queue is not empty.
        if (players[PlayerTurn].playerDeck.Count != 0)
        {
            //For turn based
            SwitchSide();

            ShuffleUIOff();

            //Comparision check
            comparision();
        }
        else
        {
            Debug.Log("Game Over");
        }

    }



    private void ShuffleUIOff()
    {
        for (int i = 0; i < 2; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }


    //Switch Sides.
    private void SwitchSide()
    {
        switch (PlayerTurn)
        {
            case 0:
                //Debug.Log("Draw Card from Player: " + players[PlayerTurn].gameObject.name);

                buttons[3].gameObject.SetActive(false);
                buttons[2].gameObject.SetActive(true);

                break;
            case 1:
                //Debug.Log("Draw Card from Player: " + players[PlayerTurn].gameObject.name);

                buttons[2].gameObject.SetActive(false);
                buttons[3].gameObject.SetActive(true);

                break;
            default:
                break;
        }
    }


    private void comparision()
    {
        // Compare 2 cards which are present in the list.

        // Compare rank.

        //Greater one will win the match.
        if (comparisionCards.Count == 2)
        {
            if (comparisionCards[0].Rank > comparisionCards[1].Rank)
            {
                Debug.Log("Player 1 has won this round");
            }
            else if (comparisionCards[0].Rank < comparisionCards[1].Rank)
            {
                Debug.Log("Player 2 has won this round");
            }
            comparisionCards.Clear();
        }
    }


    public void SetTurn(int x)
    {
        PlayerTurn = x;
    }

}

// Make card deck object which will create deck of 52 objects.

// Run shuffle on card deck (present in card deck class) to shuffle cards
// in above created object.

// Create Player1 and Player2 which will have their own decks using
// Queue data structure.

// While player1.deck or player2.deck is not empty continue with 2 things.

// Call return method from each player1 and player2 objects which return a card.

// Comparision will be done between 2 returned cards.

// The winner will enqueue the card of looser in its queue, and loooser will run dequeue.