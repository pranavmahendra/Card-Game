using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonosingletonGeneric<GameManager>
{
    public CardDeck CompleteDeck;
    public UIManager UI_Manager;
    private bool CardsHanded = false;

    public List<Player> players;

    [HideInInspector]
    public static int PlayerTurn = 0;

    //For storing returned cards.
    public List<Card> comparisionCards = new List<Card>();


    void Start()
    {
        // Give cards to players.
        UI_Manager.buttons[1].onClick.AddListener(GiveCards);

        UI_Manager.DrawButtonsOf();
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

        players[0].InstantiatePlayerDeck(-0.01f);
        players[1].InstantiatePlayerDeck(0.01f);

        //Deactivate original deck of cards.
        CompleteDeck.gameObject.SetActive(false);

        CardsHanded = true;

    }



    private void GameBegin()
    {
        //Debug.Log("Game Started");
        //Debug.Log(comparisionCards.Count);

        //While queue is not empty.
        if (players[PlayerTurn].playerDeck.Count != 0 && CardsHanded)
        {
            //For turn based
            UI_Manager.SwitchSide();
            UI_Manager.ShuffleUIOff();

            CompleteDeck.DeleteDeck();

            //Comparision check
            if (comparisionCards.Count == 2)
            {
                StartCoroutine(Comparision());
            }

        }
        else if(players[PlayerTurn].playerDeck.Count == 0 && CardsHanded)
        {
            Debug.Log("Game Over");
            UI_Manager.GameOverEnable();
        }

    }



    IEnumerator Comparision()
    {
        // Compare 2 cards which are present in the list.
        // Compare rank.
        //Greater one will win the match.
        if (comparisionCards[0].Rank > comparisionCards[1].Rank)
        {
            //Debug.Log("Player 1 has won this round");
            UI_Manager.WinnerLabel("Player 1");
            players[0].playerDeck.Enqueue(comparisionCards[1]);
            players[1].playerDeck.Dequeue();
        }

        else if (comparisionCards[0].Rank < comparisionCards[1].Rank)
        {
            //Debug.Log("Player 2 has won this round");
            UI_Manager.WinnerLabel("Player 2");
            players[1].playerDeck.Enqueue(comparisionCards[0]);
            players[0].playerDeck.Dequeue();
        }

        else if (comparisionCards[0].Rank == comparisionCards[1].Rank)
        {
            // clubs >
            if (comparisionCards[0].Suit > comparisionCards[1].Suit)
            {
                UI_Manager.WinnerLabel("Player 1");
                players[0].playerDeck.Enqueue(comparisionCards[1]);
                players[1].playerDeck.Dequeue();
            }
            else
            {
                UI_Manager.WinnerLabel("Player 2");
                players[1].playerDeck.Enqueue(comparisionCards[0]);
                players[0].playerDeck.Dequeue();
            }
        }
        comparisionCards.Clear();
        yield return new WaitForSeconds(2);
        UI_Manager.WinnerCanvas.gameObject.SetActive(false);
        players[0].DeleteCards();
        players[1].DeleteCards();
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