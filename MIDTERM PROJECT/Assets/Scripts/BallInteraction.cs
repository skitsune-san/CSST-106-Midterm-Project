using UnityEngine;

public class BallInteraction : MonoBehaviour
{
    public Transform cam;
    public Transform holdPoint;
    public float reach = 3f;
    public float throwSpeed = 8f;

    Rigidbody held;
    Collider heldCollider;

    void Update()
    {
        if (Cursor.lockState != CursorLockMode.Locked) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (held != null) { Release(); return; }
            TryInteract();
        }

        if (held != null && Input.GetMouseButtonDown(0))
        {
            Rigidbody ball = held;
            Release();
            ball.AddForce(cam.forward * throwSpeed, ForceMode.VelocityChange);
        }
    }

    void TryInteract()
    {
        if (!Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, reach)) return;

        if (hit.collider.CompareTag("Ball"))
        {
            PickUp(hit.collider.attachedRigidbody);
            return;
        }

        WorldButton button = hit.collider.GetComponentInParent<WorldButton>();
        if (button != null) button.Press();
    }

    void PickUp(Rigidbody ball)
    {
        held = ball;
        heldCollider = ball.GetComponent<Collider>();
        held.linearVelocity = Vector3.zero;
        held.angularVelocity = Vector3.zero;
        held.isKinematic = true;
        heldCollider.enabled = false;
        held.transform.SetParent(holdPoint);
        held.transform.localPosition = Vector3.zero;
    }

    public void Release()
    {
        if (held == null) return;
        held.transform.SetParent(null);
        heldCollider.enabled = true;
        held.isKinematic = false;
        held = null;
    }
    public bool IsHolding => held != null;
}