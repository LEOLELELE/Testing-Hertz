using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCPU : MonoBehaviour
{
    public AtmegaSettings settings;
    public SinApproxProfile sin;

    public float hertz;
    public float amplitude = 1f;

    public static event Action<float> OnOutputSound = delegate { };

    private void Awake()
    {
        Time.fixedDeltaTime = 1f / (float)settings.clockRate;

        UpdateHertz(hertz);
    }

    private void FixedUpdate()
    {
        Tick();
    }

    private int currentCount = 0;
    public void Tick()
    {
        OutputSound(sin.sin[currentSinElement % sin.sin.Length] * amplitude);

        CountUp();


        if (currentCount >= GetCountToHertz(hertz))
        {
            currentSinElement++;
            currentCount = 0;
        }
        currentCount++;
    }

    private void OutputSound(float sound)
    {
        Debug.Log("Output " + sound);

        OnOutputSound?.Invoke(sound);
    }

    private int currentSinElement = 0;
    private void CountUp()
    {
        currentCount++;
    }

    private int currentCountToHertz;
    private int GetCountToHertz(float hertz)
    {
        return (int)((sin.GetRate() / hertz) * settings.clockRate);
    }

    private void UpdateCountToHertz(float hertz)
    {
        currentCountToHertz = (int)((sin.GetRate() / hertz) * settings.clockRate);
    }

    public void UpdateHertz(float hertz)
    {
        this.hertz = hertz;

        UpdateCountToHertz(hertz);
    }
}
