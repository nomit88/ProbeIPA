using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
    public TMP_Text scoreText;

    public void Setup(int score) {
        gameObject.SetActive(true);

        scoreText.text = score.ToString() + " meters";
        GetComponent<HighscoreManager>().CheckAndUpdateHighscore(score);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenue()
    {
        SceneManager.LoadScene(0);
    }
}
