using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Queue<Card> playerDeck = new Queue<Card>();
    private int count = 1;


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

    public void PullCard()
    {
        Card OutCard = playerDeck.Dequeue();
        Debug.Log("Pulled Card is: " + OutCard.Suit + OutCard.Rank + " Updated Card Count: " + playerDeck.Count);
        Destroy(OutCard.Image.gameObject);
        //return OutCard;
    }
}

