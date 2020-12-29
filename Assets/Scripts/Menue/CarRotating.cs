using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotating : MonoBehaviour
{
    public GameObject ChooseCarScreen;

    private GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        car = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (ChooseCarScreen.activeSelf)
        {
            car.transform.RotateAround(car.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }
}
