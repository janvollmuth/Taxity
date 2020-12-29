using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanAI : MonoBehaviour
{
    public GameObject NextWaypoint;
    public NavMeshAgent agent;
    public float speed;
    public GameObject Human;
    public GameObject positionPlayer;
    public GameObject HighestPoint;
    public GameObject RootPoint;
    public GameObject MinimapManager;
    public GameObject MinimapMarker;

    private int player;
    private ParabolaController parabola;
    private float duration;

    // Start is called before the first frame update
    void Start()
    {
        parabola = GetComponent<ParabolaController>();

        StartCoroutine(CoroutineMovement());

        if (Human.name.Contains("Pickable"))
        {
            MinimapManager.GetComponent<MinimapManager>().AddMarkerToList(MinimapMarker);
        }
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

    private IEnumerator CoroutineDeactivateHuman()
    {
        yield return new WaitForSeconds(duration);

        Destroy(Human);

        if (player == 1)
        {
            GameManager.Instance.Player1Stopped = false;
        }
        else if (player == 2)
        {
            GameManager.Instance.Player2Stopped = false;
        }
    }

    public void Move()
    {
        agent.SetDestination(NextWaypoint.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.GetType() == typeof(SphereCollider))
        {
            if ((other.name.Contains("WayPoint") || other.name.Contains("SpawnPoint")) && other.gameObject.GetComponent<WayPointManager_v2>().type == 1)
            {
                GameObject entry = other.gameObject;
                NextWaypoint = entry.GetComponent<WayPointManager_v2>().GetRandomCrossingOption();
                StartCoroutine(CoroutineMovement());
            }
        }

        if(other.GetType() == typeof(BoxCollider))
        {
            //Debug.Log("Hit Trigger..." + other.name);
        }
    }

    public void CalcualteParabola(int player)
    {
        this.player = player;

        if (player == 1)
        {
            positionPlayer.transform.position = GameManager.Instance.Player1Position.position;
            RootPoint.transform.position = Human.transform.position;
            Vector3 point = CalculateHighestPoint();
            HighestPoint.gameObject.transform.position = point;
        }
        else if (player == 2)
        {
            positionPlayer.transform.position = GameManager.Instance.Player2Position.position;
            RootPoint.transform.position = Human.transform.position;
            Vector3 point = CalculateHighestPoint();
            HighestPoint.gameObject.transform.position = point;
        }
    }

    private Vector3 CalculateHighestPoint()
    {
        if(player == 1)
        {
            float x = 0.5f * (Human.transform.position.x + GameManager.Instance.Player1Position.position.x);
            float y = Human.transform.position.y + 4f;
            float z = 0.5f * (Human.transform.position.z + GameManager.Instance.Player1Position.position.z);

            return new Vector3(x, y, z);
        }
        else if(player == 2)
        {
            float x = 0.5f * (Human.transform.position.x + GameManager.Instance.Player2Position.position.x);
            float y = Human.transform.position.y + 4f;
            float z = 0.5f * (Human.transform.position.z + GameManager.Instance.Player2Position.position.z);

            return new Vector3(x, y, z);
        }

        return new Vector3(0,0,0);
    }

    public void DeactivateHuman(int player)
    {
        parabola.FollowParabola();
        duration = parabola.GetDuration();
        StartCoroutine(CoroutineDeactivateHuman());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, NextWaypoint.transform.position);
    }
}
