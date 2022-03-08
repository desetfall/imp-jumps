using System.Collections;
using UnityEngine;

public class pilla : MonoBehaviour
{
    bool bn = false;

    private void Start()
    {
        StartCoroutine(selfDest());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<AudioSource>().Play();
            superJump();
            bn = true;
        }
    }

    IEnumerator selfDest()
    {

        yield return new WaitForSeconds(20);
        if (bn == false)
        {
            Destroy(gameObject);
        }
    }

        void superJump()
    {
        Player.Yspeed = 12.0f;
        StartCoroutine(jumpCCC());
    }

    IEnumerator jumpCCC()
    {
        yield return new WaitForSeconds(10);
        Player.Yspeed = 6.45f;
        Destroy(gameObject);
    }

}
