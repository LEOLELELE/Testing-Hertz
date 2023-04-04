using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Vector3 move;

    private void Update()
    {
        transform.position += move * Time.deltaTime;
    }
}
