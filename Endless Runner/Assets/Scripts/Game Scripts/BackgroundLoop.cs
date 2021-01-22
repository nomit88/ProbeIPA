using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float backgroundMoveSpeed = 0.2f;

    private Material material;
    private Vector2 offset = Vector2.zero; 

    // Start is called before the first frame update
    void Start()
    {   
        material = GetComponent<Renderer> ().material;

        offset = material.GetTextureOffset("_MainTex");
        
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += backgroundMoveSpeed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
