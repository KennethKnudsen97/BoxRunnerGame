using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 50.0f;
    public float sideForce = 200.0f;

    private int timeBefore = 0;

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
            FindObjectOfType<GameManeger>().EndGame();
        }
    }
}
