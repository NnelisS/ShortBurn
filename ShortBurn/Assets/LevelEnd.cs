using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class LevelEnd : MonoBehaviour
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
                Bloom.threshold.value = Mathf.MoveTowards(Bloom.threshold.value, Bloom.threshold.value = 0, 1.5f * Time.deltaTime);

            if (Bloom.threshold.value <= 0.2f)
                Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0.001f, 0.2f * Time.maximumDeltaTime);
            else if (Bloom.threshold.value == 0)
                pausePanel.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pausing = true;
            blur.SetActive(true);
        }
    }
}
