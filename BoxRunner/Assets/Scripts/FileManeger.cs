using System.IO;
using UnityEngine;

[System.Serializable]
public class FileManager<T>
{
    public static void WriteToFile(string path, T classToBeSaved)
    {
        if (typeof(T).IsSerializable)
        {
            string json = JsonUtility.ToJson(classToBeSaved, true);
            File.WriteAllText(path, json);
        }
        else
        {
            Debug.Log("This class is not Serializable");
        }
        
    }

    public static T ReadFromFile(string path)
    {
        string json = File.ReadAllText(path);

        T tempTable = JsonUtility.FromJson<T>(json);

        return tempTable;
    }

}
