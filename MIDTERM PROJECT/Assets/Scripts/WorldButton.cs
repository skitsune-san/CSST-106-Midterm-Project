using UnityEngine;
using UnityEngine.Events;

public class WorldButton : MonoBehaviour
{
    public UnityEvent onPressed;
    public void Press() { onPressed.Invoke(); }
}