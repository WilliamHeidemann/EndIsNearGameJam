using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MushroomVisualEffectsController : MonoBehaviour
{
    [SerializeField] private FloatValue mushroom;
    [SerializeField] private PostProcessVolume postProcessVolume;
    private Vignette _vignette;
    private ChromaticAberration _chromaticAberration;
    private LensDistortion _lensDistortion;

    private void Start()
    {
        _vignette = postProcessVolume.profile.GetSetting<Vignette>();
        _chromaticAberration = postProcessVolume.profile.GetSetting<ChromaticAberration>();
        _lensDistortion = postProcessVolume.profile.GetSetting<LensDistortion>();
    }

    private void Update()
    {
        UpdateVignette();
        UpdateChromaticAberration();
        UpdateLensDistortion();
    }

    private void UpdateVignette()
    {
        var a = mushroom.value;
        var intensity = Mathf.PingPong(0, 0.2f) - 0.1f + a;
        _vignette.intensity.value = intensity;
    }

    private void UpdateChromaticAberration()
    {
        _chromaticAberration.intensity.value = mushroom.value;
    }

    private void UpdateLensDistortion()
    {
        var a = mushroom.value * 50;
        a = Mathf.Max(a, 0.0001f);
        var intensity = Mathf.PingPong(Time.time, a * 2) - a;
        _lensDistortion.intensity.value = intensity;

        var b = mushroom.value * 0.3f;
        b = Mathf.Max(b, 0.0001f);
        var centerX = Mathf.PingPong(Time.time, b * 2) - b;
        var centerY = Mathf.PingPong(Time.time + 1235.22f, b * 2) - b;
        _lensDistortion.centerX.value = centerX;
        _lensDistortion.centerY.value = centerY;
    }
}
