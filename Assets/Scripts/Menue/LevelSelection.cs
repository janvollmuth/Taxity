using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    private int SelectedLevel = 0;

    public GameObject ButtonLevel1;
    public GameObject ButtonLevel2;
    public GameObject ButtonLevel3;

    public GameObject DescriptionLevel1;
    public GameObject DescriptionLevel2;
    public GameObject DescriptionLevel3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.SelectedLevel = this.SelectedLevel;
    }

    public void OnClickLEVEL1()
    {
        SelectedLevel = 1;
        ButtonLevel1.gameObject.transform.localScale = new Vector2(1.5f, 1.5f);
        ButtonLevel2.gameObject.transform.localScale = new Vector2(1f, 1f);
        ButtonLevel3.gameObject.transform.localScale = new Vector2(1f, 1f);

        DescriptionLevel1.SetActive(true);
        DescriptionLevel2.SetActive(false);
        DescriptionLevel3.SetActive(false);

        GameManager.Instance.TargetCounter = 5;
    }
    public void OnClickLEVEL2()
    {
        SelectedLevel = 2;
        ButtonLevel1.gameObject.transform.localScale = new Vector2(1f, 1f);
        ButtonLevel2.gameObject.transform.localScale = new Vector2(1.5f, 1.5f);
        ButtonLevel3.gameObject.transform.localScale = new Vector2(1f, 1f);

        DescriptionLevel1.SetActive(false);
        DescriptionLevel2.SetActive(true);
        DescriptionLevel3.SetActive(false);

        GameManager.Instance.TargetCounter = 5;
    }
    public void OnClickLEVEL3()
    {
        SelectedLevel = 3;
        ButtonLevel1.gameObject.transform.localScale = new Vector2(1f, 1f);
        ButtonLevel2.gameObject.transform.localScale = new Vector2(1f, 1f);
        ButtonLevel3.gameObject.transform.localScale = new Vector2(1.5f, 1.5f);

        DescriptionLevel1.SetActive(false);
        DescriptionLevel2.SetActive(false);
        DescriptionLevel3.SetActive(true);

        GameManager.Instance.TargetCounter = 5;
    }
}
