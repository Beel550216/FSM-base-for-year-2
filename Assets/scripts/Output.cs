using UnityEngine;

public class Output : MonoBehaviour
{

    public PlayerInfo playerInfo;
    public float playerHealth;

    void Start()
    {
        playerHealth = playerInfo.health;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = playerInfo.health;

        UIscript.ui.DrawText("Player name " + playerInfo.playerName.ToString());
        UIscript.ui.DrawText("Player health " + playerHealth.ToString());
        UIscript.ui.DrawText("Player lives " + playerInfo.lives.ToString());

    }
}
