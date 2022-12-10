/*Christian Cerezo*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private string _mainLevel;
    [SerializeField] private string _mainMenu;
    [SerializeField] private TextMeshProUGUI elapsedTime;
    [SerializeField] private GameObject _difficultyScreen;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _playScreen;
    [SerializeField] private GameObject _itemScreen;
    [SerializeField] private GameObject victoryStarPrefab;
    [SerializeField] private GameObject nullStarPrefab;

    [SerializeField] private GameObject scoreArea;

    SaveObject NewSaveData;

    private void Update()
    {
        if (GameManager.isEndGame)
        {
            OpenEndScreen();
            GameManager.isEndGame = false;
        }
    }

    public void OpenEndScreen()
    {
        Time.timeScale = 0;
        _endScreen.SetActive(true);
        string seconds = GameManager.SaveData.TimeElapsed.ToString("0.00");
        elapsedTime.text = "Total Time Elapsed: " + seconds + "s";
        _playScreen.SetActive(false);
        _itemScreen.SetActive(false);


        // instantiate star objects in score field
        int numStars = GameManager.instance._timeGoalIntervals;
        float timeInterval = GameManager.instance._timeGoalMax / GameManager.instance._timeGoalIntervals;
        int score = (int) ((GameManager.instance._timeGoalMax - GameManager.SaveData.TimeElapsed + timeInterval) / timeInterval);
        
        
        for (int i = 0; i < score; i++)
        {
            GameObject obj = Instantiate(victoryStarPrefab);
            obj.transform.SetParent(scoreArea.transform, false);
            numStars--;
        }
        while(numStars > 0)
        {
            GameObject obj = Instantiate(nullStarPrefab);
            obj.transform.SetParent(scoreArea.transform, false);
            numStars--;
        }



    }


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
        NewSaveData.GameDifficulty = x;
        SaveManager.Save(NewSaveData);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_mainLevel);
    }
}
