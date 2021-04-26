using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private GameObject crashRef;

    private SpriteRenderer sr;
    public LayerMask ignoreCollision;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<MonoBehaviour>(out var mb))
        {
            if (mb is IDamageable damageable)
            {
                damageable.TakeDamage(damage);
            }
        }

        BoxExplode();
    }

    private void BoxExplode()
    {
        GameObject explode = Instantiate(crashRef, transform.position, Quaternion.identity);

        SpriteRenderer[] sprites = explode.GetComponentsInChildren<SpriteRenderer>();

        foreach (var sp in sprites)
        {
            StartCoroutine(Fade(sp));
        }

        sr.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 2f);
        Destroy(explode, 2f);
    }

    private IEnumerator Fade(SpriteRenderer sprren)
    {

        for (float alpha = 1f; alpha >= 0.5f; alpha -= .05f)
        {
            Color c = sprren.color;
            c.a = alpha;
            sprren.color = c;

            yield return new WaitForSeconds(.1f);
        }

        Destroy(sprren.gameObject);
    }
}
