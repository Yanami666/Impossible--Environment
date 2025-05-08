using UnityEngine;

public class LightCycleController : MonoBehaviour
{
    public GameObject[] doorLights;   // 三个灯光对象（比如挂在门上）
    private int currentIndex = 0;
    private bool canSwitch = true;

    void Start()
    {
        // 初始化随机一个灯亮
        currentIndex = Random.Range(0, doorLights.Length);
        ActivateOnly(currentIndex);
    }

    public void TrySwitchLight()
    {
        if (!canSwitch) return;

        currentIndex = (currentIndex + 1) % doorLights.Length;
        ActivateOnly(currentIndex);
        canSwitch = false;
    }

    public void AllowSwitchAgain()
    {
        canSwitch = true;
    }

    void ActivateOnly(int index)
    {
        for (int i = 0; i < doorLights.Length; i++)
        {
            doorLights[i].SetActive(i == index);
        }
        Debug.Log("💡 Switched to door light index: " + index);
    }

    public int GetActiveIndex()
    {
        return currentIndex;
    }
}