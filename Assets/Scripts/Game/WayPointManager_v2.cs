using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WayPointManager_v2 : MonoBehaviour
{

    [Serializable]
    public struct WayPoint
    {
        public string direction;
        public bool blocked;
        public GameObject crossingOption;
    }

    public int type = 0;

    public WayPoint[] crossingOptions;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetSelectedCrossingOption(string direction, Animator animator)
    {
        WayPoint next = new WayPoint();

        if (crossingOptions.Length == 1)
        {
            return crossingOptions[0].crossingOption;
        }

        foreach(WayPoint wayPoint in crossingOptions)
        {
            if(wayPoint.direction == direction && !wayPoint.blocked)
            {
                next = wayPoint;

                if(next.direction == "East")
                {
                    animator.SetTrigger("Right");
                }
                else if(next.direction == "West")
                {
                    animator.SetTrigger("Left");
                }
            }
        }

        if(next.crossingOption != null)
        {
            return next.crossingOption;
        }
        else
        {
            return GetRandomCrossingOption();
        }
    }

    public GameObject GetRandomCrossingOption()
    {
        int rand = Random.Range(0, crossingOptions.Length);

        if (crossingOptions[rand].blocked)
        {
            return GetRandomCrossingOption();
        }
        else
        {
            return crossingOptions[rand].crossingOption;
        }
    }

    private void OnDrawGizmosSelected()
    {
        foreach(WayPoint wayPoint in crossingOptions)
        {
            if (!wayPoint.blocked)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, wayPoint.crossingOption.transform.position);
            }
        }
    }
}
