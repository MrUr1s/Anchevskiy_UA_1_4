using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Players
{
    enum PlayerWay { StarWay, HexagonWay }

    [SerializeField] private PlayerWay playerWay = (PlayerWay)0;
    private PlayerWay playerWayCurrent= (PlayerWay)(-1);

    protected override void SwitchWay()
    {
        if (playerWayCurrent != playerWay)
        {
            playerWayCurrent = playerWay;
            Clear();
            switch (playerWay)
            {
                case 0:
                    _way = new List<Vector3>
                    { start_pos+new Vector3(0, 0, 0), start_pos+ new Vector3(5, 0, 15), start_pos+ new Vector3(10, 0, 0),  start_pos+new Vector3(0, 0, 10), start_pos+ new Vector3(10, 0, 10) };
                    break;
                case (PlayerWay)1:
                    _way = new List<Vector3>
                    { start_pos+ new Vector3(0, 0, 0), start_pos+ new Vector3(-5, 0, 5), start_pos+ new Vector3(-5, 0, 10) , start_pos+ new Vector3(0, 0, 15) , start_pos+ new Vector3(5, 0, 10) , start_pos+ new Vector3(5, 0, 5) };
                    break;
            }

        }
    }
}
