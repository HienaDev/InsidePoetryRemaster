using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{

    [SerializeField] private float flickerIntensity = 0.3f;
    private float defaultIntensity;
    [SerializeField] private Vector2 flickerSpeed = new Vector2(0.05f, 0.2f);
    private float flickerCooldown;
    private float justFlicked;

    private Light2D torch;

    // Start is called before the first frame update
    void Start()
    {
        torch = GetComponent<Light2D>();
        flickerCooldown = Random.Range(flickerSpeed.x, flickerSpeed.y);
        defaultIntensity = torch.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - justFlicked > flickerCooldown)
        {
            torch.intensity = Random.Range(defaultIntensity - flickerIntensity, defaultIntensity + flickerIntensity);
            flickerCooldown = Random.Range(flickerSpeed.x, flickerSpeed.y);
            justFlicked = Time.time;
        }
    }
}
