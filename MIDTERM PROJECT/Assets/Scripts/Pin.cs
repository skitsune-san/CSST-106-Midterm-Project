using UnityEngine;

public class Pin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0.12f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
