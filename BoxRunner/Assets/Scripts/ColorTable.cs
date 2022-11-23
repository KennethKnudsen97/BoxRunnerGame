using System;
using System.Collections;
using System.IO;

using System.Collections.Generic;
using UnityEngine;


public class ColorList
{
    public List<ColorEntry> colorList;


    public ColorList()
    {
        colorList = new List<ColorEntry>();
    }

    public void AddColorToList(string hexColor)
    {
        ColorEntry entry = new ColorEntry(hexColor);
        colorList.Add(entry);
    }

    public void LoadTableFromFilePath(string filePath)
    {
        string json = File.ReadAllText(Application.dataPath + filePath);
        ColorList tempTable = new ColorList();
        tempTable = JsonUtility.FromJson<ColorList>(json);
        colorList = tempTable.colorList;

    }


}


[System.Serializable]
public class ColorEntry 
{
    public string hexColor;

    public ColorEntry(string hexColor)
    {
        this.hexColor = hexColor;
    }

}