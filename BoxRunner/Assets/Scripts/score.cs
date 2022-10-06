
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
    public Text highScoreText;

    private HighScoreTable highScoreTable;

    private bool gameHasEnded;
    private float startPosZ = 0;
    private const int MAXNUMBEROFENTYES = 20;

    // Start is called before the first frame update
    void Start()
    {
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
        int newScore = int.Parse(scoreText.text);
        string playerUserName = PlayerPrefs.GetString("player");

        LoadHighScoreTable("/score.txt");
        
        if (highScoreTable.entryList.Count < MAXNUMBEROFENTYES)
        {
            //No matter the score we can add it
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


    void LoadHighScoreTable(string filePath)
    {
        string json = File.ReadAllText(Application.dataPath + filePath);

        highScoreTable = JsonUtility.FromJson<HighScoreTable>(json);
        highScoreTable.entryList.Sort();

    }

}
