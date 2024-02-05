using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;

    void Start()
    {
        speed = 2;

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;
        transform.position += new Vector3(x, 0, z) * Time.deltaTime;
    }
}
 
    

