using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Camera))]
public class CaptureScreen : MonoBehaviour
{
    private int resWidth;
    private int resHeight;
    Camera camera;

    [HideInInspector]public bool takeHiResShot = false;

    private void Awake()
    {
        camera = GetComponent<Camera>();

       
    }

    private void Start()
    {

        resWidth = camera.targetTexture.width;
        resHeight = camera.targetTexture.height;

    }



    /*  public static string ScreenShotName(int width, int height)
      {
          return string.Format("{0}/" + GameManager.instance.picDirectory+"/screen_{1}x{2}_{3}.png",
                               Application.dataPath,
                               width, height,
                               System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
      }
      */


    private static Texture2D BytesToTexture2D(byte[] bytes, int width, int height)
    {
        Texture2D tex = new Texture2D(width, height);
        tex.LoadImage(bytes);
        return tex;
      
    }

    void AddImageToPhoneMemory(byte[] bytes, int width, int height)
    {
        GetComponentInParent<PhoneController>().AddScreenshot(BytesToTexture2D(bytes, width, height));
           
    }

    //must call this from a late update function
    public void TakePicture_2()
    {
       
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        camera.Render();
        RenderTexture.active = camera.targetTexture;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        byte[] bytes = screenShot.EncodeToPNG();

        AddImageToPhoneMemory(bytes, resWidth, resHeight);

    }

   
}
