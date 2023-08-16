using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemObjectDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool IsDragging { get; private set; }

    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Image[] imageComponents;

    private Camera cameraCache;

    private Vector3 beginDragPosition;

    private void Awake()
    {
        cameraCache = Camera.main;

        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        imageComponents = GetComponentsInChildren<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvas = GetComponentInParent<Canvas>();

        beginDragPosition = transform.position;

        canvas.sortingOrder = 2;
        IsDragging = true;
        canvasGroup.blocksRaycasts = false;
        DisableImageComponentsMaskable();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mouseWordPosition = cameraCache.ScreenToWorldPoint(eventData.position);
        mouseWordPosition.z = 0;

        transform.position = mouseWordPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvas.sortingOrder = 1;
        IsDragging = false;
        canvasGroup.blocksRaycasts = true;
        EnableImageComponentsMaskable();

        transform.position = beginDragPosition;
    }

    private void EnableImageComponentsMaskable()
    {
        foreach (Image image in imageComponents)
        {
            image.maskable = true;
        }
    }

    private void DisableImageComponentsMaskable()
    {
        foreach (Image image in imageComponents)
        {
            image.maskable = false;
        }
    }
}