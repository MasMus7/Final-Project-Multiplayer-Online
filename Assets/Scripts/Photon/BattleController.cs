using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BattleController : MonoBehaviour
{
    public GameObject[] spawnPlayer;
    public GameObject[] prefabPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            prefabPlayer[0] = PhotonNetwork.Instantiate(prefabPlayer[0].name, spawnPlayer[0].transform.position, Quaternion.identity, 0);
            prefabPlayer[0].transform.Rotate(new Vector3(0, 0, -90));
        } else
        {
            prefabPlayer[1] = PhotonNetwork.Instantiate(prefabPlayer[1].name, spawnPlayer[1].transform.position, Quaternion.identity, 0);
            prefabPlayer[1].transform.Rotate(new Vector3(0, 0, 90));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        prefabPlayer[0].transform.position = prefabPlayer[0].transform.position + new Vector3(0, 0, 0);
        prefabPlayer[1].transform.position = prefabPlayer[1].transform.position + new Vector3(0, 0, 0);
    }
}
