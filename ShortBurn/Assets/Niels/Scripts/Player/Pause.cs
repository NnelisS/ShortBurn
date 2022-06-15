using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class Pause : MonoBehaviour
{   
    public Volume Volume;
    public bool Pausing = false;
    public Animator PanelAnim;

    private bool usable = true;

    [SerializeField] private GameObject blur;
    [SerializeField] private GameObject pausePanel;

    private Bloom Bloom;

    void Update()
    {
        Bloom tmp;

        if (Volume.profile.TryGet<Bloom>(out tmp))
        {
            Bloom = tmp;

            if (Pausing)
                Bloom.threshold.value = Mathf.MoveTowards(Bloom.threshold.value, Bloom.threshold.value = 0, 1 * Time.deltaTime);
            else if (Pausing == false)
                Bloom.threshold.value = Mathf.MoveTowards(Bloom.threshold.value, Bloom.threshold.value = 1, 1 * Time.deltaTime);

            if (Bloom.threshold.value <= 0.2f)
                Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0.001f, 1 * Time.deltaTime);
            else if (Bloom.threshold.value == 1)
                blur.SetActive(false);
            else if(Bloom.threshold.value >= 0.5f)
                Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1, 1 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && usable)
        {
            if (pausePanel.activeInHierarchy)
            {
                StartCoroutine(PauseAnim());
                Pausing = false;
                Time.timeScale = 1;
                pausePanel.SetActive(false);
            }
            else
            {
                StartCoroutine(PauseAnim());
                Pausing = true;
                blur.SetActive(true);
                pausePanel.SetActive(true);
            }
        }
    }

    private IEnumerator PauseAnim()
    {
        if (pausePanel.activeInHierarchy)
            PanelAnim.Play("Pausing");
        else
            PanelAnim.Play("UnPausing");

<<<<<<< HEAD
        yield return new WaitForSeconds(2);
=======
            if (restartOption)
            {
                CheckpointAnimBack.Play("CheckPointBack");
                restartOption = false;
            }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Pausing = false;
            pausePanel.SetActive(false);
        }
        else
        {
            PanelAnim.Play("Pausing");

            if (restartOption)
                CheckpointAnimBack.Play("CheckPointBack");

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            blur.SetActive(true);
            yield return new WaitForSeconds(1);
            pausePanel.SetActive(true);
        }

        yield return new WaitForSeconds(2);
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(PauseAnim());
        Pausing = false;
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        if (restartOption)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
            CheckpointAnimBack.Play("CheckPoint");

        restartOption = true;
    }

    public void CheckPointRestart()
    {

        if (checkPointManager != null)
            checkPointManager.Respawn();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(PauseAnim());
        Pausing = false;
        pausePanel.SetActive(false);
>>>>>>> parent of 6369d96 (Pause Update)
    }
}
