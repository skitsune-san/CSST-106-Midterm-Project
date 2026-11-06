using TMPro;
using UnityEngine;

public class InteractionHighlighter : MonoBehaviour
{
    public Transform cam;
    public BallInteraction player;
    public TMP_Text promptLabel;
    public float reach = 3f;

    Highlightable current;

    void Update()
    {
        Highlightable target = null;

        if (Cursor.lockState == CursorLockMode.Locked &&
            Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, reach))
        {
            Highlightable h = hit.collider.GetComponentInParent<Highlightable>();
            if (h != null && !(h.hideWhileHolding && player.IsHolding))
                target = h;
        }

        if (target != current)
        {
            if (current != null) current.SetHighlight(false);
            current = target;
            if (current != null) current.SetHighlight(true);
        }

       if (promptLabel != null)
        {
            if (current != null && current.promptText != "")
                promptLabel.text = current.promptText;
            else if (player.IsHolding)
                promptLabel.text = holdHint;
            else
                promptLabel.text = "";
        }
    }
    public string holdHint = "Throw (Left Click)\n or Drop (E)";
}