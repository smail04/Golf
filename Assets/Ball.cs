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
    public Transform spectator;
    public Joystick joystick;
    public Transform arrow;
    public BallState state;
    public Rigidbody _rigidbody;
    Vector3 forwardSpectatorDirection;
    float force;
    private void Start()
    {

    }

    private void Update()
    {
        if (_rigidbody.velocity.magnitude < 0.4)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

        if (_rigidbody.velocity.magnitude == 0)
        {
            state = BallState.Stopped;
            //joystick.Show();
        }
        else
        {
            state = BallState.Moving;
            //joystick.Hide();
        }

        //if (state == BallState.Stopped)
        //{
        if (Input.GetMouseButtonDown(0))
        {
            arrow.gameObject.SetActive(true);
            joystick.Show();
                
        }

        if (Input.GetMouseButton(0))
        {
            joystick.SetStickPosition(Input.mousePosition);
            Vector2 pos = joystick.GetPositionRelativeToCenter() / 10f;
            force = Mathf.Clamp(pos.magnitude, 0, 40); Debug.Log(force);
            spectator.Rotate(new Vector3(0, -pos.x, 0) / 15, Space.World);

            arrow.position = transform.position;
            forwardSpectatorDirection = new Vector3(spectator.forward.x, 0, spectator.forward.z);
            Vector3 arrowTargetPosition = transform.position + (forwardSpectatorDirection * force);
            arrow.LookAt(arrowTargetPosition, Vector3.up);

            //if (state == BallState.Moving)
            //{
                Time.timeScale = Mathf.Lerp(Time.timeScale, 0.2f, Time.deltaTime * 15 * (1f / Time.timeScale));
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 50, Time.deltaTime * 15 * (1f/Time.timeScale));
            //}
        }        

        if (Input.GetMouseButtonUp(0))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            arrow.gameObject.SetActive(false);
            _rigidbody.AddForce(forwardSpectatorDirection * force, ForceMode.VelocityChange);
            joystick.Hide();
            Time.timeScale = 1;
            Camera.main.fieldOfView = 60;
        }
        //}
    }
}
