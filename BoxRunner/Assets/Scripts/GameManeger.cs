using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject LostGameUI;

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
            string scoreText = scoreClass.GetFinalScore();

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
    
}
