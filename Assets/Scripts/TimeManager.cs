/*Christian Cerezo*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In progress...
/// </summary>
public class TimeManager : MonoBehaviour
{

    private static float InitialTime; //Time elapsed since Level (scene) has loaded

    public static float TotalTime; // Total time elapsed during gameplay

    public SaveObject TimeData;
    void Start()
    {
        TimeData = SaveManager.Load();
        InitialTime = Time.time;
    }

    public static float GetElapsedTime()
    {
        return Time.time - InitialTime;
    }
}
