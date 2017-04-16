using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public Card[] deckSpot = new Card[52];
    public int nextCard = 0;
    public bool loaded;

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

	// Use this for initialization
	void Start () {
        
        //Debug.Log(deckSpot[0].cardNum + ", " + deckSpot[0].cardSuit);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Shuffle()
    {
        int f = 4;
        do
        {
            for (int i = 0; i < 52; i++)
            {
                //Random.Range(1, 100), Random.Range(1, 100)
                Random.Range(Random.Range(Random.Range(Random.Range(1, 100), Random.Range(1, 100)), Random.Range(Random.Range(1, 100), Random.Range(1, 100))), 
                    Random.Range(Random.Range(Random.Range(1, 100), Random.Range(1, 100)), Random.Range(Random.Range(1, 100), Random.Range(1, 100))));
                int x = Random.Range(0, 51);
                int y = Random.Range(0, 51);

                Card temp = deckSpot[i];

                deckSpot[i] = deckSpot[y];
                deckSpot[y] = temp;
            }
            f--;
        } while (f != 0);

        for(int i = 0; i <51; i++)
        {
            if (i == deckSpot[i].cardIndex)
                Debug.Log(i);
        }
    }

    public int getNextCardIndex()
    {
        nextCard++;
        return deckSpot[nextCard - 1].cardIndex;
    }

    public Card getNextCard()
    {
        nextCard++;
        return deckSpot[nextCard - 1];
    }
}
