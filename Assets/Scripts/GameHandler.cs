using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

    /* To Do
     * Check Ace
     * Check if card in row can be moved.
     * Check victory condition.
     */

    //Public variables for gameobjects.
    public GameObject Deck;
    public GameObject FlippedCards;
    public GameObject[] Aces;
    public GameObject[] Rows;
    public GameObject card;
    //Variables for two scripts.
    public CardSprite cs;
    private Deck deckScript;

    //Vairables for piles.
    private CardPile[] AcesPile = new CardPile[4];
    private CardPile[] RowsPile = new CardPile[7];
    public CardPile deckPile = new CardPile();
    private CardPile flipedCardsPile = new CardPile();

    //Gameobject for the selected card to debug with.
    public GameObject selectedCard;

    //Variable for debugging a bug.
    public int cap;
	// Use this for initialization

    void Awake()
    {
        //Sets the cardpiles class when the game starts.
        for(int i = 0; i < 7; i++)
        {
            RowsPile[i] = new CardPile();
        }
        for (int i = 0; i < 4; i++)
        {
            AcesPile[i] = new CardPile();
        }

        //Sets the selectedcard to null.
        selectedCard = null;
    }

	void Start () {
        //Creates a game objects for the deck upside down. 
        GameObject cardGO;
        cardGO = Instantiate(card, Deck.transform.position, Deck.transform.rotation, Deck.transform);
        cardGO.GetComponent<Image>().sprite = cs.cardSprite[52];

        //Gets the deck script from the deck gameobject.
        deckScript = GetComponent<Deck>();

        //Adds the cards to the deck pile that are in the deck.
        for(int i = 0; i < 52; i++)
        {
            deckPile.addCard(deckScript.deckSpot[i]);
        }

        //Deals the cards.
        dealCards();
        //Debug.Log(deckScript.deckSpot[0].cardNum + ", " + deckScript.deckSpot[0].cardSuit);
    }
	
	// Update is called once per frame
	void Update () {
        //For debugging purposes.
        cap = RowsPile[6].getCapacity();

        //Checks to see if the deckpile is empty, makes the flipped over card disappear if so.
        if(deckPile.getCapacity() == 0)
        {
            for(int i = 0; i < Deck.transform.childCount; i++)
            {
                if(Deck.transform.GetChild(i).name == "Image(Clone)")
                {
                    Deck.transform.GetChild(i).GetComponent<Image>().enabled = false;
                    Deck.transform.GetChild(i).GetComponent<ClickEvent>().enabled = false;
                }
                else if(Deck.transform.GetChild(i).name == "Image")
                {
                    Deck.transform.GetChild(i).GetComponent<ClickEvent>().enabled = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < Deck.transform.childCount; i++)
            {
                if (Deck.transform.GetChild(i).name == "Image")
                {
                    Deck.transform.GetChild(i).GetComponent<ClickEvent>().enabled = false;
                }
                else if (Deck.transform.GetChild(i).name == "Image(Clone)")
                {
                    Deck.transform.GetChild(i).GetComponent<Image>().enabled = true;
                    Deck.transform.GetChild(i).GetComponent<ClickEvent>().enabled = true;
                }
            }
        }

        //Debugging purposes.
        if(RowsPile[6].getCapacity() > 7)
        {
            Debug.Log("over");
        }
	}

    //Function to flip the card from the deckpile.
    public void flipCard()
    {
        GameObject cardGO;
        cardGO = Instantiate(card, FlippedCards.transform.position, FlippedCards.transform.rotation, FlippedCards.transform);
        cardGO.name = deckPile.getFirstCard().cardSuit + ", " + deckPile.getFirstCard().cardNum;
        cardGO.GetComponent<Image>().sprite = cs.cardSprite[deckPile.getFirstCard().cardIndex];
        flipedCardsPile.addCard(deckPile.getFirstCard());
        cardGO.GetComponent<Card>().setCard(flipedCardsPile.getLastCard().cardSuit, flipedCardsPile.getLastCard().cardNum, flipedCardsPile.getLastCard().cardIndex, Card.placement.FLIPPED);
        deckPile.removeCard(deckPile.getFirstCard());        
    }

    //Resets the deck back to all the cards in the flipped pile.
    public void resetDeck()
    {
        //Reseting the deck with the flipped cards.
        int x = flipedCardsPile.getCapacity();
        for(int i = 0; i < x; i++)
        {
            deckPile.addCard(flipedCardsPile.getFirstCard());
            flipedCardsPile.removeCard(flipedCardsPile.getFirstCard());
        }
        x = FlippedCards.transform.childCount;
        for (int i = 0; i < x; i++)
        {
            if(FlippedCards.transform.GetChild(i).name != "Image")
                Destroy(FlippedCards.transform.GetChild(i).gameObject);
        }
    }

    //Deals the cards out to the rows.
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
    }

    //Checks if a card can be placed in the row, if so, it places it.
    public void checkCard(GameObject go)
    {
        bool canChange = false;
        if (go.GetComponent<Card>().cardPlacement == Card.placement.ROW)
        {
            if (go.GetComponent<Card>().checkRow(selectedCard.GetComponent<Card>()))
            {
                for (int i = 0; i < 7; i++)
                {
                    if (Rows[i].name == go.transform.parent.name)
                    {
                        selectedCard.transform.position = new Vector3(Rows[i].transform.position.x, Rows[i].transform.position.y - 30.0f, Rows[i].transform.position.z);
                        selectedCard.transform.SetParent(go.transform.parent);
                        selectedCard.GetComponent<Card>().cardPlacement = Card.placement.ROW;
                        Card c = flipedCardsPile.getLastCard();
                        RowsPile[i].addCard(c);
                        int x = flipedCardsPile.getCardIndex(c);
                        flipedCardsPile.removeCard(x);
                    }
                }
                canChange = true;
            }
        }
        else if (go.GetComponent<Card>().cardPlacement == Card.placement.ACE)
        {
            if(go.GetComponent<Card>().checkAce(selectedCard.GetComponent<Card>()))
            {
                for (int i = 0; i < 4; i++)
                {
                    if(Rows[i].name == go.transform.parent.name)
                    {

                    }
                }
            }
        }

        //if(!canChange)
        //{
        //    selectedCard = go;
        //}
        //selectedCard = null;
    }

    public void addAce(GameObject go)
    {
        if (selectedCard.GetComponent<Card>().cardNum == Card.Number.ACE)
        {
            selectedCard.transform.position = new Vector3(Aces[go.GetComponent<AcesScript>().index].transform.position.x, Aces[go.GetComponent<AcesScript>().index].transform.position.y, Aces[go.GetComponent<AcesScript>().index].transform.position.z);
            selectedCard.transform.SetParent(go.transform.parent);
            selectedCard.GetComponent<Card>().cardPlacement = Card.placement.ACE;
            Card c = flipedCardsPile.getLastCard();
            AcesPile[go.GetComponent<AcesScript>().index].addCard(c);
            int x = flipedCardsPile.getCardIndex(c);
            flipedCardsPile.removeCard(x);
        }
    }

    public void setSelectedCard(GameObject go)
    {
        selectedCard = go;
    }

    public GameObject getSelectedCard()
    {
        return selectedCard;
    }
}