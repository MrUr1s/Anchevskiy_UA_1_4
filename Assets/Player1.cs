using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Players
{    
    enum PlayerWay { SquareWay, TriangleWay }

    [SerializeField] private PlayerWay playerWay = 0;
    private PlayerWay playerWayCurrent= (PlayerWay) (-1);


    void Start()
    {
        StartCoroutine(Move());
    }

    protected override void SwitchWay()
    {
        if (playerWayCurrent != playerWay)
        {
            Clear();
            switch (playerWay)
            {
                case 0:
                    _way = new List<Vector3>
                    { start_pos+ new Vector3(0, 0, 0),  start_pos+new Vector3(0, 0, 10), start_pos+ new Vector3(10, 0, 10), start_pos+ new Vector3(10, 0, 0) };
                    playerWayCurrent = 0;
                    break;
                case (PlayerWay)1:
                    _way = new List<Vector3>
                    { start_pos+ new Vector3(0, 0, 0), start_pos+ new Vector3(0, 0, 10), start_pos+ new Vector3(10, 0, 10) };
                    playerWayCurrent = (PlayerWay)1;
                    break;
            }

        }
    }
}

