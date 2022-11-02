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

    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
        menu.SetActive(false);
    }
   
    public void Back(GameObject panel)
    {
        panel.SetActive(false);
        menu.SetActive(true);
        
    }
}
