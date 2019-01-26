using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildController : MonoBehaviour
{
    private static ChildController _instance;
    public static ChildController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ChildController>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
  
    }
}
