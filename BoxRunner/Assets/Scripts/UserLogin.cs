using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserLogin : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField userNameInput;


    public void StartGame()
    {

        string userName = userNameInput.text;

        PlayerPrefs.SetString("player", userName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
