using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Transform thingToPointTo;
    private GameObject player;
    public bool isInTrigger = true;
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("point"))
        {
            thingToPointTo.GetComponent<SpriteRenderer>().color = Color.red;
            isInTrigger = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("point"))
        {
            thingToPointTo.GetComponent<SpriteRenderer>().color = Color.white;
            isInTrigger = true;
        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        thingToPointTo.position = mouseWorldPosition;
    }
}
