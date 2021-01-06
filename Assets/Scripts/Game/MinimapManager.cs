using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{
    public float VisibleDuration;
    public float Duration;

    private List<GameObject> markerList;

    // Start is called before the first frame update
    void Start()
    {
        markerList = new List<GameObject>();
        StartCoroutine(CoroutineActivateMinimap());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CoroutineUpdateMinimap()
    {
        yield return new WaitForSeconds(Duration);

        StartCoroutine(CoroutineActivateMinimap());
    }

    private IEnumerator CoroutineActivateMinimap()
    {
        foreach(GameObject obj in markerList)
        {
            if(obj != null)
            {
                obj.SetActive(true);
            }
        }

        yield return new WaitForSeconds(VisibleDuration);

        foreach (GameObject obj in markerList)
        {
            if(obj != null)
            {
                obj.SetActive(false);
            }
        }

        StartCoroutine(CoroutineUpdateMinimap());
    }

    public void AddMarkerToList(GameObject obj)
    {
        markerList.Add(obj);
    }

    public void RemoveMarkerFromList(GameObject obj)
    {
        markerList.Remove(obj);
    }
}
