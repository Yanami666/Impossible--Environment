using UnityEngine;

public class RotationStopTrigger : MonoBehaviour
{
    private Rotator rotator;

    void Start()
    {
        rotator = GetComponentInParent<Rotator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("pickUp"))
        {
            rotator.isRotating = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("pickUp"))
        {
            rotator.isRotating = true;
        }
    }
}