using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenHandler : MonoBehaviour
{
    public Text TitleP1;
    public Text TitleP2;

    public Text CollectedTextP1;
    public Text CollectedTextP2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.PickedUpCostumersP1 > GameManager.Instance.PickedUpCostumersP2)
        {
            TitleP1.text = "YOU WIN";
            CollectedTextP1.text = string.Format("You've collected " + GameManager.Instance.PickedUpCostumersP1.ToString() + " people.");

            TitleP2.text = "YOU LOSE";
            CollectedTextP2.text = string.Format("You've only collected " + GameManager.Instance.PickedUpCostumersP2.ToString() + " people.");
        }
        else if(GameManager.Instance.PickedUpCostumersP1 < GameManager.Instance.PickedUpCostumersP2)
        {
            TitleP2.text = "YOU WIN";
            CollectedTextP2.text = string.Format("You've collected " + GameManager.Instance.PickedUpCostumersP2.ToString() + " people.");

            TitleP1.text = "YOU LOSE";
            CollectedTextP1.text = string.Format("You've only collected " + GameManager.Instance.PickedUpCostumersP1.ToString() + " people.");
        }
        else
        {
            TitleP2.text = "YOU LOSE";
            CollectedTextP2.text = string.Format("You've collected " + GameManager.Instance.PickedUpCostumersP2.ToString() + " people.");

            TitleP1.text = "YOU LOSE";
            CollectedTextP1.text = string.Format("You've only collected " + GameManager.Instance.PickedUpCostumersP1.ToString() + " people.");
        }
    }
}
