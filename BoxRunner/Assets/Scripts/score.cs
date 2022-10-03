
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections;

public class score : MonoBehaviour
{

    public Transform player;

    public Text scoreText;

    public Text finalScoreText;
    public Text highScoreText;

    private bool gameHasEnded;
    private float startPosZ = 0;


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

    public string GetFinalScore()
    {
        return scoreText.text;
    }

    public void StopScoreCount()
    {
        gameHasEnded = true;
        SaveScore();
        DislayScore();

    }

    void SaveScore()
    {
        int newScore = int.Parse(scoreText.text);
        PlayerInfo playerInfo = LoadScore();

        if (newScore > playerInfo.score)
        {

            PlayerInfo newPlayerInfo = new PlayerInfo
            {
                userName = "Kenneth",
                score = newScore,
            };
            string jsonFile = JsonUtility.ToJson(newPlayerInfo);
            File.WriteAllText(Application.dataPath + "/score.txt", jsonFile);

        }
    }

    PlayerInfo LoadScore()
    {
        string loadedTxt = File.ReadAllText(Application.dataPath + "/score.txt");
        PlayerInfo loadedJson = JsonUtility.FromJson<PlayerInfo>(loadedTxt);
        return loadedJson;

    }

    void DislayScore()
    {
        PlayerInfo playerInfo = LoadScore();
        highScoreText.text = playerInfo.score.ToString();
        finalScoreText.text = scoreText.text;
    }
}


public class PlayerInfo : IComparable<PlayerInfo>
{
    public string userName;
    public int score;


    public int CompareTo(PlayerInfo playerInfo)
    {
        return this.score.CompareTo(playerInfo.score);
    }

}


public class Leaderboard {
   

}
