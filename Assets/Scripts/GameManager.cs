using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public CardDeck CompleteDeck;

    public List<Player> players;
    public List<Button> buttons;

    public int PlayerTurn = 0;

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

        CompleteDeck.gameObject.SetActive(false);

    }

    private void GameBegin()
    {
        Debug.Log("Game Started");

        //While queue is not empty.
        if (players[PlayerTurn].playerDeck.Count != 0)
        {
            SwitchSide();

            for (int i = 0; i < 2; i++)
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Game Over");
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


    public void SetTurn(int x)
    {
        PlayerTurn = x;
    }

}
