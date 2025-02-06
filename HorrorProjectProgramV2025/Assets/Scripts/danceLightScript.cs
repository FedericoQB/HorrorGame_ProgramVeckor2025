using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class danceLightScript : MonoBehaviour
{
    public Light2D light;
    bool playerIsNear = false;
    int colorNumber = 1;

    float firstVariable = 1f;
    float secondVariable = 0f;
    [SerializeField] float secondsBetweenFlickers;

    Light2D lightSource;

    private void Start()
    {
        lightSource = GetComponent<Light2D>();
        StartCoroutine(LightFlicker());
    }

    IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(secondsBetweenFlickers);
        lightSource.intensity = Random.Range(firstVariable, secondVariable);
        StartCoroutine(LightFlicker());
    }
}
