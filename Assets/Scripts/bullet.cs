using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class bullet : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Player") {
            PhotonNetwork.Destroy(gameObject);
		}
	}

    void OnBecameInvisible()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
