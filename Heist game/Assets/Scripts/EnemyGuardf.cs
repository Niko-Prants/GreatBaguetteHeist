using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardf : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;

    private int waypointIndex;
    private float dis;

    

    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (dis < 1f)
        {
            IncreaseIndex();

        }
        Patrol();
    }
    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
