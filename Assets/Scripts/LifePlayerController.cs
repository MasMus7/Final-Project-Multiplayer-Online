using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayerController : MonoBehaviour
{
    public int[] lifePlayer;

    // Start is called before the first frame update
    void Start()
    {
        lifePlayer[0] = 0;
        lifePlayer[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player 1 : " + lifePlayer[0]);
        Debug.Log("Player 2 : " + lifePlayer[1]);
    }
}
