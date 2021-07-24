//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

//public class VirtualJoystick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
//    public RectTransform thumb;

//    private Vector2 originalPosition;

//    public Vector2 delta;

//    void Start() {
//        originalPosition = this.GetComponent<RectTransform>().localPosition;

//        thumb.gameObject.SetActive(false);

//        delta = Vector2.zero;
//    }

//    public void OnBeginDrag(PointerEventData eventData) {
//        thumb.gameObject.SetActive(true);

//        Vector3 worldPoint = new Vector3();
//        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform, eventData.position, eventData.enterEventCamera, out worldPoint);

//        GetComponent<RectTransform>().position = worldPoint;
//        thumb.position = worldPoint;
//    }

//    public void OnDrag(PointerEventData eventData) {
//        Vector3 worldPoint = new Vector3();
//        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform, eventData.position, eventData.enterEventCamera, out worldPoint);

//        thumb.position = worldPoint;

//        var size = this.GetComponent<RectTransform>().rect.size;
//        delta = thumb.localPosition;
//        delta.x /= size.x / 2.0f;
//        delta.y /= size.y / 2.0f;
//        delta.x = Mathf.Clamp(delta.x, -1.0f, 1.0f);
//        delta.y = Mathf.Clamp(delta.y, -1.0f, 1.0f);
//    }

//    public void OnEndDrag(PointerEventData eventData) {
//        this.GetComponent<RectTransform>().localPosition = originalPosition;

//        delta = Vector2.zero;

//        thumb.gameObject.SetActive(false);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    public RectTransform thumb;

    private Vector2 originalJoystickPosition;
    private Vector3 worldPoint;

    public Vector2 delta;
    private void Start() {
        originalJoystickPosition = this.transform.localPosition;

        delta = Vector2.zero;

        thumb.gameObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData) {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.GetComponent<RectTransform>(), eventData.position, eventData.enterEventCamera, out worldPoint);
        this.transform.position = worldPoint;

        thumb.gameObject.SetActive(true);
        thumb.position = worldPoint;
    }

    public void OnDrag(PointerEventData eventData) {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.GetComponent<RectTransform>(), eventData.position, eventData.enterEventCamera, out worldPoint);
        thumb.position = worldPoint;

        var size = this.GetComponent<RectTransform>().rect.size;

        delta = thumb.localPosition;
        delta.x /= size.x / 2.0f;
        delta.y /= size.y / 2.0f;
        delta.x = Mathf.Clamp(delta.x, -1.0f, 1.0f);
        delta.y = Mathf.Clamp(delta.y, -1.0f, 1.0f);
    }

    public void OnEndDrag(PointerEventData eventData) {
        this.GetComponent<RectTransform>().localPosition = originalJoystickPosition;

        delta = Vector2.zero;
        thumb.gameObject.SetActive(false);
    }
}
