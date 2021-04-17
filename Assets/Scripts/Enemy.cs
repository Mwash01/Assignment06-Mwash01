using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Lowman;

    private void Update() {
        Agent.SetDestination(Lowman.position);
    }
}
