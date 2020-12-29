using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public Text timer1;
    public Text timer2;
    public Text timer3;

    public GameObject MapScreen1;
    public GameObject MapScreen2;
    public GameObject MapScreen3;

    private float timeRemaining = 15;
    private int timeRemainingINT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MapScreen1.activeSelf)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            timeRemainingINT = (int)timeRemaining;
            timer1.text = timeRemainingINT.ToString();

            if (timeRemaining <= 0)
            {
                SceneManager.LoadScene(1);
                GameManager.Instance.IsRunning = true;
            }
        }

        if (MapScreen2.activeSelf)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            timeRemainingINT = (int)timeRemaining;
            timer2.text = timeRemainingINT.ToString();

            if (timeRemaining <= 0)
            {
                SceneManager.LoadScene(2);
                GameManager.Instance.IsRunning = true;
            }
        }

        if (MapScreen3.activeSelf)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            timeRemainingINT = (int)timeRemaining;
            timer3.text = timeRemainingINT.ToString();

            if (timeRemaining <= 0)
            {
                SceneManager.LoadScene(3);
                GameManager.Instance.IsRunning = true;
            }
        }
    }
}
