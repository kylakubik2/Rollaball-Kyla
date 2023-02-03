using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
    public float speed = 0.01f;
    public float xMax;
    public float xMin;
    private int direction = 1;

    // Update is called once per frame
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

        transform.position = new Vector3(xNew, 0.5f, 6.7f);
    }
}
