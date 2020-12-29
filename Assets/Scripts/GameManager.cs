using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int CarPlayer1;
    public int PickedUpCostumersP1;
    public bool HasWonP1;
    public bool Player1Stopped;
    public Transform Player1Position;
    public bool BoostOnP1;

    public int CarPlayer2;
    public int PickedUpCostumersP2;
    public bool HasWonP2;
    public bool Player2Stopped;
    public Transform Player2Position;
    public bool BoostOnP2;

    public int SelectedLevel;
    public float MasterVolume = 1;
    public int TargetCounter = 1;

    public bool IsRunning = false;
    public bool IsGameOver = false;

    public bool Restart = false;

    public int ActualPickableHumans = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CleanUpGameManager()
    {
        GameManager.Instance.IsGameOver = false;
        GameManager.Instance.IsRunning = false;
        GameManager.Instance.CarPlayer1 = 0;
        GameManager.Instance.CarPlayer2 = 0;
        GameManager.Instance.HasWonP1 = false;
        GameManager.Instance.HasWonP2 = false;
        GameManager.Instance.PickedUpCostumersP1 = 0;
        GameManager.Instance.PickedUpCostumersP2 = 0;
        GameManager.Instance.SelectedLevel = 0;
        GameManager.Instance.ActualPickableHumans = 0;

        GameManager.Instance.Player1Position = null;
        GameManager.Instance.Player2Position = null;
        GameManager.Instance.Player1Stopped = false;
        GameManager.Instance.Player2Stopped = false;
    }
}
