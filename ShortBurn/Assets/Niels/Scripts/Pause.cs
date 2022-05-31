using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject blur;
    [SerializeField] private GameObject pausePanel;

    public Volume Volume;
    private Bloom Bloom;
    public bool pausing = false;
    void Update()
    {
        Bloom tmp;

        if (Volume.profile.TryGet<Bloom>(out tmp))
        {
            Bloom = tmp;

            if (pausing)
                Bloom.threshold.value = Mathf.MoveTowards(Bloom.threshold.value, Bloom.threshold.value = 0, 1 * Time.deltaTime);
            else if (pausing == false)
                Bloom.threshold.value = Mathf.MoveTowards(Bloom.threshold.value, Bloom.threshold.value = 1, 1 * Time.deltaTime);

            if (Bloom.threshold.value <= 0.2f)
                Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0.001f, 0.2f * Time.maximumDeltaTime);
            else if (Bloom.threshold.value == 1)
                blur.SetActive(false);
            else if(Bloom.threshold.value >= 0.5f)
                Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1, 0.2f * Time.maximumDeltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeInHierarchy)
            {
                pausing = false;
                Time.timeScale = 1;
                pausePanel.SetActive(false);
            }
            else
            {
                pausing = true;
                blur.SetActive(true);
                pausePanel.SetActive(true);
            }
        }
    }
}
