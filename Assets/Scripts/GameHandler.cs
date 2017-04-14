using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

    public GameObject Deck;
    public GameObject FlippedCards;
    public GameObject[] Aces;
    public GameObject[] Rows;
    public GameObject card;
    public CardSprite cs;
    private Deck deckScript;


    private CardPile[] AcesPile = new CardPile[4];
    private CardPile[] RowsPile = new CardPile[7];
    private CardPile deckPile = new CardPile();
    private CardPile flipedCardsPile = new CardPile();

    public Card selectedCard;
	// Use this for initialization

    void Awake()
    {
        for(int i = 0; i < 7; i++)
        {
            RowsPile[i] = new CardPile();
        }
        for (int i = 0; i < 4; i++)
        {
            AcesPile[i] = new CardPile();
        }
    }

	void Start () {
        GameObject cardGO;
        cardGO = Instantiate(card, Deck.transform.position, Deck.transform.rotation, Deck.transform);
        cardGO.GetComponent<Image>().sprite = cs.cardSprite[52];

        deckScript = GetComponent<Deck>();

        for(int i = 0; i < 52; i++)
        {
            deckPile.addCard(deckScript.deckSpot[i]);
        }

        dealCards();
        //Debug.Log(deckScript.deckSpot[0].cardNum + ", " + deckScript.deckSpot[0].cardSuit);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void flipCard()
    {
        GameObject cardGO;
        cardGO = Instantiate(card, FlippedCards.transform.position, FlippedCards.transform.rotation, FlippedCards.transform);
        cardGO.name = deckPile.getFirstCard().cardSuit + ", " + deckPile.getFirstCard().cardNum;
        cardGO.GetComponent<Image>().sprite = cs.cardSprite[deckPile.getFirstCard().cardIndex];
        flipedCardsPile.addCard(deckPile.getFirstCard());
        cardGO.GetComponent<Card>().setCard(flipedCardsPile.getFirstCard().cardSuit, flipedCardsPile.getFirstCard().cardNum, flipedCardsPile.getFirstCard().cardIndex);
        deckPile.removeCard(deckPile.getFirstCard());        
    }

    public void dealCards()
    {
        for(int i = 0; i < 7; i++)
        {
            for(int x = i; x < 7; x++)
            {
                GameObject cardGO;
                cardGO = Instantiate(card, Rows[x].transform.position, Rows[x].transform.rotation, Rows[x].transform);
                if (x == i)
                    cardGO.GetComponent<Image>().sprite = cs.cardSprite[deckPile.getFirstCard().cardIndex];
                else
                    cardGO.GetComponent<Image>().sprite = cs.cardSprite[52];

                RowsPile[x].addCard(deckPile.getFirstCard());
                cardGO.name = RowsPile[x].getLastCard().cardSuit + ", " + RowsPile[x].getLastCard().cardNum;
                cardGO.GetComponent<Card>().setCard(RowsPile[x].getLastCard().cardSuit, RowsPile[x].getLastCard().cardNum, RowsPile[x].getLastCard().cardIndex);
                RowsPile[x].row = true;
                deckPile.removeCard(deckPile.getFirstCard());
            }
        }

        for(int i = 0; i < 7; i++)
        {
            Debug.Log(i + ", " + RowsPile[i].getCapacity());
        }
    }

    public void checkCard(Card c, string name)
    {
        //Debug.Log(c.CheckCardSuit(selectedCard.cardSuit));
        if(c.CheckCardSuit(selectedCard.cardSuit))
        {
            for(int i = 0; i < 7; i++)
            {
                if(Rows[i].name == name)
                {

                }
            }
        }

        selectedCard = null;
    }

    public void setSelectedCard(Card c)
    {
        selectedCard = c;
    }

    public Card getSelectedCard()
    {
        return selectedCard;
    }
}
