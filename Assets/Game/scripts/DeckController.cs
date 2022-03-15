using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckController : MonoBehaviour
{

    [SerializeField] private GameObject cardPrefab;

    [SerializeField] private List<Card> cards;

    private int indexCardRandom => UnityEngine.Random.Range(0, cards.Count);


    private void Start()
    {
        findCadsInResourcesPath();
    }


    private void findCadsInResourcesPath()
    {
        cards.Clear();
        Card[] cardsInPath = Resources.LoadAll<Card>("Cards");
        Debug.Log(cardsInPath.Length);
        foreach (Card card in cardsInPath)
        {
                cards.Add(card);
        }
        StartCoroutine(Decking());

    }


    IEnumerator Decking()
    {

        while (cards.Count > 0)
        {
            int n = indexCardRandom;
            //Debug.Log(n);

            yield return new WaitForSeconds(0.1f);
            DrawCard(cards[n]);
            //Debug.Log(cards[n]);
            cards.RemoveAt(n);
        }


    }

    private void DrawCard(Card c)
    {
     GameObject newCard =   Instantiate(cardPrefab);
        newCard.transform.SetParent(this.gameObject.transform);
        CardController newCardValue = newCard.GetComponent<CardController>();

        newCardValue.Card = c;
        newCardValue.ConfigInfo();
    }
    




}
