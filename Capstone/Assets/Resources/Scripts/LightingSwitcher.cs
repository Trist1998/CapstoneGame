using UnityEngine;
using System;

public class LightingSwitcher : MonoBehaviour
{
    [Serializable]
    public class SkyboxLightingPair
    {
        public Material skyBoxMaterial;
        public GameObject lightingGameObject;
        public GameObject camera;
        public Vector3 sunEulerAngles;


        public void ActivateTreatment(Transform sunTransform)
        {
            lightingGameObject.SetActive(true);
            RenderSettings.skybox = skyBoxMaterial;
            camera.SetActive(true);
            sunTransform.localEulerAngles = sunEulerAngles;
        }


        public void DeactivateTreatment(Transform sunTransform)
        {
            if(camera != null)
                camera.SetActive(false);
            lightingGameObject.SetActive(false);
            sunTransform.localEulerAngles = sunEulerAngles;
        }
    }


    public int startingIndex;
    public Transform sunTransform;
    public SkyboxLightingPair[] treatments;


    private int currentIndex;


    private void Start()
    {
        for (int i = 0; i < treatments.Length; i++)
        {
            treatments[i].DeactivateTreatment(sunTransform);
        }

        currentIndex = startingIndex;

        treatments[currentIndex].ActivateTreatment(sunTransform);
    }


    public void CycleTreatments()
    {
        treatments[currentIndex].DeactivateTreatment(sunTransform);

        currentIndex = (treatments.Length + currentIndex + 1) % treatments.Length;

        treatments[currentIndex].ActivateTreatment(sunTransform);
    }
}
