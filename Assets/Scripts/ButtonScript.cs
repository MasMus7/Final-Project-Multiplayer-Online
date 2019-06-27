using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityStandardAssets.CrossPlatformInput;

public class ButtonScript : MonoBehaviour
{
    public GameObject bulletPrefabBlue;
    public GameObject bulletPrefabRed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject p1 = GameObject.Find("player1(Clone)");
            GameObject bullet = PhotonNetwork.Instantiate(bulletPrefabBlue.name,
                new Vector3(p1.transform.position.x + 1.5f, p1.transform.position.y,
                p1.transform.position.z), Quaternion.Euler(0, 0, -90));
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        }
        else
        {
            GameObject p2 = GameObject.Find("player2(Clone)");
            GameObject bullet = PhotonNetwork.Instantiate(bulletPrefabRed.name,
                new Vector3(p2.transform.position.x - 1.5f, p2.transform.position.y, 
                p2.transform.position.z), Quaternion.Euler(0, 0, 90));
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }        
    }
}
