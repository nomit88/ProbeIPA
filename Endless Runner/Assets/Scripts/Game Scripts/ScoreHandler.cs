using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class ScoreHandler : MonoBehaviour
{
    public TMP_Text score;
    private int curScore = 0;

    public bool isPlaying;

    void Start()
    {
        score.text = curScore.ToString();
        isPlaying = true;

        StartCoroutine(IncreaseScore());
    }


    IEnumerator IncreaseScore()
    {
        if (isPlaying) { 
            yield return new WaitForSeconds(0.1f);
            curScore += 1;
            score.text = curScore.ToString();
            StartCoroutine(IncreaseScore());
        }

    }

    public int GetGameOverScore() {
        isPlaying = false;
        return curScore;
    }


}
