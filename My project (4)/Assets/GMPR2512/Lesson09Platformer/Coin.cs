using System;
using UnityEngine;

namespace GMPR2512.Lesson09Platformer
{
    public class Coin : MonoBehaviour
    {
        SoundHub soundHub;
        void Awake()
        {
            soundHub = GameObject.Find("SoundHub").GetComponent<SoundHub>();
        }
        void OnTriggerEnter2D(Collider2D collision)
        {
            soundHub.PlayCoinSound();
            Destroy(gameObject);
        }
    }
}
