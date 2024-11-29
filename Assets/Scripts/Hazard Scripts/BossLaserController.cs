using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

public class BossLaserController : MonoBehaviour
{
    public float speed;
    public float minDistance;
    private Transform player;
    private Rigidbody laserRb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        laserRb = GetComponent<Rigidbody>();

        if (player != null)
        {
            // Calculate direction to player.
            Vector3 direction = (player.position - transform.position).normalized;
            
            // Move laser in player's direction.
            laserRb.velocity = direction * speed;
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }
}