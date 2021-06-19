using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy : MonoBehaviour
{
    public float CountEnergy { get; private set;}
    private playerRobot _player;

    private void Start()
    {
        _player = playerRobot.ItsPlayer;
        _player.some += P;
        CountEnergy = 100;
    }
    
    public float toSendEnergy(float playerEnergy)
    {
        CountEnergy--;
        return playerEnergy += 1;
    }
    public void P()
    {
        print("halilua");
    }
}
