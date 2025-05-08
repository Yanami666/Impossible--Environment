using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 20f;
    public bool rotateClockwise = true;
    [HideInInspector] public bool isRotating = true;

    void Update()
    {
        if (!isRotating) return;

        float direction = rotateClockwise ? -1f : 1f;
        transform.Rotate(0f, 0f, direction * speed * Time.deltaTime);
    }
}