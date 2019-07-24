using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoScroll : MonoBehaviour
{
    public float scrollSpeed;
    public GameObject player;

    private Vector3 offset;

    private void Start()
    {
        offset = player.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        player.transform.position += new Vector3(scrollSpeed, 0f);
        transform.position = new Vector3(player.transform.position.x - offset.x, transform.position.y, transform.position.z);
    }
}
