using UnityEngine;

public class OpticalSceneChange : MonoBehaviour
{
    [Header("Teleport Settings")]
    [Tooltip("玩家将要被传送到的位置")]
    public Vector3 teleportPosition = new Vector3(-364.53f, -355.49f, -18.35f);

    [Tooltip("碰到后延迟多少秒再传送")]
    public float delayBeforeTeleport = 0f;

    [Tooltip("触发传送的对象的Tag")]
    public string triggeringTag = "Player";

    private bool hasTriggered = false;
    private GameObject targetPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag(triggeringTag))
        {
            hasTriggered = true;
            targetPlayer = other.gameObject;

            if (delayBeforeTeleport > 0f)
            {
                Invoke("TeleportPlayer", delayBeforeTeleport);
            }
            else
            {
                TeleportPlayer();
            }
        }
    }

    private void TeleportPlayer()
    {
        if (targetPlayer != null)
        {
            targetPlayer.transform.position = teleportPosition;
        }
    }
}
