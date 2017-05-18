using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    //Array of the card class.
    public Card[] deckSpot = new Card[52];
    public int nextCard = 0;
    //Boolean function to check if the cards are loaded.
    public bool loaded;

    //Creates each card when the game starts up.
    void Awake()
    {
        for(int i = 0; i < 52; i++)
        {
            deckSpot[i] = new Card();
        }

        int x = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int y = 0; y < 13; y++)
            {
                deckSpot[x].cardSuit = (Card.Suit)i;
                deckSpot[x].cardNum = (Card.Number)y;
                deckSpot[x].cardIndex = x;
                x++;
            }
        }

        Shuffle();
        loaded = true;
    }

    //A shuffle function to shuffle the deck.
    void Shuffle()
    {
        int f = 4;
        do
        {
            for (int i = 0; i < 52; i++)
            {
                //Random.Range(1, 100), Random.Range(1, 100)
                //A random number generator that is trying to be as different as possible, since random number generators are not as random.
                Random.Range(Random.Range(Random.Range(Random.Range(1, 100), Random.Range(1, 100)), Random.Range(Random.Range(1, 100), Random.Range(1, 100))), 
                    Random.Range(Random.Range(Random.Range(1, 100), Random.Range(1, 100)), Random.Range(Random.Range(1, 100), Random.Range(1, 100))));
                //Picks a random cards.
                int y = Random.Range(0, 51);

                //Creates a temp card to make keep that card.
                Card temp = deckSpot[i];

                //Swaps card at I with Y.
                deckSpot[i] = deckSpot[y];
                //Swaps card at Y with I.
                deckSpot[y] = temp;
            }
            //Does this loop four times, to try and make sure each card is switched multiple times.
            f--;
        } while (f != 0);
    }

    //Gets the index of the next card in the deck.
    public int getNextCardIndex()
    {
        nextCard++;
        return deckSpot[nextCard - 1].cardIndex;
    }

    //Returns the card of the next card in the deck.
    public Card getNextCard()
    {
        nextCard++;
        return deckSpot[nextCard - 1];
    }
}
