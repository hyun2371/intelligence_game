using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDeadController : MonoBehaviour
{
    // 물고기 죽으면 트리거 발생 시 획득 소리 
    public AudioClip collectSE;
    AudioSource aud;
    GameObject gameDirector;

    private void Start()
    {
        this.aud = GameObject.Find("Fishes").GetComponent<AudioSource>();
        this.gameDirector = GameObject.Find("GameDirector");
    }

    private void OnTriggerEnter(Collider other)
    {
        this.aud.PlayOneShot(this.collectSE);
        this.gameDirector.GetComponent<GameDirector>().IncreaseFishCount();
        Destroy(this.gameObject);
    }
}
