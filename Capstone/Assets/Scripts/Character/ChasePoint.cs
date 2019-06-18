using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePoint : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.localPosition += new Vector3(0, 5, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localPosition += new Vector3(0, -5, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localPosition += new Vector3(0, 0, 5) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localPosition += new Vector3(0, 0, -5) * Time.deltaTime;
        }
    }
}
