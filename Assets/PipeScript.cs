using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    float[] rotations = {0, 90, 180, 270};

    public float[] correctRotations;
    [SerializeField]
    bool isPlaced = false;

    int possibleRotations = 1;

    [SerializeField]
    public GameManager gameManager;

    private void Awake()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        possibleRotations = correctRotations.Length;

        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (possibleRotations > 1) 
        {
            if (transform.eulerAngles.z == correctRotations[0] || transform.eulerAngles.z == correctRotations[1])
            {
                isPlaced = true;
                gameManager.correctMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotations[0])
            {
                isPlaced = true;
                gameManager.correctMove();
            }
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if (possibleRotations > 1)
        {
            if (transform.eulerAngles.z == correctRotations[0] || transform.eulerAngles.z == correctRotations[1] && isPlaced == false)
            {
                isPlaced = true;
                gameManager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                gameManager.wrongMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotations[0] && isPlaced == false)
            {
                isPlaced = true;
                gameManager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                gameManager.wrongMove();
            }
        }
        
    }

}
