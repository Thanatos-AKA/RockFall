using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTargetP : MonoBehaviour
{
    public Sprite mySprite;

    private void Start() {
        IndicatorManager.instance.AddIndicator(gameObject, Color.yellow, mySprite);
    }
}
