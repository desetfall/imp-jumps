using UnityEngine;

public class cPlatrom : MonoBehaviour
{
    public GameObject x_platform;
    public GameObject y_platform;
    public GameObject pillar;
    GameObject newPlat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("deadTag"))
        {
            int RND = Random.Range(1, 4);
            switch (RND)
            {
                case 1: //x
                    newPlat = x_platform;
                    xyPlatform(newPlat);
                    break;
                case 2: //y
                    newPlat = y_platform;
                    xyPlatform(newPlat);
                    break;
                case 3: //c
                    clasicPlatrom();
                    break;
                default: //c
                    clasicPlatrom();
                    break;
            }
        }
    }

    void clasicPlatrom()
    {
        float tY = gameButtons.superY;
        float newX = Random.Range(-2.2f, 2.2f);
        float newY = Random.Range(tY + 1.6f, tY + 2.0f);
        Vector3 yij = new Vector3(newX, newY, 0);
        transform.position = yij;
        gameButtons.superY = newY;
        chancePil(yij);
    }

    void chancePil(Vector3 l)
    {
        int j = Random.Range(1, 10);
        if (j == 5)
        {
            Instantiate(pillar, l, Quaternion.identity);
        }
    }

    void xyPlatform(GameObject g)
    {
        float tY = gameButtons.superY;
        Vector3 pl_pos = new Vector3();
        pl_pos.x = Random.Range(-2.2f, 2.2f);
        pl_pos.y += Random.Range(tY + 1.6f, tY + 2.0f);
        Instantiate(g, pl_pos, Quaternion.identity);
        gameButtons.superY = pl_pos.y;
        Destroy(gameObject);
    }
}
