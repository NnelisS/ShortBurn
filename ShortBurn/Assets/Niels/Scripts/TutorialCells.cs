using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class TutorialCells : MonoBehaviour
{    
    public Volume Volume;
    public bool Pausing = false;


    [SerializeField] private GameObject blur;
    [SerializeField] private GameObject pausePanel;

    private Bloom Bloom;
    private BoxCollider boxCol;

    private void Start()
    {
        boxCol = GetComponent<BoxCollider>();
    }

    void Update()
    {
        Bloom tmp;

        if (Volume.profile.TryGet<Bloom>(out tmp))
        {
            Bloom = tmp;

            if (Pausing)
            {
                Bloom.threshold.value = Mathf.MoveTowards(Bloom.threshold.value, Bloom.threshold.value = 0, 1 * Time.deltaTime);
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 1;
                    pausePanel.SetActive(false);
                    Pausing = false;
                }
            }
            else if (Pausing == false)
                Bloom.threshold.value = Mathf.MoveTowards(Bloom.threshold.value, Bloom.threshold.value = 1, 1 * Time.deltaTime);

            if (Bloom.threshold.value <= 0.2f)
                Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0.001f, 1 * Time.deltaTime);
            else if (Bloom.threshold.value == 1)
                blur.SetActive(false);
            else if (Bloom.threshold.value >= 0.5f)
                Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1, 1 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeInHierarchy)
            {
                Pausing = false;
                Time.timeScale = 1;
                pausePanel.SetActive(false);
            }
            else
            {
                Pausing = true;
                blur.SetActive(true);
                pausePanel.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Pausing = true;
            blur.SetActive(true);
            pausePanel.SetActive(true);
        }
    }
}
