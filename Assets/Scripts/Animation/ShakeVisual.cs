using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShakeVisual : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Color flashColor = Color.red;
    [SerializeField] protected float shakeDuration = 0.15f;
    [SerializeField] protected float shakeMagnitude = 0.4f;

    public void TriggerShakeVisual() {
        StartCoroutine(Changecolor());
        StartCoroutine(Shake(shakeDuration, shakeMagnitude));
    }

    protected IEnumerator Changecolor() {
        spriteRenderer.color = flashColor;
        yield
        return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
        yield
        return new WaitForSeconds(0.1f);
    }

    protected IEnumerator Shake(float duration, float magnitude) {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration) {
            float x = Random.Range(-0.5f, 0.5f) * magnitude;
            float y = Random.Range(-0.5f, 0.5f) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
