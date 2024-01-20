using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveGameManager
{
    public static void SaveGameData(GameData savedata) {
        BinaryFormatter binaryformatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath+"/SaveGameData.save");
        binaryformatter.Serialize(file, savedata);
        file.Close();
        Debug.Log("Saved");
    }

    public static GameData ReadGameData() {
        if (File.Exists(Application.persistentDataPath + "/SaveGameData.save")) {
            try
            {
                BinaryFormatter binaryformatter = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/SaveGameData.save", FileMode.Open);
                GameData savedData = (GameData)binaryformatter.Deserialize(file);
                file.Close();
                Debug.Log("Read");
                return savedData;
            }
            catch { 
            }
        }
        return null;
    }
}
