using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardMenu : MonoBehaviour
{


    public GameObject highScorePrefab;
    public GameObject highScoreContainer;

    private HighScoreTable highScoreTable;
    private int placeNumber = 0;


    private void Start()
    {
        highScoreTable = new HighScoreTable();
        highScoreTable.LoadTableFromFilePath("/score.txt");

        LoadHighScoreTable();
    }


    private void LoadHighScoreTable()
    {
        
        foreach(HighScoreEntry entry in highScoreTable.entryList)
        {
            DisplayHighScore(entry.userName, entry.score);
        }

    }

    private void DisplayHighScore(string Username, int score)
    {
        GameObject childHighScore = Instantiate(highScorePrefab, highScoreContainer.transform.position, Quaternion.identity);

        childHighScore.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = Username;
        childHighScore.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        placeNumber++;
        childHighScore.transform.GetChild(2).GetComponent<UnityEngine.UI.Text>().text = placeNumber.ToString();
        childHighScore.transform.SetParent(highScoreContainer.transform, false);

    }

    public HighScoreTable GetHighScoreTable()
    {
        return highScoreTable;
    }
}
