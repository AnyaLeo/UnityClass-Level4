using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            movement = Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement = movement + Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement = movement + Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement = movement + Vector3.right;
        }

        transform.Translate(movement * Time.deltaTime * speed);
    }
}
