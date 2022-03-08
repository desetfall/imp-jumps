using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;


public class menuButtons : MonoBehaviour
{
    public Animator fade_animator;
    public GameObject fade;
    public Button colorBtn;
    ConsentManager.Api.Consent consent;

    private void Awake()
    {       
        ConsentManager.Api.ConsentManager consentManager = ConsentManager.Api.ConsentManager.getInstance();
        consent = consentManager.getConsent();
        ConsentManager.Api.Consent.Zone consentZone = consentManager.getConsentZone();
        ConsentManager.Api.Consent.Status consentStatus = consentManager.getConsentStatus();
        ConsentManager.Api.Consent.ShouldShow consentShouldShow = consentManager.shouldShowConsentDialog();
        if (consentShouldShow == ConsentManager.Api.Consent.ShouldShow.TRUE)
        {
            
        }
        
    }

    void Start()
    {
        Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.disableLocationPermissionCheck();
        Appodeal.disableWriteExternalStoragePermissionCheck();
        Appodeal.initialize("bcffbd2a8e7bbd37fcb5e2172ff193a5d1a026dcb576ac52", Appodeal.BANNER_BOTTOM | Appodeal.NON_SKIPPABLE_VIDEO | Appodeal.INTERSTITIAL, consent);
        StartCoroutine(IEShowBanner());
    }

    public IEnumerator IEShowBanner()
    {
        yield return new WaitUntil(() => Appodeal.canShow(Appodeal.BANNER_BOTTOM));
        Appodeal.show(Appodeal.BANNER_BOTTOM);
    }

    public void start_button()
    {
        fade.SetActive(true);
        fade_animator.SetBool("fadeIN", true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        asyncLoad.allowSceneActivation = false;
        StartCoroutine(fadeAWait(asyncLoad));
    }

    IEnumerator fadeAWait(AsyncOperation a)
    {
        yield return new WaitForSeconds(0.25f);
        a.allowSceneActivation = true;
    }

    public void color_button()
    {
        int clrIndex = PlayerPrefs.GetInt("playerColor");
        if (clrIndex < 6)
        {
            clrIndex++;
        }
        else
        {
            clrIndex = 1;
        }
        switch (clrIndex)
        {
            case 1:
                colorBtn.image.color = Color.red;
                break;
            case 2:
                colorBtn.image.color = Color.cyan;
                break;
            case 3:
                colorBtn.image.color = Color.blue;
                break;
            case 4:
                colorBtn.image.color = Color.green;
                break;
            case 5:
                colorBtn.image.color = new Color(1, 0.5f, 0);
                break;
            case 6:
                colorBtn.image.color = Color.yellow;
                break;
            default:
                colorBtn.image.color = Color.red;
                break;
        }
        PlayerPrefs.SetInt("playerColor", clrIndex);
        PlayerPrefs.Save();
    }
}
