using UnityEngine;

public class camFollow : MonoBehaviour
{
    public Transform player_pos;

    void Update()
    {
        if (player_pos.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player_pos.position.y, transform.position.z);
        }
    }
}
