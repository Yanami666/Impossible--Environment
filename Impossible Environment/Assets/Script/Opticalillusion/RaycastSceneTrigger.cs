using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastSceneTrigger : MonoBehaviour
{
    public float interactRange = 5f;              
    public string requiredTag = "Interactable";   
    public string sceneToLoad;                  

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                if (hit.collider.CompareTag(requiredTag))
                {
                    Debug.Log("🎯 Interacted with " + hit.collider.name + ", loading scene...");
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
        }
    }
}