using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject optionsMenu;
    public GameObject leaderBoardMenu;
    public GameObject userPanel;
    public GameObject menu;


    private void Start()
    {
        leaderBoardMenu.SetActive(false);
        optionsMenu.SetActive(false);
        userPanel.SetActive(false);

        menu.SetActive(true);
    }
    public void ShowOptions()
    {
        optionsMenu.SetActive(true);
        menu.SetActive(false);

    }

    public void ShowUserLoginPage()
    {
        userPanel.SetActive(true);
        menu.SetActive(false);

    }

    public void ShowLeaderBoard()
    {
        menu.SetActive(false);
        leaderBoardMenu.SetActive(true);

    }

    public void Back()
    {
        menu.SetActive(true);
        leaderBoardMenu.SetActive(false);
        optionsMenu.SetActive(false);
        userPanel.SetActive(false);
    }
}
