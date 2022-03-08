using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
public class gameButtons : MonoBehaviour
{
    public static float superY = 13.0f;
    public GameObject fade;
    private readonly float CamRect = 9f / 16f;
    public Camera cam;

    public GameObject classic_platform;

    Vector3 pl_pos = new Vector3();

    public void Awake()
    {
        cam.aspect = CamRect;
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().isLoaded)
        {
            Appodeal.hide(Appodeal.BANNER_BOTTOM);
            StartCoroutine(fadeAWait());
        }
    }

    IEnumerator fadeAWait()
    {
        yield return new WaitForSeconds(0.25f);
        fade.GetComponent<Animator>().SetBool("initFadeBool", true);
        yield return new WaitForSeconds(0.25f);
        fade.SetActive(false);
        for (int i = 0; i < 8; i++)
        {
            pl_pos.x = Random.Range(-2.2f, 2.2f);
            pl_pos.y += Random.Range(1.6f, 2.0f);
            Instantiate(classic_platform, pl_pos, Quaternion.identity);
        }
    }
}
