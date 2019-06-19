using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    LifePlayerController lifePlayerController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "player2(Clone)")
        {
            lifePlayerController.lifePlayer[1]++;

        } else if (col.gameObject.name == "player1(Clone)")
        {
            lifePlayerController.lifePlayer[0]++;
        }
    }
}