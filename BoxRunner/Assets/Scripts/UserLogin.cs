using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserLogin : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField userNameInput;
    public Button startButton;


    private void Update()
    {
        if (userNameInput.text == "")
        {
            startButton.interactable = false;
        }
        else
        {
            startButton.interactable = true;
        }


    }


    public void StartGame()
    {
        
        string userName = userNameInput.text;

        PlayerPrefs.SetString("player", userName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
