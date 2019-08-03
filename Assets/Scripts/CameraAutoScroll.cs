using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraAutoScroll : MonoBehaviour
{
    public float scrollSpeed;
    public GameObject player;
    public GameObject house;
    public GameObject platform;

    private Collider2D platformCollider;
    private Collider2D playerCollider;
    private Vector3 offset;
    private float origPosX;
    private float extraScrollWidth;

    private void Start()
    {
        extraScrollWidth = house.GetComponent<SpriteRenderer>().bounds.size.x;

        offset = player.transform.position - transform.position;
        origPosX = transform.position.x;
        playerCollider = player.GetComponent<EdgeCollider2D>();
        platformCollider = platform.GetComponent<TilemapCollider2D>();
    }

    private void FixedUpdate()
    {
        if (!playerCollider.IsTouching(platformCollider))
        {
            player.transform.position += new Vector3(scrollSpeed * Time.fixedDeltaTime, 0f);

            Vector3 endPos = new Vector3(extraScrollWidth, 0f, 0f) + transform.position;
            if (extraScrollWidth > 0)
            {
                transform.position = new Vector3(player.transform.position.x - offset.x, transform.position.y, transform.position.z);

                if (house.activeSelf)
                    extraScrollWidth -= (transform.position.x - origPosX);
            }
            origPosX = transform.position.x;
        }
    }
}
