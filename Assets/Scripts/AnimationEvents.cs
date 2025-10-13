using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public GameObject Laser1;
    public void TurnOffLaser()
    {
        Laser1.SetActive(false);
    }
    public void TurnOnLaser()
    {
        Laser1.SetActive(true);
    }
}
