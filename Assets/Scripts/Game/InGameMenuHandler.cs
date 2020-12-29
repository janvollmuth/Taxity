using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuHandler : MonoBehaviour
{
    public GameObject InGameUI;
    public GameObject WinScreen;
    public GameObject Player1UI;
    public GameObject Player2UI;
    public InGameAudioHandler AudioHandler;

    private bool winSoundActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameOver)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        InGameUI.SetActive(false);
        WinScreen.SetActive(true);
        Player1UI.SetActive(false);
        Player2UI.SetActive(false);

        AudioHandler.StopBackgroundMusic();

        if (!winSoundActive)
        {
            AudioHandler.PlayWinSound();
            winSoundActive = true;
        }
    }

    public void OnClickButtonToMAINSCREEN()
    {
        WinScreen.SetActive(false);
        SceneManager.LoadScene(0);
        GameManager.Instance.CleanUpGameManager();
    }

    public void OnClickButtonPLAYAGAIN()
    {
        WinScreen.SetActive(false);
        SceneManager.LoadScene(GameManager.Instance.SelectedLevel);
        GameManager.Instance.CleanUpGameManager();
        GameManager.Instance.IsRunning = true;
    }
}
