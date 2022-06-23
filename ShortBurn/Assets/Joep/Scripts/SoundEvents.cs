using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvents : MonoBehaviour
{
    public bool UseTrigger;
    public string SoundName;

    private void OnTriggerEnter(Collider coll)
    {
        if (UseTrigger)
        {
            if (coll.gameObject.CompareTag("Player"))
                playSound(SoundName);
        }
    }


    public void playSound(string _name)
    {
        AudioManager.instance.Play(_name);
    }
}
