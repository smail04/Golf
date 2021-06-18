using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour
{
    public Transform ball;
    public float lerpDrag = 8;
    private List<Renderer> fadingRenderers = new List<Renderer>();

    void Update()
    {
        transform.position = ball.position;

        //Debug.DrawRay(Camera.main.transform.position, (ball.position - Camera.main.transform.position) * 1000);

        //RaycastHit hitInfo;
        //if (Physics.BoxCast(Camera.main.transform.position,
        //    new Vector3(2, 2, 2),
        //    ball.position - Camera.main.transform.position,
        //    out hitInfo,
        //    Quaternion.Euler(ball.position - Camera.main.transform.position),
        //    Vector3.Distance(Camera.main.transform.position, ball.position)))
        //{
        //    Debug.Log(hitInfo.collider.name);
        //    Renderer _renderer = hitInfo.collider.GetComponent<Renderer>();
        //    if (fadingRenderers.Contains(_renderer) == false)
        //        fadingRenderers.Add(_renderer);
        //    Color color = _renderer.material.color;
        //    _renderer.material.color = new Color(color.r, color.g, color.b, 0.3f);
        //}
    }

    public void Rotate(Vector3 rotation, float speed)
    {
        Debug.Log(rotation * speed);
        transform.Rotate(rotation * speed, Space.World);
    }
}
