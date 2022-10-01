
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

        if (int.Parse(finalScoreText.text) > int.Parse(File.ReadAllText(Application.dataPath + "/score.txt")))
        {
            File.WriteAllText(Application.dataPath + "/score.txt", finalScoreText.text);
        }

        highScoreText.text = File.ReadAllText(Application.dataPath + "/score.txt");
        
    }
}
