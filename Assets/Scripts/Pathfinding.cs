using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent nav;
    private int destPoint;
    
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        Debug.Log(nav);

    }
    
    public void CheckDist()
    {
        Debug.Log(nav.pathPending);
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }
    public void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        nav.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}
