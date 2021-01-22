using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHeightToSameAsGround : MonoBehaviour
{
    float height;
    // Start is called before the first frame update
    void Start()
    {
        GameObject groundObj = GameObject.Find("Ground");
        height = groundObj.GetComponent<Renderer>().bounds.size.y * (groundObj.transform.localScale.y / GetComponent<Renderer>().transform.localScale.y);

        transform.localScale = new Vector2(transform.localScale.x , height);
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
