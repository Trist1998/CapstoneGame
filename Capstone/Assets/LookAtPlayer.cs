using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject lookAt;

    /*
     * Used to smoothly look at the lookAt target
     */
    void Update()
    {
        if (lookAt != null)
        {
            GameObject obj = gameObject;
            Quaternion newRotation = Quaternion.LookRotation (obj.transform.position - lookAt.transform.position,obj.transform.up);
            newRotation.x = 0;
            newRotation.z = 0;
            transform.rotation = Quaternion.Lerp (transform.rotation,newRotation,Time.deltaTime * 10);
        }
    }
}
