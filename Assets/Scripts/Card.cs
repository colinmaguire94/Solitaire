using UnityEngine;

public class Card : MonoBehaviour{

    //Enum that keeps track of suits.
    public enum Suit { CLUB, DIAMOND, HEART, SPADE, NONE };
    //Enum that keeps track of the Number/Face of the card.
    public enum Number { ACE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, NONE };
    //Enum that keeps track of the placement of that card.
    public enum placement { DECK, FLIPPED, ACE, ROW, NONE };

    //Public variables for the enums.
    public Suit cardSuit;
    public Number cardNum;
    public placement cardPlacement;
    //The index of card, each card has a unique index.
    public int cardIndex;
    //Boolean for if the card is flipped up or not.
    public bool isFlipped;

    //Instructor of the card
    public Card()
    {
        cardSuit = Suit.NONE;
        cardNum = Number.NONE;
        cardIndex = -1;
        cardPlacement = placement.DECK;
    }

    //Sets the card class with the values sent in.
    public void setCard(Suit s, Number n, int i, placement p)
    {
        cardSuit = s;
        cardNum = n;
        cardIndex = i;
        cardPlacement = p;
    }

    //Function to check if the card can be placed in the row, returns true if possible.
    public bool checkRow(Card c)
    {
        if (cardSuit == c.cardSuit)
        {
            return false;
        }
        else if (cardSuit == Suit.CLUB && c.cardSuit == Suit.SPADE)
        {
            return false;
        }
        else if (cardSuit == Suit.SPADE && c.cardSuit == Suit.CLUB)
        {
            return false;
        }
        else if (cardSuit == Suit.HEART && c.cardSuit == Suit.DIAMOND)
        {
            return false;
        }
        else if (cardSuit == Suit.DIAMOND && c.cardSuit == Suit.HEART)
        {
            return false;
        }
        else
        {
            if ((int)c.cardNum + 1 == (int)cardNum)
                return true;
            else
                return false;
        }
    }

    //Function to check if the card can be placed in the ace, returns true if possible.
    public bool checkAce(Card c)
    {
        if (cardSuit != c.cardSuit)
        {
            return false;
        }
        else
        {
            if ((int)c.cardNum - 1 == (int)cardNum)
                return true;
            else
                return false;
        }
    }
}
