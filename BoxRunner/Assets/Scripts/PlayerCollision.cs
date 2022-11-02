using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovementScript;
    public Rigidbody playerRb;

    public float explForce, forceRadius;
    public PhysicMaterial slippery;


    private new AudioSource audio;
    public AudioClip hitSound;

    private void Start()
    {
        //Setting friction so player slides on ground
        slippery.staticFriction = 0.0f;
        slippery.dynamicFriction = 0.0f;

        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "Obstacle")
        {
            audio.clip = hitSound;
            audio.Play();

            //Setting friction so player dosn't slide too far 
            slippery.staticFriction = 0.5f;
            slippery.dynamicFriction = 0.5f;

            //Set player settings so when hitting object look better
            playerRb.freezeRotation = false;
            playerRb.drag = 0;

            //Add explotion for visuals 
            playerRb.AddExplosionForce(explForce, transform.position, forceRadius);
            //playerMovementScript.enabled = false;
            playerMovementScript.DisableMovement();
            FindObjectOfType<GameManeger>().EndGame();
            
        }
    }
}
