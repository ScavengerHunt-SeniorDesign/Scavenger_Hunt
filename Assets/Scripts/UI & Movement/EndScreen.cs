/*Christian Cerezo*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private string _mainLevel;
    [SerializeField] private string _mainMenu;
    public static int GameDifficulty;
    [SerializeField] private GameObject _difficultyScreen;
    [SerializeField] private GameObject _endScreen;
    private SaveObject SaveData;



    public void QuitToMain()
    {
        SceneManager.LoadScene(_mainMenu);
    }

    public void PlayAgain()
    {
        _difficultyScreen.SetActive(true);
        _endScreen.SetActive(false);
    }

    public void SetDifficulty(int x)
    {
        // 0, 1, 2 correspond to easy, medium, hard respectively
        SaveData.GameDifficulty = x;
        SaveManager.Save(SaveData);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_mainLevel);
    }
}
