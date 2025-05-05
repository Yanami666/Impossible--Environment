using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public float pickupRange = 3f;              // 可拾取的最大距离
    public float holdDistance = 2f;             // 拖动物体时离摄像机的距离
    public float moveSpeed = 10f;               // 拖动时的平滑速度
    public LayerMask pickupLayer;               // 可拾取物体的 Layer

    private Camera cam;
    private GameObject heldObject;
    private Rigidbody heldRb;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPickUp();
        }

        if (Input.GetMouseButtonUp(0))
        {
            DropObject();
        }

        if (heldObject != null)
        {
            MoveObject();
        }
    }

    void TryPickUp()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, pickupRange))
        {
            if (hit.collider.CompareTag("pickUp"))
            {
                heldObject = hit.collider.gameObject;
                heldRb = heldObject.GetComponent<Rigidbody>();

                if (heldRb != null)
                {
                    heldRb.useGravity = false;
                    heldRb.freezeRotation = true;
                }
            }
        }
    }

    void MoveObject()
    {
        Vector3 targetPos = cam.transform.position + cam.transform.forward * holdDistance;
        Vector3 moveDirection = targetPos - heldObject.transform.position;
        heldRb.linearVelocity = moveDirection * moveSpeed;
    }

    void DropObject()
    {
        if (heldRb != null)
        {
            heldRb.useGravity = true;
            heldRb.freezeRotation = false;
            heldRb.linearVelocity = Vector3.zero;
        }

        heldObject = null;
        heldRb = null;
    }
}