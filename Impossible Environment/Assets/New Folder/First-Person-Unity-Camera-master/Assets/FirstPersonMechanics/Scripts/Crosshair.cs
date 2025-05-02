using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct CrosshairSize
{
    public Vector2 small;
    public Vector2 medium;
    public Vector2 big;
}

public class Crosshair : MonoBehaviour
{
    // Sprites
    [Header("Icons")]
    [SerializeField] private Sprite pickUp;     // HandIcon
    [SerializeField] private Sprite note;       // InspectIcon
    [SerializeField] private Sprite crosshair;  // Default crosshair

    // Image component
    private Image img;

    public CrosshairSize crosshairSize = new CrosshairSize();
    [SerializeField] private InteractionRayCaster _raycaster;

    void Start()
    {
        _raycaster = Camera.main.GetComponent<InteractionRayCaster>();

        _raycaster.onTargetChange += ChangeCrosshair;
        _raycaster.onNoTarget += ChangeCrosshair;

        img = gameObject.GetComponent<Image>();
    }

    private void OnDisable()
    {
        _raycaster.onTargetChange -= ChangeCrosshair;
        _raycaster.onNoTarget -= ChangeCrosshair;
    }

    void ChangeCrosshair()
    {
        if (_raycaster.Hit.collider != null)
        {
            string hitTag = _raycaster.Hit.collider.tag;
            Debug.Log("🎯 命中 Tag：" + hitTag);

            switch (hitTag)
            {
                case "pickUp":
                case "Interactable": // ✅ 共享 pickUp 样式
                    SetIcon(pickUp);
                    SetSize(crosshairSize.medium);
                    break;

                case "note":
                    SetIcon(note);
                    SetSize(crosshairSize.medium);
                    break;

                default:
                    SetIcon(crosshair);
                    SetSize(crosshairSize.small);
                    break;
            }
        }
        else
        {
            SetIcon(crosshair);
            SetSize(crosshairSize.small);
        }
    }

    void SetIcon(Sprite icon)
    {
        img.sprite = icon;
    }

    void SetSize(Vector2 size)
    {
        img.GetComponent<RectTransform>().sizeDelta = size;
    }
}