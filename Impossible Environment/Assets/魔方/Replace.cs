using UnityEngine;

public class ReplaceOnClick : MonoBehaviour
{
    [Header("替换用的球体 Prefab")]
    public GameObject replacementPrefab;

    void OnMouseDown()
    {
        // 在当前位置/朝向实例化替换球
        Instantiate(replacementPrefab, transform.position, transform.rotation);

        // 销毁当前球体，避免同时存在
        Destroy(gameObject);
    }
}
