using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercam : MonoBehaviour
{

    public Transform Player;
    public Vector3 Offset;

    void LateUpdate()
    {
        //freezes camera rotate
        if (Player != null)
            transform.position = Player.position + Offset;
    }
}
