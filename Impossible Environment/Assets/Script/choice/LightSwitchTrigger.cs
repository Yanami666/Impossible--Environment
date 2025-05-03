using UnityEngine;
using System.Collections.Generic;

public class LightSwitchTrigger : MonoBehaviour
{
    [Header("可切换的灯")]
    [SerializeField] private List<Light> targetLights = new List<Light>();

    [Header("可切换的普通物体")]
    [SerializeField] private List<GameObject> targetObjects = new List<GameObject>();

    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private KeyCode interactKey = KeyCode.Mouse0;

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    ToggleLights();
                    ToggleObjects();
                    Debug.Log("🎛️ Triggered switch!");
                }
            }
        }
    }

    void ToggleLights()
    {
        foreach (Light light in targetLights)
        {
            if (light != null)
            {
                light.enabled = !light.enabled;
            }
        }
    }

    void ToggleObjects()
    {
        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }
    }
}