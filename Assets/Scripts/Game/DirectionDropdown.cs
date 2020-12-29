using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDropdown : MonoBehaviour
{
    [HideInInspector]
    public int listIndex = 0;
    [HideInInspector]
    public List<string> Direction = new List<string>(new string[] { "North", "East", "West" });
}
