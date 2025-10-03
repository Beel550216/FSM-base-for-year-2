using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Player/PlayerInfo", order = 1)]
public class PlayerInfo : ScriptableObject
{
    public string playerName;
    public float health;
    public int lives;


}
