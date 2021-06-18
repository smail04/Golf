using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    public float maxLength = 50;
    private LineRenderer lineRendererComponent;

    private void Start()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed, float drag, float mass)
    {
        Vector3[] points = new Vector3[100];
        lineRendererComponent.positionCount = points.Length;

        float length = 0;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;
            //Vector3 newSpeed = speed + Physics.gravity * mass * time;
            //newSpeed = newSpeed - newSpeed * drag * time;
            //points[i] = origin + (newSpeed) * time + (Physics.gravity * time * time / 2f);

            if (i != 0)
            {
                length += Vector3.Distance(points[i - 1], points[i]);
            }

            if (points[i].y < 0 || length >= maxLength)
            {
                lineRendererComponent.positionCount = i + 1;
                break;
            }
        }

        lineRendererComponent.SetPositions(points);
    }
}