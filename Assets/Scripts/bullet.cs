using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class bullet : MonoBehaviour {
    public GameObject BulletPrefab;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if(player.Mine == true)
        {
            BulletPrefab.gameObject.tag = "MyAmmo";
        }
        else if(player.Yours == true)
        {
            BulletPrefab.gameObject.tag = "YourAmmo";
        }
	}

	void OnCollisionEnter2D (Collision2D coll){
        if (player.Mine == true)
        {
            if(BulletPrefab.gameObject.tag == "MyAmmo")
            {
                if(coll.gameObject.tag == "Enemy")
                {
                    PhotonNetwork.Destroy(coll.gameObject);
                }
            }
            else if (BulletPrefab.gameObject.tag == "YourAmmo")
            {
                if(coll.gameObject.tag == "Player")
                {
                    PhotonNetwork.Destroy(coll.gameObject);
                }
            }
        }

        else if (player.Yours == true)
        {
            if (BulletPrefab.gameObject.tag == "MyAmmo")
            {
                if (coll.gameObject.tag == "Enemy")
                {
                    PhotonNetwork.Destroy(coll.gameObject);
                }
            }
            else if (BulletPrefab.gameObject.tag == "YourAmmo")
            {
                if (coll.gameObject.tag == "Player")
                {
                    PhotonNetwork.Destroy(coll.gameObject);
                }
            }
        }
    }

    void OnBecameInvisible()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
