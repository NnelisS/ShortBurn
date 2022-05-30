using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject volume;
    [SerializeField] private GameObject pausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeInHierarchy == false)
            {
                Time.timeScale = 0.001f;
                volume.SetActive(true);
                pausePanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                volume.SetActive(false);
                pausePanel.SetActive(false);
            }
        }
    }
}
