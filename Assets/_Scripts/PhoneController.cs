using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public enum PhoneState
    {
       ScreenButtom,
       ScreenCenter
    }

    public enum Apps
    {
        None,
        Camera,
        Whatsapp,
        PhoneGallery

    }


  
    [SerializeField] private Transform _phone;
 

    public PhoneState currentState { get; private set; }
    public Apps currentApp { get; private set; }


    [SerializeField]private Transform _shownTransform;
    [SerializeField]private Transform _halfShownTransform;
  //  [SerializeField] private Transform _hiddenTransform;
    [SerializeField] private MeshRenderer phoneScreenRenderer;


    private CaptureScreen _phoneCamera;
    public List<Texture2D> screenshots { get; private set; }

    public bool phoneEnabled { get; private set; }



    public AppController[] apps;

    public WebcamController webCam;
    public WhatsAppController whatsApp;
    public PhotoGallery gallery;


   


    private void Awake()
    {
        _phoneCamera = _phone.GetComponentInChildren<CaptureScreen>();

        apps = GetComponentsInChildren<AppController>();
    }
    private void Start()
    {
        screenshots = new List<Texture2D>();
    }

   
    public void AddScreenshot(Texture2D image)
    {
        screenshots.Add(image);
        Debug.Log("added image number: " + screenshots.Count);
    }

    public void ShowPhone()
    {
        //  _phone.transform.position = _shownTransform.position;
        _phone.gameObject.SetActive(true);
        phoneEnabled = true;
    }

    public void HidePhone()
    {
        // _phone.transform.position = _hiddenTransform.position;
        phoneEnabled = false;
        _phone.gameObject.SetActive(false);
        
    }

    public void HalfShowPhone()
    {
       // if (phoneEnabled)
      //  {
            _phone.transform.position = _halfShownTransform.position;
            currentState = PhoneState.ScreenButtom;
       // }
    }

    public void RecenterPhone()
    {
      //  if (phoneEnabled)
      //  {
            _phone.transform.position = _shownTransform.position;
            currentState = PhoneState.ScreenCenter;
      //  }

    }

   /* public void DeactivateCamera()
    {

        if (currentApp == Apps.Camera)
        {
            var homeScreen = Resources.Load<Texture>("home_screen");
            phoneScreenRenderer.material.mainTexture = homeScreen;
            currentApp = Apps.None;
        }

    }

    public void ActivateCamera()
    {
        if(currentApp == Apps.Whatsapp)
            deac
        if (phoneEnabled)
        {
            //activate camera (show render video)
            //change material albedo of phone screen to render texture
            var renderTexture = Resources.Load<RenderTexture>("phone_camera");
            phoneScreenRenderer.material.mainTexture = renderTexture;
            cameraEnabled = true;
        }
        
    }
    */

 

    void CloseAllApps()
    {
        foreach (AppController _app in apps)
        {
            _app._canvasGroup.alpha = 0;
        }

        currentApp = Apps.None;
    }


    public void TakePicture()
    {
        if (currentApp == Apps.Camera)
            _phoneCamera.TakePicture_2();
    }

    public void ActivateCamera(bool activate = true)
    {
        if (activate)
        {
            CloseAllApps();

            //activate
            webCam._canvasGroup.alpha = 1;
            currentApp = Apps.Camera;
        }
        else
        {
            if (currentApp == Apps.Camera)
            {
                CloseAllApps();
            }
            
        }
    }

    public void ActivateWhatsapp(bool activate = true)
    {
        if (activate)
        {
            CloseAllApps();

            //activate
            whatsApp._canvasGroup.alpha = 1;
            currentApp = Apps.Whatsapp;
        }
        else
        {
            if (currentApp == Apps.Whatsapp)
                CloseAllApps();
        }
    }


    
    private void DisplayImage(int imageIndex)
    {
        if (currentApp == Apps.PhoneGallery && (imageIndex < screenshots.Count))
        { 
                phoneScreenRenderer.material.mainTexture = screenshots[imageIndex];
        }
    }

    int index;
    private void ScrollPhotoGallery()
    {

    }

    private void Update()
    {
        if (currentApp == Apps.PhoneGallery)
            ScrollPhotoGallery();
    }

    public void OpenPhotoGallery(bool activate = true)
    {
        if (activate)
        {
            CloseAllApps();

            //activate
            gallery._canvasGroup.alpha = 1;
            currentApp = Apps.PhoneGallery;
        }
        else
        {
            if (currentApp == Apps.PhoneGallery)
                CloseAllApps();
        }
    }
}
