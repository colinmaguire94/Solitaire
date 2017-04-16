using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour{

    public enum Suit { SPADE, DIAMOND, HEART, CLUB, NONE };
    public enum Number { ACE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, NONE };
    public enum placement { DECK, FLIPPED, ACE, ROW, NONE };

    public Suit cardSuit;
    public Number cardNum;
    public placement cardPlacement;
    public int cardIndex;
    public bool isFlipped;

    public Card()
    {
        cardSuit = Suit.NONE;
        cardNum = Number.NONE;
        cardIndex = -1;
        cardPlacement = placement.DECK;
    }

    public void setCard(Suit s, Number n, int i, placement p)
    {
        cardSuit = s;
        cardNum = n;
        cardIndex = i;
        cardPlacement = p;
    }

    public bool checkRow(Card c)
    {
        if (cardSuit == c.cardSuit)
        {
            return true;
        }
        else if (cardSuit == Suit.CLUB && c.cardSuit == Suit.SPADE)
        {
            return true;
        }
        else if (cardSuit == Suit.SPADE && c.cardSuit == Suit.CLUB)
        {
            return true;
        }
        else if (cardSuit == Suit.HEART && c.cardSuit == Suit.DIAMOND)
        {
            return true;
        }
        else if (cardSuit == Suit.DIAMOND && c.cardSuit == Suit.HEART)
        {
            return true;
        }
        else
        {
            if ((int)c.cardNum + 1 == (int)cardNum)
                return false;
            else
                return true;
        }
    }
}
