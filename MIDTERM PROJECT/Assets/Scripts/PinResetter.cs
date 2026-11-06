using UnityEngine;

public class PinResetter : MonoBehaviour
{
    public Transform pinsParent;

    Rigidbody[] pins;
    Vector3[] startPositions;
    Quaternion[] startRotations;

    void Start()
    {
        pins = pinsParent.GetComponentsInChildren<Rigidbody>();
        startPositions = new Vector3[pins.Length];
        startRotations = new Quaternion[pins.Length];

        for (int i = 0; i < pins.Length; i++)
        {
            startPositions[i] = pins[i].transform.position;
            startRotations[i] = pins[i].transform.rotation;
        }
    }

    public void ResetPins()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].linearVelocity = Vector3.zero;
            pins[i].angularVelocity = Vector3.zero;
            pins[i].transform.SetPositionAndRotation(startPositions[i], startRotations[i]);
        }
    }
}