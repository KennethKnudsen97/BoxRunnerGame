
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public string name;
    public string color;
    public PlayerShapes shape;

    public PlayerInfo()
    {
        name = "Default";
        shape = PlayerShapes.Ball;
        color = "#43FF00";
    }
}
