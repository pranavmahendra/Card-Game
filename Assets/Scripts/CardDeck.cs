using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDeck : MonoBehaviour
{
    public Card[] cards;
    public GameObject[] cardModels;
    public Button shuffle;
    private Text shuffleText;
    public Transform mainDeckSpawn;

    //Create a initial deck of 52 cards using this constructor.
    private void Start()
    {
        shuffleText = shuffle.GetComponentInChildren<Text>();

        CreatingInitialDeck();
    }


    private void CreatingInitialDeck()
    {
        int j = 0;
        float xOffset = 0.2f;
        float zOffset = -0.02f;
        cards = new Card[52];

        for (CardType suit = 0; suit <= CardType.S; suit++)
        {
            for (int rank = 1; rank <= 13; rank++)
            {
                cards[j] = new Card(suit, rank, cardModels[j]);

                // Instantiating the 3d models in scene.
                Instantiate(cards[j].Image, new Vector3(mainDeckSpawn.transform.position.x + xOffset,mainDeckSpawn.transform.position.y, mainDeckSpawn.transform.position.z + zOffset), Quaternion.identity, mainDeckSpawn.transform);
                j++;
                //Debug.Log("Card is: " + suit + " " + rank);
                xOffset += 0.2f;
                zOffset -= 0.03f;
            }
        }
    }


    // Method for shuffling card n number of times.
    public void ShuffleDeck(int n)
    {
        int num1;
        int num2;

        shuffleText.text = "Shuffled!!";

        Debug.Log("Shuffling the cards.");
        for (int i = 0; i < n; i++)
        {
            num1 = Random.Range(0, 26);
            num2 = Random.Range(27, 51);

            //Debug.Log(num1 + " " + num2);

            Exchange(num1, num2);
        }

        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].Image.gameObject.transform.position = new Vector3(0, 0, 0);
        }

    }

    // This is called in shuffling.
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

    public void DeleteDeck()
    {
        foreach(Transform card in mainDeckSpawn)
        {
            Destroy(card.gameObject);
        }
    }

}
