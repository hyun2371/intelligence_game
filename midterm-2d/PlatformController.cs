using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Translate(0.02f, 0, 0);
            if (transform.position.x > 37.5)
            {
                transform.position = new Vector2(31, transform.position.y);
            }
        }

        if (Input.GetMouseButton(0))
        {
            transform.Translate(-0.02f, 0, 0);
            if (transform.position.x < 31)
            {
                transform.position = new Vector2(37.5f, transform.position.y);
            }
        }

    }
}
