using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerDate
{
    public float warm;

    public float[] position;

    public PlayerDate(EffectFreezing freezing, PlayerMove player)
    {
        warm = freezing.freezeLevel;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}