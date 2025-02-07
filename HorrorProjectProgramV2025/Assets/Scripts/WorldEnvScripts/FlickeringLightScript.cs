using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickeringLightScript : MonoBehaviour
{
    [SerializeField] float firstVariable;
    [SerializeField] float secondVariable;
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
        lightSource.pointLightOuterRadius = Random.Range(firstVariable, secondVariable);
        StartCoroutine(LightFlicker());
    }
}
