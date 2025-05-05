using System.Collections.Generic;
using UnityEngine;

public class RedButtonTrigger : MonoBehaviour
{
    [SerializeField] private GameObject targetStair;         // 该按钮控制的楼梯
    [SerializeField] private List<string> validTags;         // 允许触发的Tag（例如Player、pickUp）

    private int triggerCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (validTags.Contains(other.tag))
        {
            triggerCount++;
            targetStair.SetActive(true);
            Debug.Log("🛠️ 进入触发器，楼梯激活");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (validTags.Contains(other.tag))
        {
            triggerCount = Mathf.Max(0, triggerCount - 1);
            if (triggerCount == 0)
            {
                targetStair.SetActive(false);
                Debug.Log("🔚 离开触发器，楼梯隐藏");
            }
        }
    }
}