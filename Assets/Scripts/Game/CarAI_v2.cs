using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI_v2 : MonoBehaviour
{
    public GameObject NextWaypoint;
    public NavMeshAgent agent;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoroutineMovement());
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsRunning)
        {
            agent.speed = 0;
        }
        else
        {
            agent.speed = speed;
        }
    }

    private IEnumerator CoroutineMovement()
    {
        Move();

        yield return null;
    }

    public void Move()
    {
        agent.SetDestination(NextWaypoint.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("WayPoint") && other.gameObject.GetComponent<WayPointManager_v2>().type == 0)
        {
            GameObject entry = other.gameObject;
            NextWaypoint = entry.GetComponent<WayPointManager_v2>().GetRandomCrossingOption();
            StartCoroutine(CoroutineMovement());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Taxi"))
        {
            GetComponent<ParabolaController>().FollowParabola();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, NextWaypoint.transform.position);
    }
}

