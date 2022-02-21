using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinarySavingSystem 
{
    public static void SavePlayer(EffectFreezing freezing, PlayerMove player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sp";
        FileStream stream = new FileStream(path,FileMode.Create);

        PlayerDate date = new PlayerDate(freezing, player);

        formatter.Serialize(stream, date);
        stream.Close();
    }

    public static PlayerDate LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sp";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerDate date = formatter.Deserialize(stream) as PlayerDate;
            stream.Close();
            return date;
        }
        else
        {
            Debug.LogError("Save file not fount in" + path);
            return null;
        }
    }
}
