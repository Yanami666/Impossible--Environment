using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // 获取当前活动场景的名称
            string currentSceneName = SceneManager.GetActiveScene().name;

            // 重新加载该场景
            SceneManager.LoadScene(currentSceneName);
        }
    }
}