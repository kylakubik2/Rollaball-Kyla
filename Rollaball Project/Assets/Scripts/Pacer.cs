using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacer : MonoBehaviour
{
    public float speed;
    public float xMax;
    public float xMin;
    private int direction = 1;
    private float zCurrent;

    void Update()
    {
        float xNew = transform.position.x + direction * speed * Time.deltaTime;

        if (xNew >= xMax) {
            xNew = xMax;
            direction *= -1;
        } else if (xNew <= xMin) {
            xNew = xMin;
            direction *= -1;
        }

        zCurrent = transform.position.z;

        transform.position = new Vector3(xNew, 0.75f, zCurrent);
    }
}
