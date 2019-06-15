using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

	public Vector2 jumpForce = new Vector2 (0, 200);

	public GameObject projectilePrefab;
	private List<GameObject> Projectiles = new List<GameObject> ();
	private float projectileVelocity;

    //private SpriteRenderer terbang1;

	// Use this for initialization
	void Start () {
		projectileVelocity = 3;
	}

	// Update is called once per frame
	void Update () {

		for (int i = 0; i < Projectiles.Count; i++) {
			GameObject iBullet = Projectiles [i];
			if (iBullet != null) {
				iBullet.transform.Translate (new Vector3 (0, -1) * Time.deltaTime * projectileVelocity);

				Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (iBullet.transform.position);
				if (bulletScreenPos.y >= Screen.height || bulletScreenPos.y <= 0) {
					DestroyObject (iBullet);
					Projectiles.Remove (iBullet);
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "bullet") {
			Die ();
		}
	}

    void Die()
    {
        
    }

    public void Fire()
    {
        GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectiles.Add(bullet);
    }
}
