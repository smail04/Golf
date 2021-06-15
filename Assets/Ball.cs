using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallState
{ 
    Moving,
    Stopped
}
public class Ball : MonoBehaviour
{
    public Joystick joystick;
    public Transform arrow;
    public BallState state;
    public Rigidbody _rigidbody;
    Vector3 arrowTarget = Vector3.zero;

    private void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log(_rigidbody.velocity.magnitude);
        if (_rigidbody.velocity.magnitude < 0.4)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

        if (_rigidbody.velocity.magnitude == 0)
        {
            state = BallState.Stopped;
            joystick.Show();
        }
        else
        {
            state = BallState.Moving;
            joystick.Hide();
        }

        if (state == BallState.Stopped)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //joystick.Show();
                arrow.gameObject.SetActive(true);
            }

            if (Input.GetMouseButton(0))
            {
                joystick.SetStickPosition(Input.mousePosition);
                Vector2 pos = joystick.GetPositionRelativeToCenter() / 10f;
                arrowTarget = transform.position + new Vector3(-pos.x, 0, -pos.y);
                arrow.position = transform.position;
                arrow.LookAt(arrowTarget, Vector3.up);
            }        

            if (Input.GetMouseButtonUp(0))
            {
                //joystick.Hide();
                arrow.gameObject.SetActive(false);
                _rigidbody.AddForce(arrowTarget - transform.position, ForceMode.VelocityChange);
            }
        }
    }
}
