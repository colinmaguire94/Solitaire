using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class that is basically a button.
public class ClickEvent : MonoBehaviour {

    //Variable for the deck and gamehandler scripts.
    private Deck deck;
    private GameHandler gh;

    //Boolean to check if the mouse is being used.
    private bool mouseUsed;

	// Use this for initialization
	void Start () {
        //Gives the three variables their values.
        mouseUsed = false;
        deck = GetComponent<Deck>();
        gh = FindObjectOfType<GameHandler>();
	}
	
	// Update is called once per frame
	void Update () {
        //Checks to see if the mouse is pressed.
        if (Input.GetMouseButtonDown(0))
        {
            //Simple if statement, does nothing if the mouse is already used.
            if (mouseUsed)
            {
                //Do nothing.
            }
            else
            {
                mouseUsed = true;
                //Checks to see if the mouse position is in the spot of the gameobject clicked.
                if (!(Input.mousePosition.x >= this.transform.position.x + (79 / 2) || Input.mousePosition.x <= this.transform.position.x - (79 / 2))
                    && !(Input.mousePosition.y >= this.transform.position.y + (100 / 2) || Input.mousePosition.y <= this.transform.position.y - (100 / 2)))
                {
                    //Checks to see if the player is selecting deck..
                    if (this.transform.parent.name == "Deck")
                    {
                        //deck.deckSpot[deck.nextCard].isFlipped = true;
                        //If so checks if the deck is empty or not, if is resets.
                        if (this.transform.name == "Image")
                        {
                            gh.resetDeck();
                        }
                        //Then calls flip card function.
                        gh.flipCard();
                    }
                    //or if they are selecting the playing rows/spot...
                    else if (this.transform.parent.name.Contains("Spot"))
                    {
                        //Checks to see if the selected card is null or not.
                        if (gh.getSelectedCard() == null)
                        {
                            //If is, sets it to this gameobject.
                            gh.setSelectedCard(this.gameObject);
                        }
                        else
                        {
                            //If not checks the card to see if it can play.
                            gh.checkCard(this.gameObject);
                        }
                        //if(this.GetComponent<Card>().CheckCardSuit(this.GetComponent<Card>().cardSuit))
                    }
                    //or if they are selecting a flipped card...
                    else if (this.transform.parent.name == "Flipped Cards")
                    {
                        //Sets selected card to top flipped card.
                        gh.setSelectedCard(this.gameObject);
                    }
                    //Or checks if they are playing a card to the aces.
                    else if (this.transform.parent.name.Contains("Ace"))
                    {
                        //Checks if no cards are present.
                        if(this.transform.name == "Image")
                        {
                            //Checks if it's an ace or not.
                            gh.addAce(this.transform.gameObject);
                        }
                        else
                        {

                        }
                    }
                }
            }
        }
        //Makes the mouse not being used with the button is pressed anymore.
        else if (Input.GetMouseButtonUp(0))
        {
            mouseUsed = false;
        }
    }
}
