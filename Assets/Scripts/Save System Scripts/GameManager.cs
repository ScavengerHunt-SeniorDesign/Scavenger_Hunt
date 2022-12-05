using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static SaveObject SaveData;
    void Awake()
    {
        SaveData = SaveManager.Load();
        SaveData.NewGame = false;
        SaveManager.Save(SaveData);
    }

}
