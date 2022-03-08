using UnityEngine;

public class startPl : MonoBehaviour
{
    public Transform tb;

    void Update()
    {
        if (tb != null)
        {
            if (tb.position.y > 3)
            {
                Destroy(gameObject);
            }
        }
    }
}
