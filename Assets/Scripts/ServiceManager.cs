using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class ServiceManager : MonoBehaviour
{
    public static ServiceManager instance;

    public GameObject ConnectedMenu;
    public GameObject DisconnectedMenu;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        //DontDestroyOnLoad(gameObject);
        PlayGamesPlatform.Activate();
        OnConnectionResponse(PlayGamesPlatform.Instance.localUser.authenticated);
    }

    void Start()
    {
        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        //PlayGamesPlatform.InitializeInstance(config);
        //PlayGamesPlatform.DebugLogEnabled = true;
        //PlayGamesPlatform.Activate();
        SignIn();
    }

    // Update is called once per frame
    private void SignIn()
    {
        Social.localUser.Authenticate(success =>
        {
            OnConnectionResponse(success);
        });
    }

    public void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, (bool success) =>
        {

        });
    }

    public void IncrementAchievement(string id, int stepsToIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
    }

    public void ShowAchievement()
    {
        Social.ShowAchievementsUI();
    }

    public void ShowAchievements()
    {
        instance.ShowAchievement();
    }

    public void OnConnectionResponse(bool authenticated)
    {
        if (authenticated)
        {
            ConnectedMenu.SetActive(true);
            DisconnectedMenu.SetActive(false);
        }
        else
        {
            ConnectedMenu.SetActive(false);
            DisconnectedMenu.SetActive(true);
        }
    }
}
