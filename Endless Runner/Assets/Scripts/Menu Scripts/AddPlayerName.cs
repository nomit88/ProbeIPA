using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class AddPlayerName : MonoBehaviour
{
    public TMP_InputField inputNameField;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("playername") && PlayerPrefs.GetString("playername" ) != "")
        {
            SetNameForImputField();
        }
        else if(SceneManager.GetActiveScene().name != "addCharacterNameScene")
        {
            SceneManager.LoadScene("addCharacterNameScene");
        }
    }

    public void SetNameForImputField() {
        inputNameField.text = PlayerPrefs.GetString("playername");
    }

    public void EnterName()
    {
        if (inputNameField.text != null && inputNameField.text != "")
        {
            PlayerPrefs.SetString("playername", inputNameField.text);
            Debug.Log(PlayerPrefs.GetString("playername"));

            if (SceneManager.GetActiveScene().buildIndex != 0) { 
                SceneManager.LoadScene(0);
            }
           
        }
    }

    public void checkNameSet() {
        if (!PlayerPrefs.HasKey("playername")) {
            if (SceneManager.GetActiveScene().name != "addCharacterNameScene")
            {
                SceneManager.LoadScene("addCharacterNameScene");
            }
        }
    }
}
