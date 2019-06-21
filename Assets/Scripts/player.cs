using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using Photon.Pun;

public class player : MonoBehaviour {
    float directiony;
	public Vector2 jumpForce = new Vector2 (0, 200);
    public float moveSpeed = 10f;

    //public GameObject projectilePrefab;
    //private List<GameObject> Projectiles = new List<GameObject> ();
    //private float projectileVelocity;
    public PhotonView pv;

    private SpriteRenderer terbang1;
    public Rigidbody2D rb;

    public static bool Mine = false;
    public static bool Yours = false;

    // Use this for initialization
    void Start () {
        //projectileVelocity = 3;
        if (pv.IsMine)
        {
            this.gameObject.tag = "Player";
            Mine = true;
            Yours = false;
        }
        else
        {
            this.gameObject.tag = "Enemy";
            Mine = false;
            Yours = true;
        }
	}

	// Update is called once per frame
	void Update () {
        Updown();
		//for (int i = 0; i < Projectiles.Count; i++) {
		//	GameObject iBullet = Projectiles [i];
		//	if (iBullet != null) {
		//		iBullet.transform.Translate (new Vector3 (0, -1) * Time.deltaTime * projectileVelocity);

		//		Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (iBullet.transform.position);
		//		if (bulletScreenPos.y >= Screen.height || bulletScreenPos.y <= 0) {
		//			DestroyObject (iBullet);
		//			Projectiles.Remove (iBullet);
		//		}
		//	}
		//}
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "bullet") {
			Die ();
		}
	}

    void Die()
    {
        
    }

    private void Updown()
    {
        directiony = CrossPlatformInputManager.GetAxis("Vertical"); 
        if (CrossPlatformInputManager.GetButtonDown("Up"))
        {

        }

        if (CrossPlatformInputManager.GetButtonDown("Down"))
        {

        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x , directiony * moveSpeed);
    }
}
