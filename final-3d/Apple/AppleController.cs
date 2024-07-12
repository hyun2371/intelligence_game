using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사과의 밤송이 충돌, 사람 충돌 이벤트 제어
public class AppleController : MonoBehaviour
{
    public AudioClip hitSE, collectSE;
    AudioSource aud;
    GameObject gameDirector;
    bool isHit = false; //NullReferenceException 방지

    void Start()
    {
        this.aud = GameObject.Find("AppleTrees").GetComponent<AudioSource>();
        this.gameDirector = GameObject.Find("GameDirector");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bamsongi")
        {
            this.aud.PlayOneShot(this.hitSE); // 음악 동적 할당
            if (!isHit)
                transform.parent = transform.parent.parent; // 부모(나무)로부터 분리 -> 부모의 위치 움직임 영향x
            GetComponent<Rigidbody>().isKinematic = false; //사과 떨어짐
            GetComponent<ParticleSystem>().Play();
            isHit = true;
        }

        if (collision.gameObject.tag == "Player")
        {
            this.aud.PlayOneShot(this.collectSE);
            this.gameDirector.GetComponent<GameDirector>().IncreaseAppleCount();
            Destroy(this.gameObject);
        }

        
    }
}
