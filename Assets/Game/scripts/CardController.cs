using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private TMP_Text cardValueText;
    [SerializeField] private TMP_Text keywordText;
    [SerializeField] private List<TMP_Text> dicasTextListed;
    private int cardValue;

    public Card card;
    private string[] dicasListed;

    //private Transform DropZone;

    public Card Card { get => card; set => card = value; }

    private void Start()
    {
        //Dropzone d = FindObjectOfType<Dropzone>().gameObject.transform;
            

        cardValueText.text = cardValue.ToString();
    }

    public void UpdateCardValuePoints(int value)
    {
        cardValue += value;
        cardValueText.text = cardValue.ToString();
    }

    public void ConfigInfo()    
    {

        cardValue = card.dicas.Count+1;
        UpdateCardValuePoints(0);

        keywordText.text = card.keyWord;


        CriardicasEmbaralhadas();

    }


    private void CriardicasEmbaralhadas()
    {
        List<string> dListed = card.dicas;
        //Debug.Log(dListed[0].ToString());

        foreach(TMP_Text dtext in dicasTextListed)
        {
            int n = Random.Range(0, dListed.Count);
            dtext.text = dListed[n].ToString();
            dListed.RemoveAt(n);
            //dicasTextListed.RemoveAt(n);
            
        }
    }

}
