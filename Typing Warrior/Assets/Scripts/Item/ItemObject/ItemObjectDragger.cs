using UnityEngine;
using UnityEngine.EventSystems;

public class ItemObjectDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool IsDragging { get; private set; }

    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private Camera cameraCache;

    private void Awake()
    {
        cameraCache = Camera.main;

        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        IsDragging = true;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mouseWordPosition = cameraCache.ScreenToWorldPoint(eventData.position);
        mouseWordPosition.z = 0;

        transform.position = mouseWordPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        IsDragging = false;
        canvasGroup.blocksRaycasts = true;
    }
}