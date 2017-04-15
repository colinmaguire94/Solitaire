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

    public GameObject selectedCard;
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
        cardGO.GetComponent<Card>().setCard(flipedCardsPile.getFirstCard().cardSuit, flipedCardsPile.getFirstCard().cardNum, flipedCardsPile.getFirstCard().cardIndex, Card.placement.FLIPPED);
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
                cardGO.GetComponent<Card>().setCard(RowsPile[x].getLastCard().cardSuit, RowsPile[x].getLastCard().cardNum, RowsPile[x].getLastCard().cardIndex, Card.placement.ROW);
                RowsPile[x].row = true;
                deckPile.removeCard(deckPile.getFirstCard());
            }
        }

        for(int i = 0; i < 7; i++)
        {
            Debug.Log(i + ", " + RowsPile[i].getCapacity());
        }
    }

    public void checkCard(GameObject go)
    {
        //Debug.Log(c.CheckCardSuit(selectedCard.cardSuit));
        if(!go.GetComponent<Card>().CheckCardSuit(selectedCard.GetComponent<Card>().cardSuit))
        {
            for(int i = 0; i < 7; i++)
            {
                if(Rows[i].name == go.transform.parent.name)
                {
                    selectedCard.transform.position = new Vector3(Rows[i].transform.position.x, Rows[i].transform.position.y - 30.0f, Rows[i].transform.position.z);
                    selectedCard.transform.parent = go.transform.parent;
                    RowsPile[i].addCard(flipedCardsPile.getLastCard());
                    flipedCardsPile.removeCard(flipedCardsPile.getLastCard());
                }
            }
        }

        //selectedCard = null;
    }

    public void setSelectedCard(GameObject go)
    {
        selectedCard = go;
    }

    public Card getSelectedCard()
    {
        return selectedCard.GetComponent<Card>();
    }
}
