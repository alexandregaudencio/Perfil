using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Image barFill;



    [SerializeField] private float scorePoint;
    [SerializeField] private float scorePointMax;

    private float partialScore => scorePoint / scorePointMax;



    void Start()
    {
        UpdateScoreboard();
    }



    void UpdateScoreboard()
    {
        barFill.fillAmount = partialScore;
        scoreText.text = scorePoint.ToString() + " / " + scorePointMax.ToString();
    }

    public void changeScore(int value)
    {

        scorePoint += value;
        UpdateScoreboard();
        
    }


}
