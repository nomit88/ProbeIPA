using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreTable : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Highscore> highscoreList;
    private List<Transform> highscoreTransformList;
    

    private void Awake(){
        entryContainer = GameObject.Find("HighscoresEntrysContainer").transform;
        
        entryTemplate = entryContainer.Find("HighscoresEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey("highscores"))
        {

            string jsonString = PlayerPrefs.GetString("highscores");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            //Sortiert die Liste
            for (int i = 0; i < highscores.highscoreList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreList.Count; j++)
                {
                    if (highscores.highscoreList[j].score > highscores.highscoreList[i].score)
                    {
                        //Tauschen
                        Highscore temp = highscores.highscoreList[i];
                        highscores.highscoreList[i] = highscores.highscoreList[j];
                        highscores.highscoreList[j] = temp;
                    }
                }
            }

            highscoreTransformList = new List<Transform>();
            int anzEntrys = 10;
            if (highscores.highscoreList.Count < anzEntrys) {
                anzEntrys = highscores.highscoreList.Count;
            }
            for (int i = 0; i < anzEntrys; i++)
            {
                CreateHighscoreEntryTransform(highscores.highscoreList[i], entryContainer, highscoreTransformList);
            }
        }
    }

    private void CreateHighscoreEntryTransform(Highscore highscore, Transform container, List<Transform> transformList) {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -50 * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString ;

        switch (rank)
        {
            default:
                rankString = rank + "th"; break;

            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;

        }

        //Debug.Log(entryTransform.Find("PositionText"));
        entryTransform.Find("PositionText").GetComponent<TMP_Text>().text = rankString;
        entryTransform.Find("PlayerNameText").GetComponent<TMP_Text>().text = highscore.name;
        entryTransform.Find("DistanceText").GetComponent<TMP_Text>().text = highscore.score.ToString() +" meters";

        transformList.Add(entryTransform);

    }
}
