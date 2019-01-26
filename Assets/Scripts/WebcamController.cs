using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebcamController : AppController
{
    public CaptureScreen mainCam;
    public Button camButton;


    private void Awake()
    {
        mainCam = FindObjectOfType<CaptureScreen>();
    }
    private void OnEnable()
    {
        camButton.onClick.AddListener(TakeShot);
    }

    private void OnDisable()
    {
        camButton.onClick.RemoveAllListeners();
    }

    void TakeShot()
    {
        mainCam.TakePicture_2();
    }
}
