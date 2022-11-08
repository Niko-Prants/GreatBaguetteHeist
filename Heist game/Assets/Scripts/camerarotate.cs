using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerarotate : MonoBehaviour
{
    public float camSpeed = 10f;

  



    void Update()
    {
        //rotates camera between 85 and -85
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * camSpeed, 180) -85);


    }
}
