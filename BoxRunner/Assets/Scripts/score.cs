
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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
        
        finalScoreText.text = scoreText.text;
        int finalScore = int.Parse(finalScoreText.text);

        SaveObject saveObject = new SaveObject()
        {
            userName = "Kenneth",
            score = finalScore,
        };

        string json = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.dataPath + "/score.txt", json);



    }
}


public class SaveObject
{
    public string userName;
    public int score;
}
