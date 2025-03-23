using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakingwall : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    private AudioSource audioSource;
    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Weapon"))
        {
            StartCoroutine(Break());
        }
    }
    private IEnumerator Break()
    {
        particle.Play();
        sr.enabled = false;
        bc.enabled = false;

        audioSource.Play();

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}

