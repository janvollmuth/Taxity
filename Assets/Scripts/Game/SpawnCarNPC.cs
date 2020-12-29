using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCarNPC : MonoBehaviour
{
    public GameObject Point;

    public bool spawn = false;
    public GameObject Car;
    public GameObject FirstWayPoint;
    public float rotation = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            SpawnCar();
            spawn = false;
        }
    }

    private IEnumerator CoroutineSpawn()
    {
        GameObject instObj = (GameObject)Instantiate(Car, Point.transform.position, new Quaternion(0, 0, rotation, 0));
        instObj.GetComponentInChildren<CarAI_v2>().NextWaypoint = FirstWayPoint;

        yield return null;
    }

    public void SpawnCar()
    {
        StartCoroutine(CoroutineSpawn());
    }
}
