using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceSceneSwitch1 : MonoBehaviour
{
    public GameObject[] hiddenDoors;     // 所有必须激活的门
    public string targetSceneName;       // 要切换到的场景名称

    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            CheckAndSwitchScene();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    private void CheckAndSwitchScene()
    {
        if (!playerInside) return;

        foreach (GameObject door in hiddenDoors)
        {
            if (!door.activeSelf)
            {
                Debug.Log("⛔ 还有门没激活");
                return;
            }
        }

        Debug.Log("✅ 所有门已激活，切换场景！");
        SceneManager.LoadScene(targetSceneName);
    }
}