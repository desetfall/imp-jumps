using System.Collections;
using UnityEngine;

public class bPlatform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
       gameObject.GetComponent<Animator>().SetTrigger("pb_broke");
       gameObject.GetComponent<AudioSource>().Play();
       gameObject.GetComponent<BoxCollider2D>().enabled = false;
       StartCoroutine(jolk());
    }

    IEnumerator jolk()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
