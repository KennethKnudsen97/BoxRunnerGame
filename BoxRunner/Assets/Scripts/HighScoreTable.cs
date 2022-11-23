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

}


[System.Serializable]
public class HighScoreEntry : IComparable<HighScoreEntry>
{
    public string name;
    public int score;

    public HighScoreEntry(string userName, int score)
    {
        this.name = userName;
        this.score = score;
    }

    public int CompareTo(HighScoreEntry highScoreEntry)
    {
        return highScoreEntry.score.CompareTo( this.score);
    }

}