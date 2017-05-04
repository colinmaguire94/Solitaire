using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile{

    List<Card> cardsInPile = new List<Card>();
    public bool row = false;

    public void addCard(Card c)
    {
        cardsInPile.Add(c);
    }

    public void removeCard(Card c)
    {
        cardsInPile.Remove(c);
    }

    public void removeLastCard()
    {
        cardsInPile.RemoveAt(cardsInPile.Count - 1);
    }

    public Card getFirstCard()
    {
        return cardsInPile[0];
    }

    public Card getLastCard()
    {
        return cardsInPile[cardsInPile.Count - 1];
    }

    public int getCardIndex(int i)
    {
        return cardsInPile[i].cardIndex;
    }

    public int getCapacity()
    {
        return cardsInPile.Count;
    }

    
    public int getCardIndex(Card c)
    {
        //Work around, as the function always gave back a 0, now gives back the correct index.
        int x = -1;

        for(int i = 0; i < cardsInPile.Count; i++)
        {
            if (cardsInPile[i].cardIndex == c.cardIndex)
                x = i;
        }

        return x;
    }

    public void removeCard(int i)
    {
        cardsInPile.RemoveAt(i);
    }
}
