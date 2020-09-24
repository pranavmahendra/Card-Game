using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Queue<Card> playerDeck = new Queue<Card>();
    private int count = 1;
    public Card outCard;

    public void PrintCards()
    {
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
            Instantiate(cards.Image, new Vector3(this.transform.position.x + xOffset, this.transform.position.y, this.transform.position.z + zOffset), Quaternion.identity, this.transform);
            xOffset += 0.2f;
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
        Debug.Log("Pulled Card is: " + outCard.Suit + outCard.Rank + " Updated Card Count: " + playerDeck.Count);
        //return OutCard;
    }

}

