using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    //public float dumping = 1.5f;
    //public Vector2 offset = new Vector2(2f, 1f);
    //private lastX;
    //private lastZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
