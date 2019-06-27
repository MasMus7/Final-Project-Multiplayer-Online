using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;

    public GameObject battleButton;

    private void Awake()
    {
        lobby = this; //menciptakan singleton, aktif saat Main Menu
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings(); //Menghubungkan ke server Master Photon
        ServiceManager.instance.UnlockAchievement(GPGSIds.achievement_first_login);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player telah terhubung dengan server Photon");
        battleButton.SetActive(true);
    }

    public void OnBattleButtonClicked()
    {
        Debug.Log("Tombol Battle telah ditekan");
        battleButton.SetActive(false);
        PhotonNetwork.JoinRandomRoom();
        StartCoroutine(WaitJoinRoom());
        ServiceManager.instance.UnlockAchievement(GPGSIds.achievement_first_battle);
    }

    IEnumerator WaitJoinRoom()
    {
        yield return new WaitForSeconds(2f);

        RoomOptions roomSetting = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        int roomNumber = Random.Range(0, 1000);
        PhotonNetwork.CreateRoom(roomNumber.ToString(), roomSetting, null, null);
    }

    public override void OnJoinedRoom()
    {
        StopAllCoroutines();
        PhotonNetwork.LoadLevel("Main Game");
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToBattleMenu()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
}
