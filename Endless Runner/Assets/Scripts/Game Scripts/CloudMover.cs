using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float speed = -2f;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        speed += Random.Range(-0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(speed, 0);
    }
}
