using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BattleController : MonoBehaviour
{
    public GameObject spawnPlayer;
    public GameObject spawnPlayers;
    public GameObject prefabPlayer;
    public GameObject prefabPlayers;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(prefabPlayer.name, spawnPlayer.transform.position, Quaternion.identity, 0);
        }
        else
        {
            PhotonNetwork.Instantiate(prefabPlayers.name, spawnPlayers.transform.position, Quaternion.identity, 0);
        }
    }
}
