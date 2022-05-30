using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject volume;
    [SerializeField] private GameObject pausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeInHierarchy)
            {
                Time.timeScale = 1;
                volume.SetActive(false);
                pausePanel.SetActive(false);
            }
            else
            {
                Time.timeScale = 0.001f;
                volume.SetActive(true);
                pausePanel.SetActive(true);
            }
        }
    }
}
