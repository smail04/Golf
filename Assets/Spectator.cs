using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour
{
    public Transform ball;
    public float lerpDrag = 8;

    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, ball.position, Time.deltaTime * lerpDrag * (1f / Time.timeScale));
        transform.position = ball.position;
    }

    public void Rotate(Vector3 rotation, float speed)
    {
        transform.Rotate(rotation * speed, Space.World);
    }
}
