using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    // Public Variables
    public bool isLit;
    public GameObject TorchLight;
    public GameObject MainFlame;
    public GameObject BaseFlame;
    public GameObject Etincelles;
    public GameObject Fumee;
    public float MaxLightIntensity;
    public float IntensityLight;

    // Use this for initialization
    void Start ()
    {
        TorchLight.GetComponent<Light>().intensity = IntensityLight;
        MainFlame.GetComponent<ParticleSystem>().emissionRate = IntensityLight * 20f;
        BaseFlame.GetComponent<ParticleSystem>().emissionRate = IntensityLight * 15f;
        Etincelles.GetComponent<ParticleSystem>().emissionRate = IntensityLight * 7f;
        Fumee.GetComponent<ParticleSystem>().emissionRate = IntensityLight * 12f;
        if (isLit == false)
        {
            Extinguish();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isLit == true)
        {
            if (IntensityLight < 0)
            {
                IntensityLight = 0;
            }
            if (IntensityLight > MaxLightIntensity)
            {
                IntensityLight = MaxLightIntensity;
            }

            TorchLight.GetComponent<Light>().intensity = IntensityLight / 2f + Mathf.Lerp(IntensityLight - 0.1f, IntensityLight + 0.1f, Mathf.Cos(Time.time * 30));

            TorchLight.GetComponent<Light>().color = new Color(Mathf.Min(IntensityLight / 1.5f, 1f), Mathf.Min(IntensityLight / 2f, 1f), 0f);
            MainFlame.GetComponent<ParticleSystem>().emissionRate = IntensityLight * 20f;
            BaseFlame.GetComponent<ParticleSystem>().emissionRate = IntensityLight * 15f;
            Etincelles.GetComponent<ParticleSystem>().emissionRate = IntensityLight * 7f;
            Fumee.GetComponent<ParticleSystem>().emissionRate = IntensityLight * 12f;
        }
    }

    void Extinguish()
    {
        // Set isLit to false
        isLit = false;
        // Set all the torch parts to be inactive
        TorchLight.SetActive(false);
        MainFlame.SetActive(false);
        BaseFlame.SetActive(false);
        Etincelles.SetActive(false);
        Fumee.SetActive(false);
    }

    void Ignite()
    {
        // Set isLit to true
        isLit = true;
        // Set all the torch parts to be inactive
        TorchLight.SetActive(true);
        MainFlame.SetActive(true);
        BaseFlame.SetActive(true);
        Etincelles.SetActive(true);
        Fumee.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the game object in question is an ignitable
        if (other.gameObject.CompareTag("Ignitable"))
        {
            // Get the Torch component from the object in question
            Torch torch = other.gameObject.GetComponent<Torch>();
            // Make sure this component is valid
            if (torch != null)
            {
                // Make sure the other torch is on fire
                if (torch.isLit == true)
                {
                    // Light this torch
                    Ignite();
                }
            }
        }

    }
}
