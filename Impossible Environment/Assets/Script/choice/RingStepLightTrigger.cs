using UnityEngine;

public class RingStepLightTrigger : MonoBehaviour
{
    [SerializeField] private LightCycleController lightController;

    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!playerInside && other.CompareTag("Player"))
        {
            lightController.TrySwitchLight();  // 切换灯光
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerInside && other.CompareTag("Player"))
        {
            lightController.AllowSwitchAgain(); // 允许再次触发
            playerInside = false;
        }
    }
}