using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{

    public float radius = 1;
    [Range(0, 360)]
    public float angle = 45;


    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer { get; private set; }
    public bool caught;



    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
    }
    private void Update()
    {
        if(canSeePlayer == true)
        {
            caught = true;
        }
        else
        {
            caught = false;
        }
    }
    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetMask);
        if(rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;

            if(Vector2.Angle(transform.up, dirToTarget) < angle  / 2)
            {
                float distToTarget = Vector2.Distance(transform.position, target.position);
                if(!Physics2D.Raycast(transform.position, dirToTarget, distToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if(canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle1 = DirFromAngle(-transform.eulerAngles.z, -angle * 0.5f);
        Vector3 angle2 = DirFromAngle(-transform.eulerAngles.z, angle * 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + angle1 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle2 * radius);

        if(canSeePlayer)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, playerRef.transform.position);
        }
    }
    private Vector3 DirFromAngle(float eulerY, float angleInDegrees)
    {
            angleInDegrees += eulerY;
       
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
