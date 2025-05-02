using UnityEngine;

public class TestInteract : MonoBehaviour
{
    void Interacting()
    {
        Debug.Log("你成功与我互动了！");
    }

    void Hovering(Vector3 point)
    {
        Debug.Log("鼠标看着我啦！");
    }
}