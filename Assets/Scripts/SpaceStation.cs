using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : MonoBehaviour
{
    private void Start() {
        //IndicatorManager aaa = FindObjectOfType<IndicatorManager>();
        //aaa.AddIndicator(gameObject, Color.green);

        IndicatorManager.instance.AddIndicator(gameObject, Color.green);
    }
}
