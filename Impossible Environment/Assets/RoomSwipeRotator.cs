using UnityEngine;

public class RoomSwipeRotator : MonoBehaviour, IManualTriggerable
{
    public Transform centralCube;
    public float rotationSpeed = 200f;
    public KeyCode keyLeft = KeyCode.A;
    public KeyCode keyRight = KeyCode.D;
    public KeyCode keyUp = KeyCode.W;
    public KeyCode keyDown = KeyCode.S;

    private bool activated = false;
    private bool isRotating = false;

    private Quaternion startRot, endRot;
    private float rotateTime = 0f;
    private Vector3 rotateAxis;
    private float rotateDir;

    public void Trigger()
    {
        Debug.Log("Triggered: " + gameObject.name);
        activated = true;
    }

    void Update()
    {
        if (!activated || isRotating) return;

        if (Input.GetKeyDown(keyLeft))
        {
            Rotate(Vector3.up, -1);
            Debug.Log("A-left(Y-90°)");
        }
        else if (Input.GetKeyDown(keyRight))
        {
            Rotate(Vector3.up, 1);
            Debug.Log("D-right(Y+90°)");
        }
        else if (Input.GetKeyDown(keyUp))
        {
            Rotate(Vector3.right, 1);
            Debug.Log("w-up(X+90°)");
        }
        else if (Input.GetKeyDown(keyDown))
        {
            Rotate(Vector3.right, -1);
            Debug.Log("S-down(X-90°)");
        }
    }

    void Rotate(Vector3 axis, float dir)
    {
        if (isRotating) return;
        startRot = transform.rotation;
        endRot = Quaternion.AngleAxis(90f * dir, axis) * startRot;
        rotateAxis = axis;
        rotateDir = dir;
        rotateTime = 0f;
        isRotating = true;
    }

    void FixedUpdate()
    {
        if (!isRotating) return;

        rotateTime += Time.fixedDeltaTime * rotationSpeed / 90f;
        transform.rotation = Quaternion.Slerp(startRot, endRot, rotateTime);
        if (centralCube) centralCube.rotation = Quaternion.Slerp(startRot, endRot, rotateTime);

        if (rotateTime >= 1f)
        {
            transform.rotation = endRot;
            if (centralCube) centralCube.rotation = endRot;
            isRotating = false;
            activated = false;
            Debug.Log("finish");
        }
    }
}