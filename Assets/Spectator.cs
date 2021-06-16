using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour
{
    public Transform ball;
    public float lerpDrag = 8;

    void Update()
    {
        transform.position = ball.position;
    }

    public void Rotate(Vector3 rotation, float speed)
    {
        Debug.Log(rotation * speed);
        transform.Rotate(rotation * speed, Space.World);
    }
}
