using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvents : MonoBehaviour
{
    public void playSound(string _name)
    {
        AudioManager.instance.Play(_name);
    }
}
