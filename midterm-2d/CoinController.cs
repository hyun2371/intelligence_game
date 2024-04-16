using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject gameDirector;
    private GameObject coins;

    void Start()
    {
        this.coins = GameObject.Find("coins");
        this.gameDirector = GameObject.Find("GameDirector");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("Coin Trigger");
            this.gameDirector.GetComponent<GameDirector>().IncreaseScore(5);
            this.coins.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
    }
}
