using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject PipeHolder;
    public GameObject[] Pipes;
    public GameObject Chest;

    [SerializeField]
    int totalPipes = 0;

    private int correctedPipes = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalPipes = PipeHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];

        for (int i = 0; i < totalPipes; i++) 
        {
            Pipes[i] = PipeHolder.transform.GetChild(i).gameObject;
        }
    }

    public void correctMove()
    {
        correctedPipes += 1;

        Debug.Log("correct move");

        if (correctedPipes == totalPipes)
        {
            Debug.Log("You win!");
            // open chest
            Chest.GetComponent<Animator>().Play("Open");

            //Animator = GameObject.Find("Open").GetComponent<Animator>();

        }
    }

    public void wrongMove()
    {
        correctedPipes -= 1;
    }
}
