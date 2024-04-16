using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    private GameObject gameDirector;
    private AudioSource potionSound;

    void Start()
    {
        this.gameDirector = GameObject.Find("GameDirector");
        this.potionSound = GameObject.Find("potions").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            potionSound.Play();
            if (gameObject.tag == "Potion1")
                this.gameDirector.GetComponent<GameDirector>().increaseHp(0.1f);
            if (gameObject.tag == "Potion2")
                this.gameDirector.GetComponent<GameDirector>().increaseHp(0.2f);
            if (gameObject.tag == "Potion3")
                this.gameDirector.GetComponent<GameDirector>().resetHp();
            Destroy(gameObject);
        }
    }
}
