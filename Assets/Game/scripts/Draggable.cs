using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool cardOnGame = false;
    //public Transform deckPosition;
    //public Transform dropPosition;
    public Button panelPalavra;

    //public DeckZone dropzone;
    public Transform targetPosition;


    private void OnEnable()
    {
        targetPosition = FindObjectOfType<Dropzone>().gameObject.transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!cardOnGame)
        {
            this.transform.SetParent(this.transform.parent.parent);
        }


    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!cardOnGame)
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(targetPosition);
        panelPalavra.interactable = true;
        cardOnGame = true;
        //if(dropzone.mouseIn)
        //{
        //    this.transform.SetParent(deckPosition);

        //} else
        //{
        //    this.transform.SetParent(dropPosition);
        //    cardOnGame = true;
        //    panelPalavra.interactable = true;

        //}

    }



}
