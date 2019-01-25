using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        SwichAndCapture.instance.CanCapture = true;
        Debug.Log(other);
       if(other.tag == "Enemy1")
        {
            SwichAndCapture.instance.index = 0;

        }

        if (other.tag == "Enemy2")
        {
            SwichAndCapture.instance.index = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SwichAndCapture.instance.CanCapture = false;
    }
}
