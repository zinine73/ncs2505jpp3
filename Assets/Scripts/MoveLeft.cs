using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    float speed = 30.0f;
    void Update()
    {
        transform.Translate(Vector3.left 
            * Time.deltaTime * speed);
    }
}
