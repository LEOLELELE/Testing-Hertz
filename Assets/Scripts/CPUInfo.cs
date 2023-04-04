using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CPUInfo : MonoBehaviour
{
    public CPU cpu;
    public TextMeshProUGUI hertz;
    public TextMeshProUGUI clockRate;
    public TextMeshProUGUI sinResolution;
    public TextMeshProUGUI amplitude;

    private void Update()
    {
        sinResolution.text = "Sinus Wave Resolution: " + cpu.sin.sin.Length.ToString();
        amplitude.text = "Amplitude: " + cpu.amplitude.ToString();
        clockRate.text = "CPU Tickrate: " + cpu.settings.clockRate.ToString();
        hertz.text = "Hertz: " + cpu.hertz.ToString();
    }
}
