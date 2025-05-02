using UnityEngine;

public class ADoorTrigger : MonoBehaviour, IManualTriggerable
{
    public GameObject[] hiddenDoors;              // 提前放好的门
    public GameObject cloneDoorPrefab;            // 用于后续克隆
    public Transform cloneSpawnPoint;             // 克隆门的生成点（可选）

    private int count = 0;

    public void Trigger()
    {
        if (count < hiddenDoors.Length)
        {
            // 🚪 激活隐藏门
            hiddenDoors[count].SetActive(true);
            Debug.Log($"✅ 激活第 {count + 1} 个门");
        }
        else
        {
            // 🧱 全部激活完了，开始克隆门
            Vector3 spawnPos = cloneSpawnPoint ? cloneSpawnPoint.position : transform.position + transform.forward * 2;
            Quaternion rot = cloneSpawnPoint ? cloneSpawnPoint.rotation : Quaternion.identity;

            GameObject clone = Instantiate(cloneDoorPrefab, spawnPos, rot);
            Debug.Log($"🌀 生成克隆门 at {spawnPos}");
        }

        count++;
    }
}