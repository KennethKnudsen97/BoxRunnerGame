using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject LostGameUI;

    private void Start()
    {
        LostGameUI.SetActive(false);
    }
    public void LostGame()
    {
        LostGameUI.SetActive(true);
        
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;

            //Get score class so we can stop score count and also get the final score
            score scoreClass = FindObjectOfType<score>();
            scoreClass.StopScoreCount();
           

            Debug.Log("Game over!");
            Invoke("LostGame", 5f);
        }
    }

    public void Restart()
    {
        LostGameUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("QUIT! Thanks for playing");
        Application.Quit();
    }
    
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
