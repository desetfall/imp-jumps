using UnityEngine;

public class yPlatform : MonoBehaviour
{
    GameObject newPlat;
    public GameObject cla_pl;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().SetTrigger("yp_opa");
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("deadTag"))
        {
            int RND = Random.Range(1, 3);
            switch (RND)
            {
                case 1: //x
                    newPlat = cla_pl;
                    claPlatform(newPlat);
                    break;
                case 2: //y
                    thisPlat();
                    break;
                default: //c
                    thisPlat();
                    break;
            }
        }
    }

    void claPlatform(GameObject o)
    {
        float tY = gameButtons.superY;
        Vector3 pl_pos = new Vector3();
        pl_pos.x = Random.Range(-2.2f, 2.2f);
        pl_pos.y += Random.Range(tY + 1.6f, tY + 2.0f);
        Instantiate(o, pl_pos, Quaternion.identity);
        gameButtons.superY = pl_pos.y;
        Destroy(gameObject);
    }

    void thisPlat()
    {
        float tY = gameButtons.superY;
        float newX = Random.Range(-2.2f, 2.2f);
        float newY = Random.Range(tY + 1.6f, tY + 2.0f);
        transform.position = new Vector3(newX, newY, 0);
        gameButtons.superY = newY;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        gameObject.GetComponent<Animator>().SetTrigger("yp_opaExit");
    }
}
