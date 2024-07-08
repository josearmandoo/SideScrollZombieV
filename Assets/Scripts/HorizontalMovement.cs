using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    static float t = 0.0f;

    public float distance, speed;

    private float originalPos;

    bool isRotate = false;
    void Start()
    {
        originalPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(originalPos + Mathf.Sin(t) * distance, transform.position.y, transform.position.z);
        t += speed * Time.deltaTime;
    }
}
