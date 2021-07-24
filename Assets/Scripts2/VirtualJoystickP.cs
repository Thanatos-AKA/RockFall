using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystickP : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    public Vector2 delta;
    public RectTransform thumb;

    private Vector3 worldPoint;
    private Vector2 originalJoystickPoisition;

    private void Start() {
        thumb.gameObject.SetActive(false);
        originalJoystickPoisition = transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        thumb.gameObject.SetActive(true);

        RectTransformUtility.ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.enterEventCamera, out worldPoint);
        
        transform.position = worldPoint;
        thumb.position = worldPoint;
    }

    public void OnDrag(PointerEventData eventData) {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.enterEventCamera, out worldPoint);
        thumb.position = worldPoint;

        var size = GetComponent<RectTransform>().localPosition;

        delta = thumb.localPosition;
        delta.x /= size.x / 2.0f;
        delta.y /= size.y / 2.0f;
        delta.x = Mathf.Clamp(delta.x, -1.0f, 1.0f);
        delta.y = Mathf.Clamp(delta.y, -1.0f, 1.0f);
    }

    public void OnEndDrag(PointerEventData eventData) {
        thumb.gameObject.SetActive(false);
        delta = Vector2.zero;
    }
}
