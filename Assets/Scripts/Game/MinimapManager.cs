using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{
    public float VisibleDuration;
    public float Duration;

    private List<GameObject> markerList;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        markerList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            StartCoroutine(CoroutineUpdateMinimap());
            isActive = true;
        }
    }

    private IEnumerator CoroutineUpdateMinimap()
    {
        StartCoroutine(CoroutineActivateMinimap());

        yield return new WaitForSeconds(Duration);

        isActive = false;
    }

    private IEnumerator CoroutineActivateMinimap()
    {
        foreach(GameObject obj in markerList)
        {
            obj.SetActive(true);
        }

        yield return new WaitForSeconds(VisibleDuration);

        foreach (GameObject obj in markerList)
        {
            obj.SetActive(false);
        }
    }

    public void AddMarkerToList(GameObject obj)
    {
        markerList.Add(obj);
    }

    public void RemoveMarkerToList(GameObject obj)
    {
        markerList.Remove(obj);
    }
}
