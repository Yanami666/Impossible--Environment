using UnityEngine;

public class BlueTrapRaycastActivator : MonoBehaviour
{
    [SerializeField] private GameObject trapToDrop; // 被激活的掉落物
    [SerializeField] private float rayDistance = 3f; // 检测距离
    [SerializeField] private KeyCode triggerKey = KeyCode.Mouse0; // 鼠标左键

    private Camera cam;
    private bool used = false;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
            {
                if (!used && hit.collider.gameObject == gameObject)
                {
                    if (trapToDrop != null)
                    {
                        trapToDrop.SetActive(true); // 激活掉落物
                        used = true;
                        Debug.Log("🔵 Trap activated by blue door button");
                    }
                }
            }
        }
    }
}