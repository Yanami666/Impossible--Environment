using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralSceneChanger : MonoBehaviour
{
    [Header("Scene Settings")]
    [Tooltip("要切换到的场景名字")]
    public string sceneToLoad;

    [Tooltip("碰到触发器后延迟几秒切换场景")]
    public float delayBeforeLoad = 0f;

    [Header("Trigger Tag Settings")]
    [Tooltip("只有带有这个标签的对象才能触发切换")]
    public string triggeringTag = "Player";

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag(triggeringTag))
        {
            hasTriggered = true;
            if (delayBeforeLoad > 0f)
            {
                Invoke("LoadScene", delayBeforeLoad);
            }
            else
            {
                LoadScene();
            }
        }
    }

    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene name is not set in GeneralSceneChanger.");
        }
    }
}
