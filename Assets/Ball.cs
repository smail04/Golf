using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallState
{ 
    Moving,
    Aiming
}
public class Ball : MonoBehaviour
{
    public Transform spectator;
    public Joystick joystick;
    public Transform arrow;
    public BallState state;
    public Rigidbody _rigidbody;
    public TrajectoryRenderer trajectoryRenderer;
    public float forceMultiplier;

    Vector3 startPosition;
    Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = spectator.rotation;
    }

    private void Update()
    {
        if (state == BallState.Moving)
        {
            if (_rigidbody.velocity.magnitude < 0.4)
            {
                ForceStop();
            }
        }

        if (state == BallState.Aiming)
        {
            Aim();
        }

        if (transform.position.y < -5)
        {
            MoveToStart();
        }

        //trajectoryRenderer.transform.position = transform.position;
    }

    public void MoveToStart()
    {
        ForceStop();
        transform.position = startPosition;
        spectator.rotation = startRotation;
    }

    public void Charge()
    {
        arrow.gameObject.SetActive(true);
        state = BallState.Aiming;
    }

    public void Aim()
    {
        Vector2 pos = joystick.GetPositionRelativeToCenter() / 10f;
        spectator.Rotate(new Vector3(0, -pos.x, 0) / 15, Space.World);

        float force = Mathf.Clamp(joystick.GetPositionRelativeToCenter().magnitude, 0, 50);
        Vector3 speed = new Vector3(spectator.forward.x, 0, spectator.forward.z) * force * forceMultiplier;
        trajectoryRenderer.ShowTrajectory(transform.position, new Vector3(speed.x, _rigidbody.velocity.y, speed.z),_rigidbody.drag, _rigidbody.mass);

        Vector3 arrowTargetPosition = transform.position + new Vector3(spectator.forward.x, 0, spectator.forward.z);
        
        arrow.LookAt(arrowTargetPosition, Vector3.up);
        arrow.position = transform.position;

        Time.timeScale = Mathf.Lerp(Time.timeScale, 0.2f, Time.deltaTime * 15 * (1f / Time.timeScale));
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 50, Time.deltaTime * 15 * (1f / Time.timeScale));
    }

    public void Release()
    {
        ForceStop();
        arrow.gameObject.SetActive(false);
        float force = Mathf.Clamp(joystick.GetPositionRelativeToCenter().magnitude, 0, 50);
        _rigidbody.AddForce(new Vector3(spectator.forward.x, 0, spectator.forward.z) * force * forceMultiplier, ForceMode.VelocityChange);
        Time.timeScale = 1;
        Camera.main.fieldOfView = 60;
        state = BallState.Moving;
    }

    public void ForceStop()
    {
        _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
        _rigidbody.angularVelocity = Vector3.zero;
    }

}
