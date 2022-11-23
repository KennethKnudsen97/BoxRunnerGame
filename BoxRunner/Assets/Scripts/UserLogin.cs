using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class UserLogin : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField userNameInput;
    public Button startButton;
    public GameObject playerPreviewCube;
    public GameObject playerPreviewBall;

    public GameObject spawnPoint;
    private GameObject currentPreview;

    public Toggle cubeToggle;
    public Toggle ballToggle;

   
    public ToggleGroup colorToggle;
    public Toggle colorTogglePrefab;
    public GameObject colorToggleContainer;

    private ColorList colorList;

    private PlayerInfo playerInfo;

    private Ref<string> colorListRef;
    private bool hasdisplayed;

    private void Start()
    {
        hasdisplayed = false;
        playerInfo = new PlayerInfo();
        colorList = new ColorList();
        currentPreview = Instantiate(playerPreviewCube, spawnPoint.gameObject.transform.position, spawnPoint.gameObject.transform.rotation);
        
        loadColorFromServer();
    }

    private void DisplayColorList()
    {
        foreach(ColorEntry entry in colorList.colorList)
        {
            Debug.Log("toggle drawed");
            Toggle childToggle = Instantiate(colorTogglePrefab, colorToggleContainer.transform.position, Quaternion.identity);
            childToggle.isOn = false;
            childToggle.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = entry.hexColor;
            
            Color color;
            if (ColorUtility.TryParseHtmlString(entry.hexColor, out color))
            {
                childToggle.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().color = color;
            }
            childToggle.transform.SetParent(colorToggleContainer.transform, false);
            childToggle.group = FindObjectOfType<ToggleGroup>();
        }

        colorToggle.transform.GetChild(0).GetComponent<Toggle>().SetIsOnWithoutNotify(true);

    }


    private void Update()
    {
        

        if (userNameInput.text == "")
        {
            startButton.interactable = false;
        }
        else
        {
            startButton.interactable = true;
        }

        if (ballToggle.isOn && currentPreview.gameObject.tag == "Cube")
        {
            Debug.Log("Changed to Ball");
            Destroy(currentPreview);
            currentPreview = Instantiate(playerPreviewBall, spawnPoint.gameObject.transform.position, spawnPoint.gameObject.transform.rotation);
        }
        if (cubeToggle.isOn && currentPreview.gameObject.tag == "Ball")
        {
            Debug.Log("Changed to Cube");
            Destroy(currentPreview);
            currentPreview = Instantiate(playerPreviewCube, spawnPoint.gameObject.transform.position, spawnPoint.gameObject.transform.rotation);
        }

        //Wait for colorlist has been updated from server 
        if (hasdisplayed)
        {
            currentPreview.GetComponent<Renderer>().material.color = colorToggle.GetFirstActiveToggle().transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().color;

        }
        else
        {
            if (colorList.colorList.Count != 0)
            {
                hasdisplayed = true;
                DisplayColorList();
            }
        }


    }


    public void StartGame()
    {
        SavePlayerInfo();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    private void SavePlayerInfo()
    {
        //Add name
        playerInfo.name = userNameInput.text;


        //Add shape
        if (ballToggle.isOn)
        {
            playerInfo.shape = PlayerShapes.Ball;
        }else if (cubeToggle.isOn)
        {
            playerInfo.shape = PlayerShapes.Cube;
        }

        //Add color
        Color tempColor = currentPreview.GetComponent<Renderer>().material.color;
        playerInfo.color = "#" + ColorUtility.ToHtmlStringRGBA(tempColor);
        FileManager<PlayerInfo>.WriteToFile(Application.dataPath + "/playerInfo.txt", playerInfo);
    }

    private async void loadColorFromServer()
    {
        colorListRef = new Ref<string>();
        await ServerCom.LoadColorList(colorListRef);
        colorList = JsonUtility.FromJson<ColorList>(colorListRef.Value);
    }
}
