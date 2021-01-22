using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{

    public GameOverScreen gameOverScreen;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "deadly" || other.gameObject.tag == "fly_deadly") {
            gameOver();
        }
    }

    void gameOver() {
        gameOverScreen.Setup(GameObject.Find("Score").GetComponent<ScoreHandler>().GetGameOverScore());

    }

    
}
