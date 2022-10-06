using System;
using System.Collections;
using System.IO;

using System.Collections.Generic;
using UnityEngine;


public class HighScoreTable
{ 
    public List<HighScoreEntry> entryList;
   

    public HighScoreTable()
    {
        entryList = new List<HighScoreEntry>();
    }

    public void AddPlayerToHighScoreTable(string userName, int score)
    {
        entryList.Add(new HighScoreEntry(userName, score));
        entryList.Sort();
    }

    public void LoadTableFromFilePath(string filePath)
    {
        string json = File.ReadAllText(Application.dataPath + filePath);

        HighScoreTable tempTable = JsonUtility.FromJson<HighScoreTable>(json);
        entryList = tempTable.entryList;
        entryList.Sort();
        
    }


}


[System.Serializable]
public class HighScoreEntry : IComparable<HighScoreEntry>
{
    public string userName;
    public int score;

    public HighScoreEntry(string userName, int score)
    {
        this.userName = userName;
        this.score = score;
    }

    public int CompareTo(HighScoreEntry highScoreEntry)
    {
        return highScoreEntry.score.CompareTo( this.score);
    }

}