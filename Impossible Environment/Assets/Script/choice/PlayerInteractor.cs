using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public float interactRange = 3f;
    public KeyCode interactKey = KeyCode.Mouse0;

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.red); // ✅ 画射线（Scene视图中可见）

        if (Input.GetKeyDown(interactKey))
        {
            Debug.Log("🖱️ Mouse0 被按下");

            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                Debug.Log("🎯 Raycast 命中了物体: " + hit.collider.name);

                if (hit.collider.CompareTag("Interactable"))
                {
                    Debug.Log("✅ 命中了 Interactable 物体");

                    MonoBehaviour[] scripts = hit.collider.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour script in scripts)
                    {
                        if (script is IManualTriggerable)
                        {
                            Debug.Log("🟢 调用了 Trigger() 方法");
                            ((IManualTriggerable)script).Trigger();
                        }
                    }
                }
                else
                {
                    Debug.Log("⚠️ 命中了物体，但 Tag 不是 Interactable");
                }
            }
            else
            {
                Debug.Log("❌ Raycast 没有打中任何物体");
            }
        }
    }
}