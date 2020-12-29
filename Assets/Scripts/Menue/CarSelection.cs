using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    private int CarPlayer1 = 0;
    private int CarPlayer2 = 0;

    public Image PreviousButtonP1;
    public Image NextButtonP1;

    public Image PreviousButtonP2;
    public Image NextButtonP2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.CarPlayer1 = this.CarPlayer1;
        GameManager.Instance.CarPlayer2 = this.CarPlayer2;
    }

    public void OnClickPREVIOUSP1()
    {
        if(CarPlayer1 == 0)
        {
            CarPlayer1 = 1;
        }
        else
        {
            CarPlayer1--;
        }
    }
    public void OnClickNEXTP1()
    {
        if (CarPlayer1 == 1)
        {
            CarPlayer1 = 0;
        }
        else
        {
            CarPlayer1++;
        }
    }
    public void OnClickPREVIOUSP2()
    {
        if (CarPlayer2 == 0)
        {
            CarPlayer2 = 1;
        }
        else
        {
            CarPlayer2--;
        }
    }
    public void OnClickNEXTP2()
    {
        if (CarPlayer2 == 1)
        {
            CarPlayer2 = 0;
        }
        else
        {
            CarPlayer2++;
        }
    }
}
