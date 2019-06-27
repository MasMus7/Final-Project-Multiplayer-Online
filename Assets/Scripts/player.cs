using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using Photon.Pun;

public class player : MonoBehaviourPun, IPunObservable
{
    float directiony;

    public float moveSpeed = 10f;

    public PhotonView pv;

    private SpriteRenderer terbang1;
    private Vector3 gerakBebas;
    public Rigidbody2D rb;
    public GameObject senapanTembak;
    public Transform tempatBidik;

    public static bool Mine = false;
    public static bool Yours = false;

    // Use this for initialization
    void Start () {
        //projectileVelocity = 3;
        if (pv.IsMine)
        {
            this.gameObject.tag = "Player";
            rb = GetComponent<Rigidbody2D>();
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
        if (photonView.IsMine)
        {
            senapanTembak.gameObject.tag = "MyAmmo";
            Updown();
        }
        else
        {
            senapanTembak.gameObject.tag = "YourAmmo";
            pergerakanLain();
        }
    }

    private void pergerakanLain()
    {
        transform.position = Vector3.Lerp(gerakBebas, transform.position, Time.deltaTime * 10);
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

        if (CrossPlatformInputManager.GetButtonDown("Shoot"))
        {
            GameObject senapan;
            senapan = PhotonNetwork.Instantiate(senapanTembak.name, tempatBidik.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x , directiony * moveSpeed);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else if (stream.IsReading)
        {
            gerakBebas = (Vector3)stream.ReceiveNext();
        }
    }
}
