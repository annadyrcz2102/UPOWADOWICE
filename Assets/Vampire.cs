using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Vampire : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    Transform Player;
    AIDestinationSetter enemyDest;
        
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyDest= GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player.position);
    }
}
