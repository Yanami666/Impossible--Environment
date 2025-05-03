using UnityEngine;

public class ADoorTrigger : MonoBehaviour, IManualTriggerable
{
    public GameObject[] hiddenDoors;  // 提前放好的门

    private int count = 0;

    public void Trigger()
    {
        if (count < hiddenDoors.Length)
        {
            hiddenDoors[count].SetActive(true);
            Debug.Log($"✅ 激活第 {count + 1} 个门");
            count++;
        }
        else
        {
            Debug.Log("所有门都已激活");
        }
    }
}