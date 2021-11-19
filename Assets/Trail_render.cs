using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail_render : MonoBehaviour
{

    public TrailRenderer _trailRenderer;
    float alpha = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void Update()
    {
        Gradient _gradient = new Gradient();
        _gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.blue, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        _trailRenderer.colorGradient = _gradient;
    }

}
