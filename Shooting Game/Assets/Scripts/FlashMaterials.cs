using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashMaterial : MonoBehaviour
{
    [SerializeField] Material flashMaterial;

    private Material originmaterial;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        originmaterial = spriteRenderer.material;
    }

    public IEnumerator HitEffect(float duration)
    {
        spriteRenderer.material = flashMaterial;

        yield return new WaitForSeconds(duration);

        spriteRenderer.material = originmaterial;
    }
}
