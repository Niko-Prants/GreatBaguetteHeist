using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuard : MonoBehaviour
{

    public Transform[] waypoints;
    public int targetPoint;
    public float speed = 1;
    public GameObject guard;
    private Vector3 angles;
    public float smooth = 1f;
    void Start()
    {
        targetPoint = 0;
    }

    void Update()
    {
        //checks if guard is on waypoint
        if(transform.position == waypoints[targetPoint].position)
        {
   
            increaseTargetInt();
            Turn();

        }
        //makes guard go to waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetPoint].position, speed * Time.deltaTime);
    }
    void increaseTargetInt()
    {
        //increases target number so the guard changes target and goes to next waypoint
        targetPoint++;

        //if target is greater than amount of waypoints ets target to 0
        if(targetPoint >= waypoints.Length)
        {
            targetPoint = 0;
        }
    }
private void Turn()
    {
        //makes guard turn around
        angles = transform.eulerAngles + 180f * Vector3.forward;
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, angles, smooth);
    }
}
