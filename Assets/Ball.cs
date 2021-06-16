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
        float force = Mathf.Clamp(joystick.GetPositionRelativeToCenter().magnitude, 0, 40);
        _rigidbody.AddForce(new Vector3(spectator.forward.x, 0, spectator.forward.z) * force, ForceMode.VelocityChange);
        Time.timeScale = 1;
        Camera.main.fieldOfView = 60;
        state = BallState.Moving;
    }

    public void ForceStop()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

}
