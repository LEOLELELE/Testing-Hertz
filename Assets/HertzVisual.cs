using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HertzVisual : MonoBehaviour
{
    public Transform from;
    public float visualMultiplier;
    private TrailRenderer trail;
    public CPU cpu;

    private void Awake()
    {
        CPU.OnOutputSound += UpdateToSound;
        trail = GetComponent<TrailRenderer>();
    }

    public void UpdateToSound(float sound)
    {
        transform.position = from.position + sound * visualMultiplier * Vector3.up;
    }
}
