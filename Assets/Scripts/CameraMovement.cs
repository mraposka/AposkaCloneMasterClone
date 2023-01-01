using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed;
    public Vector3 offset;
    void FixedUpdate()
    {
        Vector3 pos = player.position + offset;
        Vector3 smoothPos=Vector3.Lerp(transform.position, pos, smoothSpeed);
        transform.position = smoothPos;
        transform.LookAt(transform.position);
    }
}
