using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    float span = 2.0f;
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(bulletPrefab) as GameObject; // GameObject 타입으로 인스턴스화
            go.transform.position = new Vector2(70f, -2.4f);
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 27, ForceMode2D.Impulse);
            Destroy(go, 0.7f);
        }
    }
}
