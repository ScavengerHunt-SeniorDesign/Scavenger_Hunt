/*Christian Cerezo*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In progress...
/// </summary>
public class TimeManager : MonoBehaviour
{

    public static TimeManager instance = null;

    private static float InitialTime; 

    public static float TimeSinceLoad; //Time elapsed since Level (scene) has loaded

    public SaveObject TimeData;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        TimeData = SaveManager.Load();
        InitialTime = Time.time;
    }

    private void Update()
    {
        TimeSinceLoad = Time.time - InitialTime;
    }
    public float GetElapsedTime()
    {
        return TimeSinceLoad + TimeData.TimeElapsed;
    }
}

