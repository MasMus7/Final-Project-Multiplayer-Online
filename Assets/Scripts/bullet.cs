using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class bullet : MonoBehaviourPun {
    public GameObject BulletPrefab;
    public float speed = 10f;
    public GameObject lose;
    public GameObject Win;
    // Use this for initialization
    void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if(player.Mine == true)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        else if(player.Yours == true)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
	}

	void OnCollisionEnter2D (Collision2D coll){
        if (photonView.IsMine)
        {
            if(BulletPrefab.gameObject.tag == "MyAmmo")
            {
                if(coll.gameObject.tag == "Enemy")
                {
                    PhotonNetwork.Destroy(coll.gameObject);
                    ServiceManager.instance.UnlockAchievement(GPGSIds.achievement_first_kill);
                    Win.gameObject.SetActive(true);
                }
            }
            else if (BulletPrefab.gameObject.tag == "YourAmmo")
            {
                if(coll.gameObject.tag == "Player")
                {
                    PhotonNetwork.Destroy(coll.gameObject);
                    ServiceManager.instance.UnlockAchievement(GPGSIds.achievement_first_die);
                    lose.gameObject.SetActive(true);
                }
            }
        }

        else
        {
            if (BulletPrefab.gameObject.tag == "MyAmmo")
            {
                if (coll.gameObject.tag == "Enemy")
                {
                    PhotonNetwork.Destroy(coll.gameObject);
                    ServiceManager.instance.UnlockAchievement(GPGSIds.achievement_first_kill);
                    Win.gameObject.SetActive(true);
                }
            }
            else if (BulletPrefab.gameObject.tag == "YourAmmo")
            {
                if (coll.gameObject.tag == "Player")
                {
                    PhotonNetwork.Destroy(coll.gameObject);
                    ServiceManager.instance.UnlockAchievement(GPGSIds.achievement_first_die);
                    lose.gameObject.SetActive(true);
                }
            }
        }

    }
}
