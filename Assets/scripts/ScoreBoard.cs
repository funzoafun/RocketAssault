using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreBoard : MonoBehaviour
{

    int score = 0;
    TMP_Text scorePoint;

    private void Start() {
        scorePoint = GetComponent<TMP_Text>();
        scorePoint.text = "Start";
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        scorePoint.text = score.ToString();
    }
}
