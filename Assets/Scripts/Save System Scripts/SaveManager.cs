/*Author: Christian Cerezo */
using UnityEngine;
using System.IO;
public static class SaveManager
{
    //persistant data path for the project
    public static string directory = "/SaveData/";
    //file name to be used to save data
    public static string fileName = "MyData.txt";

    /// <summary>
    /// Public fields are saved in JSON format in a text file under the persistentDataPath + directory path
    /// </summary>
    /// <param name="so">Object whose public fields are to be saved </param>
    public static void Save(SaveObject so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        //JSON generated from public fields of object
        string json = JsonUtility.ToJson(so);
        //JSON is saved
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveObject Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveObject so = new SaveObject();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<SaveObject>(json);

        }
        else
        {
            Debug.Log("Save file does not exist");
        }

        return so;
    }
}
