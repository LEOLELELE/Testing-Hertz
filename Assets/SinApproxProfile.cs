using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SinApproxProfile : ScriptableObject
{
    public float[] sin;

    /// <summary>
    /// Gets the sample rate of the sin wave.
    /// </summary>
    /// <returns>int</returns>
    public float GetRate()
    {
        return 1f / (float)sin.Length;
    }
}
