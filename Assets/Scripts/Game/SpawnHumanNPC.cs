using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHumanNPC : MonoBehaviour
{
    public GameObject Point;

    public bool spawn = false;
    public GameObject[] PickableHuman;
    public GameObject[] Humans;
    public GameObject FirstWayPoint;
    public GameObject MinimapManager;
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
            SpawnHuman();
            spawn = false;
        }
    }

    private IEnumerator CoroutineSpawnHuman()
    {
        int rand = Random.Range(0, Humans.Length);

        GameObject instObj = (GameObject)Instantiate(Humans[rand], Point.transform.position, new Quaternion(0, 0, rotation, 0));
        instObj.GetComponentInChildren<HumanAI>().NextWaypoint = FirstWayPoint;

        yield return null;
    }

    private IEnumerator CoroutineSpawnPickableHuman()
    {
        if(GameManager.Instance.SelectedLevel == 1)
        {
            GameObject instObj = (GameObject)Instantiate(PickableHuman[0], Point.transform.position, new Quaternion(0, 0, rotation, 0));
            instObj.GetComponentInChildren<HumanAI>().NextWaypoint = FirstWayPoint;
            instObj.GetComponentInChildren<HumanAI>().MinimapManager = MinimapManager;
        }
        else
        {
            int rand = Random.Range(0, PickableHuman.Length);

            GameObject instObj = (GameObject)Instantiate(PickableHuman[rand], Point.transform.position, new Quaternion(0, 0, rotation, 0));
            instObj.GetComponentInChildren<HumanAI>().NextWaypoint = FirstWayPoint;
            instObj.GetComponentInChildren<HumanAI>().MinimapManager = MinimapManager;
        }

        yield return null;
    }

    public void SpawnHuman()
    {
        StartCoroutine(CoroutineSpawnHuman());
    }

    public void SpawnPickableHuman()
    {
        StartCoroutine(CoroutineSpawnPickableHuman());
    }
}
