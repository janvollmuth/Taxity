using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public int TargetPickableHumans;
    public int TargetHumans;
    public int ActualHumans = 0;

    public GameObject[] SpawnPointsCars;
    public int TargetCars;
    public int ActualCars = 0;

    public int SpawnTimer = 10;

    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = SpawnTimer;

        for(int i = 0; i < TargetPickableHumans; i++)
        {
            int rand = Random.Range(0, SpawnPoints.Length);

            SpawnPoints[rand].GetComponent<SpawnHumanNPC>().SpawnPickableHuman();
        }

        GameManager.Instance.ActualPickableHumans = 3;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CoroutineUpdateSpawning());
    }

    private IEnumerator CoroutineUpdateSpawning()
    {
        if (GameManager.Instance.ActualPickableHumans < 3)
        {
            int rand = Random.Range(0, SpawnPoints.Length);

            SpawnPoints[rand].GetComponent<SpawnHumanNPC>().SpawnPickableHuman();

            GameManager.Instance.ActualPickableHumans++;
        }

        if (timer <= 0)
        {
            if (ActualHumans <= TargetHumans)
            {
                int rand = Random.Range(0, SpawnPoints.Length);

                SpawnPoints[rand].GetComponent<SpawnHumanNPC>().SpawnHuman();
                ActualHumans++;
                timer = SpawnTimer;
            }

            if (ActualCars <= TargetCars)
            {
                int rand = Random.Range(0, SpawnPointsCars.Length);

                SpawnPointsCars[rand].GetComponent<SpawnCarNPC>().SpawnCar();
                ActualCars++;
                timer = SpawnTimer;
            }
        }

        timer--;

        yield return null;
    }
}
