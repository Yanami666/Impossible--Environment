using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;

    [Header("BGM 设置")]
    public AudioSource bgmSource;
    public AudioClip connectedScenesBGM;

    [Header("哪些场景可以播放 BGM")]
    public string[] connectedScenes; // 你可以在 Inspector 面板里填

    void Awake()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (!IsInConnectedScenes(currentScene))
        {
            Destroy(gameObject); // 不在目标场景，直接销毁
            return;
        }

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (!bgmSource.isPlaying)
            {
                bgmSource.clip = connectedScenesBGM;
                bgmSource.loop = true;
                bgmSource.Play();
            }

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // 如果已有BGM，新的删掉
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!IsInConnectedScenes(scene.name))
        {
            if (bgmSource.isPlaying) bgmSource.Stop();
            Destroy(gameObject);
            instance = null;
        }
    }

    bool IsInConnectedScenes(string sceneName)
    {
        foreach (string name in connectedScenes)
        {
            if (sceneName == name)
                return true;
        }
        return false;
    }
}