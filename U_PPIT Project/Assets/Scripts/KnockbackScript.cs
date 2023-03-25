using System.Collections;
using UnityEngine;

public class KnockbackScript : MonoBehaviour
{
    [SerializeField] private float knockbackStrength = 2f;
    [SerializeField] private float shakeIntensity = 2f;
    [SerializeField] private float shakeCameraTimer = 3f;
    [SerializeField] private string enemyToKnockBack = "";
    [SerializeField] private GameObject playerGO;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyToKnockBack))
        {
            if (other.gameObject != null)
            {
                Vector2 direction = (playerGO.transform.position - other.transform.position).normalized; 
                other.GetComponentInParent<Rigidbody2D>().AddForce(-direction * knockbackStrength * Time.deltaTime, ForceMode2D.Impulse);
                CameraShake.cameraShakeInstance.ShakeTheCamera(shakeIntensity, shakeCameraTimer);
            }
        }
    }

}
