using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueHandler : MonoBehaviour
{

    public GameObject MainScreen;
    public GameObject CreditsScreen;
    public GameObject SettingsScreen;
    public GameObject HowToScreen;
    public GameObject ChooseCarScreen;
    public GameObject ChooseLevelScreen;
    public GameObject MapScreen1;
    public GameObject MapScreen2;
    public GameObject MapScreen3;
    //public GameObject MapCanvas;



    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.Restart)
        {
            MainScreen.SetActive(false);
            CreditsScreen.SetActive(false);
            SettingsScreen.SetActive(false);
            HowToScreen.SetActive(false);
            ChooseCarScreen.SetActive(true);
            ChooseLevelScreen.SetActive(false);
            MapScreen1.SetActive(false);
            MapScreen2.SetActive(false);
            MapScreen3.SetActive(false);
            //MapCanvas.SetActive(false);
        }
        else
        {
            MainScreen.SetActive(true);
            CreditsScreen.SetActive(false);
            SettingsScreen.SetActive(false);
            HowToScreen.SetActive(false);
            ChooseCarScreen.SetActive(false);
            ChooseLevelScreen.SetActive(false);
            MapScreen1.SetActive(false);
            MapScreen2.SetActive(false);
            MapScreen3.SetActive(false);
            //MapCanvas.SetActive(false);
        }

        GameManager.Instance.Restart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //MainScreen Methods for Buttons
    public void OnClickButtonToHOWTOSCREEN()
    {
        MainScreen.SetActive(false);
        CreditsScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        HowToScreen.SetActive(true);
        ChooseCarScreen.SetActive(false);
        ChooseLevelScreen.SetActive(false);
        MapScreen1.SetActive(false);
        MapScreen2.SetActive(false);
        MapScreen3.SetActive(false);
        //MapCanvas.SetActive(false);
    }

    public void OnClickButtonToCREDITSSCREEN()
    {
        MainScreen.SetActive(false);
        CreditsScreen.SetActive(true);
        SettingsScreen.SetActive(false);
        HowToScreen.SetActive(false);
        ChooseCarScreen.SetActive(false);
        ChooseLevelScreen.SetActive(false);
        MapScreen1.SetActive(false);
        MapScreen2.SetActive(false);
        MapScreen3.SetActive(false);
        //MapCanvas.SetActive(false);
    }

    public void OnClickButtonToSETTINGSSCREEN()
    {
        MainScreen.SetActive(false);
        CreditsScreen.SetActive(false);
        SettingsScreen.SetActive(true);
        HowToScreen.SetActive(false);
        ChooseCarScreen.SetActive(false);
        ChooseLevelScreen.SetActive(false);
        MapScreen1.SetActive(false);
        MapScreen2.SetActive(false);
        MapScreen3.SetActive(false);
        //MapCanvas.SetActive(false);
    }

    public void OnClickButtonToCHOOSECARSCREEN()
    {
        MainScreen.SetActive(false);
        CreditsScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        HowToScreen.SetActive(false);
        ChooseCarScreen.SetActive(true);
        ChooseLevelScreen.SetActive(false);
        MapScreen1.SetActive(false);
        MapScreen2.SetActive(false);
        MapScreen3.SetActive(false);
        //MapCanvas.SetActive(false);
    }

    public void OnClickButtonToCHOOSELEVELSCREEN()
    {
        MainScreen.SetActive(false);
        CreditsScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        HowToScreen.SetActive(false);
        ChooseCarScreen.SetActive(false);
        ChooseLevelScreen.SetActive(true);
        MapScreen1.SetActive(false);
        MapScreen2.SetActive(false);
        MapScreen3.SetActive(false);
        //MapCanvas.SetActive(false);
    }

    public void OnClickButtonToMAPSCREEN()
    {
        if(GameManager.Instance.SelectedLevel == 0)
        {
            return;
        }
        else if (GameManager.Instance.SelectedLevel == 1)
        {
            MapScreen1.SetActive(true);
            MapScreen2.SetActive(false);
            MapScreen3.SetActive(false);
        }
        else if (GameManager.Instance.SelectedLevel == 2)
        {
            MapScreen1.SetActive(false);
            MapScreen2.SetActive(true);
            MapScreen3.SetActive(false);
        }
        else if (GameManager.Instance.SelectedLevel == 3)
        {
            MapScreen1.SetActive(false);
            MapScreen2.SetActive(false);
            MapScreen3.SetActive(true);
        }

        MainScreen.SetActive(false);
        CreditsScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        HowToScreen.SetActive(false);
        ChooseCarScreen.SetActive(false);
        ChooseLevelScreen.SetActive(false);
        //MapCanvas.SetActive(true);
    }

    public void OnClickButtonToMAINSCREEN()
    {
        MainScreen.SetActive(true);
        CreditsScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        HowToScreen.SetActive(false);
        ChooseCarScreen.SetActive(false);
        ChooseLevelScreen.SetActive(false);
        MapScreen1.SetActive(false);
        MapScreen2.SetActive(false);
        MapScreen3.SetActive(false);
        //MapCanvas.SetActive(false);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

    public void OnClickSkipButton()
    {
        SceneManager.LoadScene(GameManager.Instance.SelectedLevel);
        GameManager.Instance.IsRunning = true;
    }
}
