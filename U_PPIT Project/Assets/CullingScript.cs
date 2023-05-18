using System.Collections.Generic;
using UnityEngine;

public class CullingScript : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private Transform normalEnemyGroup;
    [SerializeField] private Transform smallEnemyGroup;
    
    public List<string> tagsToCheck;
    private Collider2D visibilityCollider;
    
    void Awake()
    {
        visibilityCollider = GetComponent<Collider2D>();
        
        foreach (Transform child in normalEnemyGroup)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }
        }
        
        foreach (Transform child in smallEnemyGroup)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }
        }
        
        foreach (string tag in tagsToCheck)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
            
            foreach (GameObject obj in objects)
            {
                Collider2D objectCollider = obj.GetComponent<Collider2D>();
                if (objectCollider != null && !visibilityCollider.bounds.Intersects(objectCollider.bounds))
                {
                    obj.SetActive(false);
                }
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Normal Enemy") || other.CompareTag("SmallEnemy"))
        {
            Transform parent = other.gameObject.transform.parent;
            parent.GetComponent<SpriteRenderer>().enabled = true;
            Transform sibling = parent.Find("Follow Radius");
            sibling.gameObject.SetActive(true);
        }

        if (other.CompareTag("HouseArea"))
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
        
        if (other.CompareTag("TreeArea"))
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
            other.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Normal Enemy") || other.CompareTag("SmallEnemy"))
        {
            Transform parent = other.gameObject.transform.parent;
            parent.GetComponent<SpriteRenderer>().enabled = false;
            Transform sibling = parent.Find("Follow Radius");
            sibling.gameObject.SetActive(false);
        }
        
        if (other.CompareTag("HouseArea"))
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
        
        if (other.CompareTag("TreeArea"))
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
            other.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    
    private void Update()
    {
        transform.position = camera.position;
    }
}