using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarNew : MonoBehaviour
{
    private Transform sweepTransform;
    private float rotationSpead;

    private void Awake()
    {
        sweepTransform = transform.Find("Sweep");
        rotationSpead = 180f;
    }

    // Update is called once per frame
    private void Update()
    {
        sweepTransform.eulerAngles -= new Vector3(0, 0, rotationSpead * Time.deltaTime); 
    }
}
