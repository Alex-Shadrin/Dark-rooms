using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSnow : MonoBehaviour
{
    public CustomRenderTexture SnowHeightMap;
    public Material HeightMapUpdate;
    public GameObject[] Tires;
    public float SecondsToRestore = 100; 
    private Camera mainCamera;
    private int tireIndex;
    private float timeToRestoreOneTick;
    public static readonly int DrawPosition = Shader.PropertyToID("_DrawPosition");
    public static readonly int DrawAngle = Shader.PropertyToID("_DrawAngle");
    public static readonly int RestoreAmount = Shader.PropertyToID("_RestoreAmount");
    // Start is called before the first frame update
    private void Start()
    {
        SnowHeightMap.Initialize();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out RaycastHit hit))
        //    {
        //        Vector2 hitTextureCoord = hit.textureCoord;

        //        HeightMapUpdate.SetVector(name: "_DrawPosition", hitTextureCoord);
        //        HeightMapUpdate.SetFloat(name: "_DrawAngle", 45 * Mathf.Deg2Rad);
        //    }
        //}

        timeToRestoreOneTick -= Time.deltaTime;
        if(timeToRestoreOneTick < 0)
        {
            HeightMapUpdate.SetFloat(RestoreAmount, 1/250f);
            timeToRestoreOneTick = SecondsToRestore / 250f;
        }
        else
        {
            HeightMapUpdate.SetFloat(RestoreAmount, 0);
        } 

        GameObject tire = Tires[tireIndex++ % Tires.Length];

        Ray ray = new Ray(tire.transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance: 0.48f))
        {
            Vector2 hitTextureCoord = hit.textureCoord;
            float angle = -90+tire.transform.rotation.eulerAngles.y;

            HeightMapUpdate.SetVector(DrawPosition, hitTextureCoord);
            HeightMapUpdate.SetFloat(DrawAngle, angle * Mathf.Deg2Rad);
        }

       
    }
}
