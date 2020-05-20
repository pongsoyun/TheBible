using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static object _lock = new object();
    private static bool _isDestroy = false;

    public static T instance
    {
        get
        {
            if (_isDestroy)
            {
                Debug.LogWarning(string.Format("[Singleton] Instance '{0}' already destroyed.", typeof(T)));
                return null;
            }

            lock (_lock)
            {
                if(_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));
                    if(_instance == null)
                    {
                        var singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return _instance;
            }
        }

    }

    private void OnApplicationQuit()
    {
        _isDestroy = true;
    }

    private void OnDestroy()
    {
        _isDestroy = true;
    }
}
