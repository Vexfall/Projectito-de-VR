using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private static GameObject Player;
    private static GameObject previusWaypoint;

    void Awake()
    {
        if (!Player)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void Move()
    {
        Player.transform.position = this.transform.position;

        if (previusWaypoint)
        {
            previusWaypoint.SetActive(true);
        }

        previusWaypoint = this.gameObject;
        this.gameObject.SetActive(false);
    }
}
