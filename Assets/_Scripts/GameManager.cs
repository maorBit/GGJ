using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // public string picDirectory = "screenShoots";

    [SerializeField] private PhoneController _phoneController;


    [SerializeField] private KeyCode phoneToggle;
    [SerializeField] private KeyCode halfShowPhone;
    [SerializeField] private KeyCode togglePhoneCamera;
    [SerializeField] private KeyCode toggleWhatsApp;
    [SerializeField] private KeyCode takePicture;
    [SerializeField] private KeyCode togglePhotoGallery;

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
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



    private void Start()
    {
        //hide phone
        _phoneController.HidePhone();
    }

    
    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            Debug.Log("scroll = " + scroll);
            //_phoneController.Scr
        }


        //togglePhotoGallery
        if (Input.GetKeyDown(togglePhotoGallery))
        {
            _phoneController.OpenPhotoGallery(_phoneController.currentApp != PhoneController.Apps.PhoneGallery);
        }

            //public KeyCode phoneToggle;
        if (Input.GetKeyDown(phoneToggle))
        {
            if (!_phoneController.phoneEnabled)
                _phoneController.ShowPhone();
            else
                _phoneController.HidePhone();
        }


        // public KeyCode halfShowPhone;
        if (Input.GetKeyDown(halfShowPhone))
        {
            if (_phoneController.currentState == PhoneController.PhoneState.ScreenButtom)
                _phoneController.RecenterPhone();
            else
                _phoneController.HalfShowPhone();
        }
            

        // public KeyCode togglephoneCamera;
        if (Input.GetKeyDown(togglePhoneCamera))
        {

            _phoneController.ActivateCamera(_phoneController.currentApp != PhoneController.Apps.Camera);


        }

        // public KeyCode toggleWhatsApp;
        if (Input.GetKeyDown(toggleWhatsApp))
        {

            _phoneController.ActivateWhatsapp(_phoneController.currentApp != PhoneController.Apps.Whatsapp);


        }

        
           
    }

    private void LateUpdate()
    {
        // public KeyCode takeScreenShot;
        if (Input.GetKeyDown(takePicture))
            _phoneController.TakePicture();

    }
}





