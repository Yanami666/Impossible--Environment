using UnityEngine;

public class ChoiceStopJump : MonoBehaviour
{
    private FPMovementController playerMovement;

    void Start()
    {
        playerMovement = GetComponent<FPMovementController>();

        if (playerMovement != null)
        {
            playerMovement.SetJumpingDisabled(true);
            Debug.Log("🚫 Jump disabled by ChoiceStopJump.");
        }
        else
        {
            Debug.LogWarning("❌ No FPMovementController found on this object.");
        }
    }
}