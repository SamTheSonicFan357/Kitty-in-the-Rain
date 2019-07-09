using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoScroll : MonoBehaviour
{
    public float scrollSpeed;

    void FixedUpdate()
    {
        transform.position += new Vector3(scrollSpeed, 0f, 0f);
    }
}
