/*Christian Cerezo */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    // Used to store level difficulty to be serialized to JSON
    public SaveObject SaveData;

    [SerializeField] private GameObject _difficultyCanvas;
    [SerializeField] private GameObject _mainMenuCanvas;
    
    // Name of the scene to be loaded to enter the level
    [SerializeField] private string _mainLevel;

    //Global Variable that will allow us to use across all scripts - Pedro
    [HideInInspector]
    public static int levelDifficulty;

    /// <summary>
    /// Game difficulty set, saved, and serialized to JSON file
    /// </summary>
    /// <param name="difficulty"> Level difficulty: ints 0, 1, 2 correspond to easy, medium, hard </param>
    public void SetDifficulty(int difficulty)
    {
        MainMenu.isContinue = false; //level will generate without using save data - Christian

        levelDifficulty = difficulty;               //Save difficulty to global variable - Pedro
        SaveData.GameDifficulty = difficulty;
        SaveManager.Save(SaveData);
    }

    public void CloseDifficulty()
    {
        _difficultyCanvas.SetActive(false);
        _mainMenuCanvas.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_mainLevel);
    }

}
