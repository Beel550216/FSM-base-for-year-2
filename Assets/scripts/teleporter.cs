using UnityEngine;

public class teleporter : MonoBehaviour
{
    public Transform teleport;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("COLLIDED");
        player.transform.position = teleport.transform.position;
    }
}
