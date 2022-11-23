using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject player;
    public float speed = 50.0f;
    public float sideForce = 200.0f;

    private int timeBefore = 0;
    private PlayerInfo playerInfo;

    public Mesh ballMesh;
    public Mesh CubeMesh;


    public AudioClip fallingClip;
    private new AudioSource audio;
    private bool feltOutOfMap;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        feltOutOfMap = false;
        UpdatePlayer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((int)Time.realtimeSinceStartup > timeBefore + 5)
        {
            timeBefore = (int)Time.realtimeSinceStartup;
            speed += 500;
        }
              
        player.GetComponent<Rigidbody>().AddForce(0, 0, speed * Time.deltaTime);

        if (Input.GetKey("a"))
        {
            player.GetComponent<Rigidbody>().AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            
        }

        if (Input.GetKey("d"))
        {
            player.GetComponent<Rigidbody>().AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            
        }

        if (player.GetComponent<Rigidbody>().position.y < -1f)
        {
            if (!feltOutOfMap)
            {
                feltOutOfMap = true;
                audio.clip = fallingClip;
                audio.Play();
            }
            FindObjectOfType<GameManeger>().EndGame();
            
        }
    }


    public void DisableMovement()
    {
        speed = 0;
        sideForce = 0;
    }


    private void UpdatePlayer()
    {
        playerInfo = FileManager<PlayerInfo>.ReadFromFile(Application.dataPath + "/playerinfo.txt");
        player = GameObject.Find("Player");

        Color newCol;
        if (ColorUtility.TryParseHtmlString(playerInfo.color, out newCol))
        {
            Debug.Log("Changed color");
            player.GetComponent<Renderer>().material.color = newCol;
        }
        else
        {
            Debug.Log("fail color");

        }

        if (playerInfo.shape == PlayerShapes.Cube)
        {
            player.GetComponent<MeshFilter>().mesh = CubeMesh;
        }
        else
        {
            player.GetComponent<MeshFilter>().mesh = ballMesh;

        }

    }
}



