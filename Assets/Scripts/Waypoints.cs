using System;
using System.Linq;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoints;

    private void Awake()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }

    }

    private void OnDrawGizmos()
    {
        if (waypoints == null) return;
        for (int i = 0; i < waypoints.Length-1; i++)
        {
            Gizmos.DrawLine(waypoints[i].position, waypoints[i+1].position);
        }
    }
}
