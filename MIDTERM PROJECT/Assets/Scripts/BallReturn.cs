using UnityEngine;

public class BallReturn : MonoBehaviour
{
    public BallInteraction player;

    Rigidbody[] balls;
    Vector3[] startPositions;
    Quaternion[] startRotations;

    void Start()
    {
        GameObject[] found = GameObject.FindGameObjectsWithTag("Ball");
        balls = new Rigidbody[found.Length];
        startPositions = new Vector3[found.Length];
        startRotations = new Quaternion[found.Length];

        for (int i = 0; i < found.Length; i++)
        {
            balls[i] = found[i].GetComponent<Rigidbody>();
            startPositions[i] = found[i].transform.position;
            startRotations[i] = found[i].transform.rotation;
        }
    }

    public void ReturnBalls()
    {
        player.Release();

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].linearVelocity = Vector3.zero;
            balls[i].angularVelocity = Vector3.zero;
            balls[i].transform.SetPositionAndRotation(startPositions[i], startRotations[i]);
        }
    }
    
}