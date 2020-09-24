using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Queue<Card> playerDeck = new Queue<Card>();
    public Card outCard;
    public TextMeshProUGUI scoreCounter;

    public Transform DeckSpawn;
    public Transform selectedCardSpawn;

    private void Update()
    {
        scoreCounter.text = "Cards: " + playerDeck.Count;
    }

    public void PrintCards()
    {
        int count = 1;   //Keeping track of cards.
        foreach (Card cards in playerDeck)
        {
            Debug.Log("Player has: " + cards.Rank + " " + cards.Suit + " " + count);
            count++;
        }
    }

    public void InstantiatePlayerDeck()
    {
        float xOffset = 0.2f;
        float zOffset = -0.02f;

        foreach (Card cards in playerDeck)
        {
            Instantiate(cards.Image, new Vector3(DeckSpawn.transform.position.x + xOffset, DeckSpawn.transform.position.y, DeckSpawn.transform.position.z + zOffset), Quaternion.identity, DeckSpawn);
            xOffset += 0.3f;
            zOffset -= 0.03f;
        }
    }


    public void AddCard(Card newCard)
    {
        playerDeck.Enqueue(newCard);
    }


    public void PullCard()
    {
        outCard = playerDeck.Dequeue();
        GameManager.Instance.comparisionCards.Add(outCard);

        Instantiate(outCard.Image, selectedCardSpawn.transform.position, Quaternion.Euler(0f,180f,0f), selectedCardSpawn);

        Debug.Log("Pulled Card is: " + outCard.Suit + outCard.Rank + " Updated Card Count: " + playerDeck.Count);
        playerDeck.Enqueue(outCard);
        //return OutCard;
    }

}

