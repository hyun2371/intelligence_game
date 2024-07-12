using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornController : MonoBehaviour
{
    int count = 1;
    bool isGrown = false;
    public AudioClip growSE, collectSE;
    AudioSource aud;
    GameObject gameDirector;

    void Start()
    {
        this.aud = GameObject.Find("CornGroup").GetComponent<AudioSource>();
        this.gameDirector = GameObject.Find("GameDirector");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            count++;
            this.aud.PlayOneShot(this.growSE);
            transform.localScale = new Vector3(0.5f * count, 0.5f * count, 0.5f * count);
            
        }
        if (count >5) // 1,2,3,4,5
        {
            count = 0;
            transform.Rotate(0, 0, 90); // z축 기준으로 90도 회전
            isGrown = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isGrown)
        {
            // 파티클 활성화
            this.aud.PlayOneShot(this.collectSE);
            this.gameDirector.GetComponent<GameDirector>().IncreaseCornCount();
            Destroy(gameObject);
        }
    }
}
