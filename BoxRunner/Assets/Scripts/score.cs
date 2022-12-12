
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    public Text finalScoreText;

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

    public void StopScoreCount()
    {
        gameHasEnded = true;
      
        SaveScore();
    }

    private async void  SaveScore()
    {
        //Updating score on game over screen
        finalScoreText.text = scoreText.text;

        int newScore = int.Parse(scoreText.text);

        //Getting the username saved in playerPref from UserLogin scene 
        PlayerInfo playerInfo = FileManager<PlayerInfo>.ReadFromFile(Application.dataPath + "/playerinfo.txt");

        HighScoreEntry highscore = new HighScoreEntry(playerInfo.name, newScore);

        await ServerCom.WriteScore(highscore);
    }

}
