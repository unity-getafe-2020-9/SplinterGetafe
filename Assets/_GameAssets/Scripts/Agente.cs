using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agente : MonoBehaviour
{
    public Transform[] targetPoints;
    NavMeshAgent nma;
    int targetIndex = 0;
    private void Awake()
    {
        nma = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        nma.SetDestination(targetPoints[targetIndex].position);
    }
    private void Update()
    {
        if (nma.hasPath)
        {
            if (nma.remainingDistance < 1)
            {
                targetIndex++;
                //targetIndex = targetIndex == targetPoints.Length ? 0 : targetIndex;
                if (targetIndex == targetPoints.Length)
                {
                    targetIndex = 0;
                }
                nma.SetDestination(targetPoints[targetIndex].position);
            }
        }
    }
}
