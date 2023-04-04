using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CPU : MonoBehaviour
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

    //private float lastTime = 0;
    public void Tick()
    {
        //Debug.Log("FixedUpdate tick at " + Time.time + ". This simulates a tickrate of: " + (1 / (Time.time - lastTime)));

        //lastTime = Time.time;

        OutputSound(sin.sin[currentSinElement % sin.sin.Length] * amplitude);

        CountUp();

        if (currentCount >= GetCountToHertz(hertz))
        {
            currentSinElement++;
            currentCount = 0;
        }
    }

    private void OutputSound(float sound)
    {
        Debug.Log("Output " + sound);

        OnOutputSound?.Invoke(sound);
    }

    private int currentSinElement = 0;
    private int currentCount = 0;
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
        //If we have 1 hz.
        //We want to update the number in our sinus wave every (1 / sinus-resolution) second.
        //This results in a full period in one second.

        //IF we have a hz of 20.
        //We want to update the number in our sinus wave every (1 / (sinus-resolution * 20))

        //Looks like the formula is: (1 / (sinus-resolution * hertz)) or (1 / sinus-resolution / hertz).
        //This is how many seconds we want to pass between each change.

        //To get the number we need to count to we must take the clock-rate into account.

        //Let's say clockrate is 1 000 000 hz.
        //To get the amount of time before a second has passed we just count to 1 000 000.
        //To get the amount of time before 0.5 seconds has passed, we count to 500 000.
        //The formula should therefore be: clock-rate * seconds-that-should-pass.
        //To get the amount of time before 0.03 seconds has passed we do:
        //clock-rate * 0.03 seconds. Nice.
        currentCountToHertz = (int)((sin.GetRate() / hertz) * settings.clockRate);
        Debug.Log("Count-to-hertz has been updated to: " + currentCountToHertz);
    }

    public void UpdateHertz(float hertz)
    {
        this.hertz = hertz;

        UpdateCountToHertz(hertz);
    }
}
