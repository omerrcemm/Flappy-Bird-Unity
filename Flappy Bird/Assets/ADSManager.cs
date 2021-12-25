using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class ADSManager : MonoBehaviour
{
    public static ADSManager instance;

    public BannerView _bannerAd;
    // Test Banner Id si 
    [SerializeField] string _bannerAdId = "ca-app-pub-3940256099942544/6300978111";

    public InterstitialAd _fullscreenAd;
    // Tam ekran reklam göstermek için gereken test id si
    [SerializeField] string _fullScreenAdId = "ca-app-pub-3940256099942544/1033173712";




    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        showBannerAd();
        MobileAds.Initialize(initStatus => { });
    }

    // BANNERAD START
    public void showBannerAd()
    {
        requestBannerAd();

        // Yüklenen banner reklamını göstermek için aşağıdaki kodu kullanıyoruz.
        _bannerAd.Show();
    }

    public void requestBannerAd()
    {
        _bannerAd = new BannerView(_bannerAdId, AdSize.Banner, AdPosition.Bottom);
        AdRequest adRequest = new AdRequest.Builder().Build();

        // Burada banner reklamımızın AdMobdan yüklüyoruz ve göstermek için hazır hale getiriyoruz.
        _bannerAd.LoadAd(adRequest);
    }
    // BANNERAD END


    // FULLSCREENAD - START
    public void requestFullScreenAd()
    {
        _fullscreenAd = new InterstitialAd(_fullScreenAdId);

        AdRequest adRequest = new AdRequest.Builder().Build();

        _fullscreenAd.LoadAd(adRequest);

        // Reklam yüklenmesini bekler ondan sonra reklamı gösterir.
        _fullscreenAd.OnAdLoaded += (sender, args) => { _fullscreenAd.Show(); };
    }
    // FULLSCREENAD - END

    public void ShowADS()
    {
        requestFullScreenAd();

        _fullscreenAd.Show();
    }
}



