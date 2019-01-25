using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwichAndCapture : MonoBehaviour {

    public static SwichAndCapture instance;

    [System.Serializable]
    public class enemy
    {
        public GameObject enemy1;
        public GameObject enemy2;
    }
    public enemy[] EnemiesList;

    [SerializeField] private Image flashScreen;
    [SerializeField] private GameObject MainCamera;
    public Camera CameraPRefab;
    public  int index;
    public  bool CanCapture = false;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update ()
    {
        if(CanCapture)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // lashScreen.enabled = true;   
                TakePicAndSwitch();
                // enemyAnimator2.PlayInFixedTime()
                Invoke("ResetScreen", 0.2f);

            }
        }	
    }

    private void TakePicAndSwitch()
    {
        Debug.Log(index);
        flashScreen.enabled = true;
        EnemiesList[index].enemy1.SetActive(false);
        Camera newCamera = Instantiate(CameraPRefab, MainCamera.transform.position, MainCamera.transform.rotation) as Camera;
        newCamera.gameObject.SetActive(false);
        EnemiesList[index].enemy2.SetActive(true);
    }

    private void ResetScreen()
    {
        flashScreen.enabled = false;
    }
}
