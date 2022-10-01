using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovementScript;
    public Rigidbody playerRb;

    public float explForce, forceRadius;
    public PhysicMaterial slippery;

    private void Start()
    {
        slippery.staticFriction = 0.0f;
        slippery.dynamicFriction = 0.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "Obstacle")
        {
            slippery.staticFriction = 0.5f;
            slippery.dynamicFriction = 0.5f;

            playerRb.freezeRotation = false;
            playerRb.drag = 0;
            playerRb.AddExplosionForce(explForce , transform.position, forceRadius);
            playerMovementScript.enabled = false;
            FindObjectOfType<GameManeger>().EndGame();
            
        }
    }
}
