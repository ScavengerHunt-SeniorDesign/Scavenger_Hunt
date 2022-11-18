using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScreen : MonoBehaviour
{
    [SerializeField] private GameObject _fullInventoryCanvas;
    [SerializeField] private GameObject _playScreenCanvas;
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
           

            if (Time.timeScale == 1)
            {
                Debug.Log("Item Screen: true");
                _fullInventoryCanvas.SetActive(true);
                _playScreenCanvas.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                Debug.Log("Item Screen: false");
                _fullInventoryCanvas.SetActive(false);
                _playScreenCanvas.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
            Debug.Log(Time.timeScale);
        }
    }
}
