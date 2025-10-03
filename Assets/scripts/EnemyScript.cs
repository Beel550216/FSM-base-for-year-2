using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //public float playerHealth;
    private float bonus = 10f;
    public PlayerInfo playerInfo;

    void Start()
    {
        //playerHealth = playerInfo.health;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("="))                    //+ IS ACTUALLY =
        {
            playerInfo.health = playerInfo.health + bonus;
            print(playerInfo.health);
        }
        if (Input.GetKeyDown("-"))
        {
            playerInfo.health = playerInfo.health - bonus;
            print(playerInfo.health);
        }
    }
}
