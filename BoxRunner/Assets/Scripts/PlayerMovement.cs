using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 50.0f;
    public float sideForce = 200.0f;

    private int timeBefore = 0;


    public AudioClip fallingClip;
    private new AudioSource audio;
    private bool feltOutOfMap;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        feltOutOfMap = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((int)Time.realtimeSinceStartup > timeBefore + 5)
        {
            timeBefore = (int)Time.realtimeSinceStartup;
            Debug.Log("5 seconds has passed");
            speed += 500;
        }
              
        rb.AddForce(0, 0, speed * Time.deltaTime);

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            
        }

        if (rb.position.y < -1f)
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
}
