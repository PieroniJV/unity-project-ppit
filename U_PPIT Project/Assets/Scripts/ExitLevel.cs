using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] private GameObject uiGO;

    private void Awake()
    {
        uiGO.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiGO.SetActive(true);
        }
    }
}
