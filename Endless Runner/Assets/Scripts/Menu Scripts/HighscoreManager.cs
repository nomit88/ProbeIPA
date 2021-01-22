using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class HighscoreManager : MonoBehaviour
{
    public TMP_Text highscoreText;
    public TMP_Text newHighscoreText;

    // Start is called before the first frame update

    //PlayerPrefs.DeleteAll(); to delet all PlayerPrefs
    void Start()
    {
       
        if (GetHighscore(PlayerPrefs.GetString("playername")) != 0 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            CheckAndUpdateHighscore(GetHighscore(PlayerPrefs.GetString("playername")));
        }
    }

    public void CheckAndUpdateHighscore(int score)
    {
        string playername = PlayerPrefs.GetString("playername");
        Debug.Log(playername +" Playername");
        Debug.Log(score);
        Debug.Log(GetHighscore(playername));
        if (score > GetHighscore(playername))
        {
        

            AddHighscore(score, playername);

            highscoreText.text = "Highscore: " + score.ToString() + " meters";
            if (newHighscoreText != null)
            {
                newHighscoreText.gameObject.SetActive(true);
            }
        }
        else
        {
            highscoreText.text = "Highscore: " + GetHighscore(playername).ToString() + " meters";
        }
        highscoreText.gameObject.SetActive(true);

    }

    private int GetHighscore(string playername)
    {
        Highscores highscores;
        if (PlayerPrefs.HasKey("highscores"))
        {
            //Load the saved Highscores
            string jsonString = PlayerPrefs.GetString("highscores");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);

            foreach (Highscore highscore in highscores.highscoreList)
            {
                if (highscore.name == playername)
                {
                    return highscore.score;
                }
            }
        }
        return 0;
    }

    public void AddHighscore(int score, string playername)
    {
        //Create Higscore Obj
        Highscore newHighscore = new Highscore { score = score, name = playername };
        Highscores highscores;
        bool highscoreUpdated = false;
        

        if (PlayerPrefs.HasKey("highscores"))
        {
            //Load the saved Highscores
            string jsonString = PlayerPrefs.GetString("highscores");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);

            //Überschreibt den existierenden Higscore des Spielers in der Liste
            foreach (Highscore highscore in highscores.highscoreList)
            {
                if (highscore.name == playername)
                {
                    highscore.score = newHighscore.score;
                    highscoreUpdated = true;
                }
            }
            if (!highscoreUpdated) {
                // Add new Highscore to the list
                highscores.highscoreList.Add(newHighscore);
                highscoreUpdated = true;
            }
        }
        else
        {
            highscores = new Highscores();
            // Add new Highscore to the list
            highscores.highscoreList.Add(newHighscore);
        }

        // Save Updated Highscores list 
        string highscoresListAsJson = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscores", highscoresListAsJson);
        PlayerPrefs.Save();
    }

}
