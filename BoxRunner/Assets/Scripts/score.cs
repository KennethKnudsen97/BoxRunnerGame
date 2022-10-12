
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class score : MonoBehaviour
{

    public Transform player;

    public Text scoreText;

    public Text finalScoreText;

    private HighScoreTable highScoreTable;

    private bool gameHasEnded;
    private float startPosZ = 0;
    private const int MAXNUMBEROFENTYES = 20;

    // Start is called before the first frame update
    void Start()
    {
        highScoreTable = new HighScoreTable();

        gameHasEnded = false;
        startPosZ = player.position.z;
    }

    // Update is called once per frame  
    void Update()
    {
        if (!gameHasEnded)
        {   
            scoreText.text = (player.position.z - startPosZ).ToString("0");
        }
    }

    public void DisplayScore()
    {
        //scoreText.text;
    }

    public void StopScoreCount()
    {
        gameHasEnded = true;
      
        SaveScore();
    }

    void SaveScore()
    {
        //Updating score on game over screen
        finalScoreText.text = scoreText.text;

        int newScore = int.Parse(scoreText.text);

        //Getting the username saved in playerPref from UserLogin scene 
        string playerUserName = PlayerPrefs.GetString("player");

        //HighscoreTable class has a function that load a score text file and update the entry list. 
        highScoreTable.LoadTableFromFilePath("/score.txt");
        
        if (highScoreTable.entryList.Count < MAXNUMBEROFENTYES)
        {
            //If highscore table is free the we can add the score no matter the score
            highScoreTable.AddPlayerToHighScoreTable(playerUserName, newScore);

            string json = JsonUtility.ToJson(highScoreTable, true);
            File.WriteAllText(Application.dataPath + "/score.txt", json);
        }
        else
        {
            if (highScoreTable.entryList[highScoreTable.entryList.Count - 1].score < newScore)
            {
                highScoreTable.entryList.RemoveAt(highScoreTable.entryList.Count - 1);
                highScoreTable.AddPlayerToHighScoreTable(playerUserName, newScore);

                string json = JsonUtility.ToJson(highScoreTable, true);
                File.WriteAllText(Application.dataPath + "/score.txt", json);

            }
            else
            {
                Debug.Log("Not good enough");
            }
        }
    }



}
