using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour{

    public enum Suit { SPADE, HEART, DIAMOND, CLUB, NONE };
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
    }

    public void setCard(Suit s, Number n, int i)
    {
        cardSuit = s;
        cardNum = n;
        cardIndex = i;
    }

    public bool CheckCardSuit(Suit s)
    {
        if (cardSuit == s)
        {
            return true;
        }
        else if (cardSuit == Suit.CLUB && s == Suit.SPADE)
        {
            return true;
        }
        else if (cardSuit == Suit.SPADE && s == Suit.CLUB)
        {
            return true;
        }
        else if (cardSuit == Suit.HEART && s == Suit.DIAMOND)
        {
            return true;
        }
        else if (cardSuit == Suit.DIAMOND && s == Suit.HEART)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
