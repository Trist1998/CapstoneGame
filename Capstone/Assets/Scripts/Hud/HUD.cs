using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    WorldObject obj;
    [SerializeField]
    private Image health;
    [SerializeField]
    private Image energy;
    [SerializeField]
    private Image star;


    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<WorldObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // health.fillAmount; must be between 0 and 1
    }

   

    

    
}
