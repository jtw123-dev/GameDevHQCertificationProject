using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicMechEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        _agent.destination = _waypoints[1].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
