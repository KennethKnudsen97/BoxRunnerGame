using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject optionsMenu;
    public GameObject leaderBoardMenu;
    public GameObject menu;


    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }   

    public void ShowOptions()
    {
        optionsMenu.SetActive(true);
        menu.SetActive(false);

    }

    public void ShowLeaderBoard()
    {
        menu.SetActive(false);
        leaderBoardMenu.SetActive(true);

    }

    public void Back()
    {
        gameObject.SetActive(true);
        leaderBoardMenu.SetActive(false);
        optionsMenu.SetActive(false);

    }
}
