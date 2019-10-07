
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{
    public static void SaveHatchigotchi(Hatchigotchi hatchigotchi)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/hatchigotchi.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        HatchigotchiData data = new HatchigotchiData(hatchigotchi);
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static HatchigotchiData LoadHatchigotchi()
    {
        string path = Application.persistentDataPath + "/hatchigotchi.fun";
        if(File.Exists(path))
        {
            
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HatchigotchiData data = formatter.Deserialize(stream) as HatchigotchiData;
            
           
            stream.Close();

            return data;
        }else
        {
            Debug.LogError("Save file not found in" + path);
            return null;   
        }
    
    
    
    
    }


}
