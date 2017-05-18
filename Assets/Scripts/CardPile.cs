using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile{

    //List of the Card class, to keep track of all the cards in that pile.
    List<Card> cardsInPile = new List<Card>();
    public bool row = false;

    //Adds a card to the list, when given a card.
    public void addCard(Card c)
    {
        cardsInPile.Add(c);
    }

    //Removes a specific card from the list.
    public void removeCard(Card c)
    {
        cardsInPile.Remove(c);
    }

    //Removes the last card.
    public void removeLastCard()
    {
        cardsInPile.RemoveAt(cardsInPile.Count - 1);
    }

    //Gets what the first card is and returns it.
    public Card getFirstCard()
    {
        return cardsInPile[0];
    }

    //Gets the last Card is and returns it.
    public Card getLastCard()
    {
        return cardsInPile[cardsInPile.Count - 1];
    }

    //Gets the card index at i.
    public int getCardIndex(int i)
    {
        return cardsInPile[i].cardIndex;
    }

    //Gets the capacity of the card pile
    public int getCapacity()
    {
        return cardsInPile.Count;
    }

    //Gets the card index of a card sent to this function.
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

    //Removes a card at i.
    public void removeCard(int i)
    {
        cardsInPile.RemoveAt(i);
    }
}
