using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTest : MonoBehaviour {

    public GameObject[] go;
    public CardSprite cs;
    public GameObject card;
    private Deck deck;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < go.Length; i++)
        {
            GameObject cardGO;
            cardGO = Instantiate(card, go[i].transform.position, go[i].transform.rotation, go[i].transform);
            /*if(go[i].name == "Ace 1")
            //{
            //    cardGO.GetComponent<Image>().sprite = cs.cardSprite[0];
            //}
            //else if (go[i].name == "Ace (2)")
            //{
            //    cardGO.GetComponent<Image>().sprite = cs.cardSprite[13];
            //}
            //else if (go[i].name == "Ace (3)")
            //{
            //    cardGO.GetComponent<Image>().sprite = cs.cardSprite[26];
            //}
            //else if (go[i].name == "Ace (4)")
            //{
            //    cardGO.GetComponent<Image>().sprite = cs.cardSprite[39];
            //}
            //else*/ if(go[i].name == "Deck")
            {
                cardGO.GetComponent<Image>().sprite = cs.cardSprite[52];
                cardGO.AddComponent<ClickEvent>();
            }
            else
            {
                Destroy(cardGO);
            }
        }

        deck = GetComponent<Deck>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void flipCard()
    {
        for(int i = 0; i < go.Length; i++)
        {
            if(go[i].name == "Flipped Cards")
            {
                GameObject cardGO;
                cardGO = Instantiate(card, go[i].transform.position, go[i].transform.rotation, go[i].transform);
                cardGO.GetComponent<Image>().sprite = cs.cardSprite[deck.getNextCardIndex()];
            }
        }
    }
}
