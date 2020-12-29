using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject Obstacle1;
    public GameObject Obstacle2;
    public GameObject Obstacle3;
    public GameObject Obstacle4;
    public GameObject Obstacle5;
    public GameObject Obstacle6;
    public GameObject Obstacle7;
    public GameObject Obstacle8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Obstacle1.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Obstacle2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Obstacle3.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Obstacle4.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Obstacle5.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            Obstacle6.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            Obstacle7.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            Obstacle8.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Obstacle1.SetActive(false);
            Obstacle2.SetActive(false);
            Obstacle3.SetActive(false);
            Obstacle4.SetActive(false);
            Obstacle5.SetActive(false);
            Obstacle6.SetActive(false);
            Obstacle7.SetActive(false);
            Obstacle8.SetActive(false);
        }
    }
}
