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
        LoadHighScoreTable();
    }


    private async void LoadHighScoreTable()
    {
        //highScoreTable =  FileManager<HighScoreTable>.ReadFromFile(Application.dataPath + "/score.txt");
        string serverResponse = await ServerCom.LoadScoreBoard();

        HighScoreTable highScoreTable = JsonUtility.FromJson<HighScoreTable>(serverResponse);
        foreach (HighScoreEntry entry in highScoreTable.entryList)
        {
            DisplayHighScore(entry.name, entry.score);
        }

    }

    private void DisplayHighScore(string name, int score)
    {
        GameObject childHighScore = Instantiate(highScorePrefab, highScoreContainer.transform.position, Quaternion.identity);

        childHighScore.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = name;
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
