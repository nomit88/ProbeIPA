using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Highscore
{
    public int score;
    public string name;
}

[System.Serializable]
public class Highscores {
    public List<Highscore> highscoreList;
    public Highscores() {
        highscoreList = new List<Highscore>();
    }
}
