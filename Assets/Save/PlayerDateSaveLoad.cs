using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDateSaveLoad : MonoBehaviour
{
    [SerializeField] private EffectFreezing effectFreezing;
    [SerializeField] private PlayerMove playerMove;

    public void SavePlayer()
    {
        BinarySavingSystem.SavePlayer(effectFreezing, playerMove);
    }

    public void LoadPlayer()
    {
        PlayerDate date = BinarySavingSystem.LoadPlayer();

        effectFreezing.freezeLevel = date.warm;

        //Vector3 position;
        //position.x = date.position[0];
        //position.y = date.position[1];
        //position.z = date.position[2];

        //transform.position = position;

        playerMove.transform.position = new Vector3(date.position[0], date.position[1], date.position[2]);
    }
}
