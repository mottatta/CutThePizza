using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    float scrollSpeed = -5f;
    Vector2 startPos;
    public bool doScroll = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (doScroll)
        {
            float newPos = Mathf.Repeat(Time.time * scrollSpeed, 20);
            transform.position = startPos + Vector2.left * newPos;
        }
    }
}
