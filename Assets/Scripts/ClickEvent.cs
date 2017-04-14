using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour {

    private Deck deck;


    private bool mouseUsed = false;
	// Use this for initialization
	void Start () {
        deck = GetComponent<Deck>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (mouseUsed)
            {
                //Do nothing.
            }
            else
            {
                mouseUsed = true;
                //RaycastHit hit;
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //Debug.LogError(Input.mousePosition);

                //if (Physics.Raycast(Input.mousePosition, transform.forward, out hit))
                //{
                //    Debug.LogError("blah");
                //    if(hit.transform.name == "Deck")
                //    {
                //        Debug.LogError("blah");
                //        //hit.transform.GetComponent<GameTest>().flipCard();
                //    }
                //}
                //GameObject.FindObjectOfType<GameTest>().flipCard();
                if (!(Input.mousePosition.x >= this.transform.position.x + (79 / 2) || Input.mousePosition.x <= this.transform.position.x - (79 / 2))
                    && !(Input.mousePosition.y >= this.transform.position.y + (100 / 2) || Input.mousePosition.y <= this.transform.position.y - (100 / 2)))
                {
                    if (this.transform.parent.name == "Deck")
                    {
                        //deck.deckSpot[deck.nextCard].isFlipped = true;
                        GameObject.FindObjectOfType<GameHandler>().flipCard();
                    }
                    else if (this.transform.parent.name.Contains("Spot"))
                    {
                        if (GameObject.FindObjectOfType<GameHandler>().getSelectedCard() == null)
                        {
                            GameObject.FindObjectOfType<GameHandler>().setSelectedCard(this.GetComponent<Card>());
                        }
                        else
                        {
                            GameObject.FindObjectOfType<GameHandler>().checkCard(this.GetComponent<Card>(), this.transform.parent.name);
                        }
                        //if(this.GetComponent<Card>().CheckCardSuit(this.GetComponent<Card>().cardSuit))
                    }
                    else if (this.transform.parent.name == "Flipped Cards")
                    {
                        GameObject.FindObjectOfType<GameHandler>().setSelectedCard(this.GetComponent<Card>());
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseUsed = false;
        }
    }
}
