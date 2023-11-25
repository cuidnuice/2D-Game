using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float speed;
    [SerializeField] Vector2 direction;
    [SerializeField] GameObject particle;

    [SerializeField] Sound sound = new Sound();

    private FlashMaterials flashMaterial;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;

    private void Awake()
    {
        direction = Vector2.down;

        flashMaterial = GetComponent<FlashMaterials>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void OnHit(int damage)
    {
        health -= damage;
        AudioManager.instance.Sound(sound.audioClip[0]);

        if (health <= 0)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        AudioManager.instance.Sound(sound.audioClip[1]);

        circleCollider2D.enabled = false;

        spriteRenderer.enabled = false;

        particle.SetActive(true);
    }

    public IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            if (gameObject.activeSelf)
            {
                StartCoroutine(flashMaterial.HitEffect(0.125f));
            }
        }
    }

    private void OnBecameInvisible()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(DeathRoutine());
        }
    }

    private void OnEnable()
    {
        health = 100;

        circleCollider2D.enabled = true;

        spriteRenderer.enabled = true;

        particle.SetActive(false);
    }
}
