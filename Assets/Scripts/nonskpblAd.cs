using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class nonskpblAd : MonoBehaviour
{
    public GameObject b1, b2;
    ConsentManager.Api.Consent consent;

    IEnumerator ButtonWait()
    {
        yield return new WaitForSeconds(2);
        b1.SetActive(true);
        b2.SetActive(true);
    }

    void Start()
    {
        ConsentManager.Api.ConsentManager consentManager = ConsentManager.Api.ConsentManager.getInstance();
        consent = consentManager.getConsent();
        Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.disableLocationPermissionCheck();
        Appodeal.disableWriteExternalStoragePermissionCheck();       
        StartCoroutine(IEShowNSV());
        StartCoroutine(ButtonWait());
    }

    public IEnumerator IEShowNSV()
    {
        if (MMplayer_prefs.Adcount < 2)
        {
            yield return new WaitUntil(() => Appodeal.canShow(Appodeal.INTERSTITIAL));
            MMplayer_prefs.Adcount = MMplayer_prefs.Adcount + 1;
            Appodeal.show(Appodeal.INTERSTITIAL);
        }
        else
        {
            yield return new WaitUntil(() => Appodeal.canShow(Appodeal.NON_SKIPPABLE_VIDEO));
            MMplayer_prefs.Adcount = 0;
            Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
        }
        
    }
}
 