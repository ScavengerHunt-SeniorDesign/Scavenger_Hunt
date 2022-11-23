/*Christian Cerezo*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private GameObject _playCanvas;
    [SerializeField] private  GameObject _optionsCanvas;
    [SerializeField] private GameObject _itemCanvas;
    public string menuScreen;
    [SerializeField] private TextMeshProUGUI _timeElapsed;

    public void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1)
            {
                _pauseCanvas.SetActive(true);
                _playCanvas.SetActive(false);
                _itemCanvas.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                _pauseCanvas.SetActive(false);
                _playCanvas.SetActive(true);
                _itemCanvas.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }
        //TODO: truncate to 2 decimal places
        _timeElapsed.text = "Time Elapsed: " + TimeManager.GetElapsedTime();
    }
    public void ClosePauseMenu()
    {
        _pauseCanvas.SetActive(false);
        _playCanvas.SetActive(true);
        _itemCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void OpenOptions()
    {
        _pauseCanvas.SetActive(false);
        _optionsCanvas.SetActive(true);
    }

    public void CloseOptions()
    {
        _optionsCanvas.SetActive(false);
        _pauseCanvas.SetActive(true);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(menuScreen);
    }
}
