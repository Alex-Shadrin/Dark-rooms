using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFreezing : MonoBehaviour
{
    public Material ef_material;
    public float frozen;
    private float saveFrozen;
    public float freezeLevel;

    private void Update()
    {
        Freeze();
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        other.GetComponent<EffectFreezing>().frozen = this.frozen;
    //        //time += Time.deltaTime * frozen;
    //        //if (time != 100)
    //        //    ef_material.SetFloat("_Sides", time);
    //        //Debug.Log("Collider");
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var playersEffectFreezing = other.GetComponent<EffectFreezing>();
            saveFrozen = playersEffectFreezing.frozen;
            playersEffectFreezing.frozen = this.frozen;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            var playersEffectFreezing = other.GetComponent<EffectFreezing>();
            playersEffectFreezing.frozen = saveFrozen;
        }
    }

    private void Freeze()
    {
        freezeLevel = Math.Min(Math.Max(freezeLevel + Time.deltaTime * frozen, 10), 100); 
        ef_material.SetFloat("_Sides", Mathf.Round(freezeLevel));
    }
}
