//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Indicator : MonoBehaviour {
//    public Transform target;

//    public Transform showDistanceTo;

//    public Text distanceLable;

//    public int margin = 50;

//    public Color color {
//        set {
//            GetComponent<Image>().color = value;
//        }
//        get {
//            return GetComponent<Image>().color;
//        }
//    }

//    private void Start() {
//        distanceLable.enabled = false;

//        GetComponent<Image>().enabled = false;
//    }

//    private void Update() {
//        if(target == null) {
//            Destroy(gameObject);
//            return;
//        }

//        if(showDistanceTo == null) {
//            distanceLable.enabled = false;
//        }
//        else {
//            distanceLable.enabled = true;

//            var distance = (int)Vector3.Magnitude(showDistanceTo.position - target.position);

//            distanceLable.text = distance.ToString() + " M";
//        }

//        this.GetComponent<Image>().enabled = true;
//        var screenPoint = Camera.main.WorldToScreenPoint(target.position);
//        if(screenPoint.z < 0) {
//            screenPoint.z = 0;
//            screenPoint = screenPoint.normalized;
//            screenPoint.x += Mathf.Infinity;
//        }
//        screenPoint.x = Mathf.Clamp(screenPoint.x, margin, Screen.width - margin);
//        screenPoint.y = Mathf.Clamp(screenPoint.y, margin, Screen.height - margin);

//        var localPosition = new Vector2();
//        RectTransformUtility.ScreenPointToLocalPointInRectangle(this.transform.parent.GetComponent<RectTransform>(), screenPoint, Camera.main, out localPosition);
//        GetComponent<RectTransform>().localPosition = localPosition;
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour {
    public Transform target;
    public Transform showDistanceTo;
    public Text distanceLable;
    private float margin = 50.0f;

    public Color color {
        get {
            return GetComponent<Image>().color;
        }
        set {
            GetComponent<Image>().color = value;
        }
    }

    private void Start() {
        distanceLable.enabled = false;
        GetComponent<Image>().enabled = false;
    }

    private void Update() {
        if(target == null) {
            Destroy(gameObject);
            return;
        }

        if(showDistanceTo == null) {
            distanceLable.enabled = false;
        }
        else {
            distanceLable.enabled = true;
            var distance = (int)Vector3.Magnitude(showDistanceTo.position - target.position);
            distanceLable.text = distance.ToString() + " M";
        }

        GetComponent<Image>().enabled = true;

        var screenPoint = Camera.main.WorldToScreenPoint(target.position);

        if(screenPoint.z < 0.0f) {
            screenPoint.z = 0.0f;
            screenPoint = screenPoint.normalized;
            screenPoint.x *= Mathf.Infinity;
        }

        screenPoint.x = Mathf.Clamp(screenPoint.x, margin, Screen.width - margin);
        screenPoint.y = Mathf.Clamp(screenPoint.y, margin, Screen.height - margin);

        var localPosition = new Vector2();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), screenPoint, Camera.main, out localPosition);
        transform.localPosition = localPosition;
        transform.localPosition = localPosition;
    }
}
