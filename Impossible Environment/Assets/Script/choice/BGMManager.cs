using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;

    public AudioSource bgmSource;
    public AudioClip connectedScenesBGM; // A、B、C共用的音乐

    public string[] connectedScenes; // 让你在Inspector里填

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (IsInConnectedScenes(scene.name))
        {
            if (!bgmSource.isPlaying || bgmSource.clip != connectedScenesBGM)
            {
                bgmSource.clip = connectedScenesBGM;
                bgmSource.loop = true;
                bgmSource.Play();
            }
        }
        else
        {
            // 离开A/B/C场景，停止或换歌
            bgmSource.Stop();
        }
    }

    bool IsInConnectedScenes(string sceneName)
    {
        foreach (string name in connectedScenes)
        {
            if (sceneName == name) return true;
        }
        return false;
    }
}