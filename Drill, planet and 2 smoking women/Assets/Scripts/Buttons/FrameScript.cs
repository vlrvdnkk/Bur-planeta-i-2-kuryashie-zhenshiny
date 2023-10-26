using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameScript : MonoBehaviour
{
    [SerializeField] private ShootPointScript _shoot;
    public void Enter()
    {
        _shoot.Cooldown();
    }
}
