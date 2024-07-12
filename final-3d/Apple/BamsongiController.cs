using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    bool isLocked = false;
    private void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isLocked)
        {
            GetComponent<ParticleSystem>().Play();
            isLocked = true;
        }
        
    }
}
