using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePortal : MonoBehaviour
{
    public int doorIndex; // 该门对应的灯索引
    public string sceneToLoad;
    public LightCycleController lightController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && lightController.GetActiveIndex() == doorIndex)
        {
            Debug.Log("🚪 进入正确门，加载场景: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}