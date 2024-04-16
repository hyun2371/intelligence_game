using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatformController : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 1.0f);
    }
}
