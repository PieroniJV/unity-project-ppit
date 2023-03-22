using System.Collections;
using UnityEngine;

public class KnockbackScript : MonoBehaviour
{
    [SerializeField] private float knockbackStrength = 2f;
    [SerializeField] private float flashSpriteDelay = 2f;
    [SerializeField] private float shakeIntensity = 2f;
    [SerializeField] private float shakeCameraTimer = 3f;
    [SerializeField] private string objectToKnockBackTag = "";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(objectToKnockBackTag))
        {
            if (other.gameObject != null)
            {
                print("Normal enemy has entered trigger");
                StartCoroutine(Knockback_Coroutine(other));
            }
        }
    }

    IEnumerator Knockback_Coroutine(Collider2D other)
    {
        other.GetComponentInParent<Rigidbody2D>().AddForce(transform.up * knockbackStrength * Time.deltaTime, ForceMode2D.Impulse);
        CameraShake.cameraShakeInstance.ShakeTheCamera(shakeIntensity, shakeCameraTimer);
        other.GetComponentInParent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(flashSpriteDelay);
        if (other != null)
        {
            other.GetComponentInParent<SpriteRenderer>().color = Color.red;
        }
    }
}
