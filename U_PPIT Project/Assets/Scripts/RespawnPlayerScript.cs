using UnityEngine;

public class RespawnPlayerScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            player.position = transform.position;
        }
    }
}
