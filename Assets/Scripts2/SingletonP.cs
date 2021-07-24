using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonP<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T instance {
        get {
            if(_instance != null) {
                return _instance;
            }
            else {
                _instance = FindObjectOfType<T>();
                return _instance;
            }
        }
    }
}
