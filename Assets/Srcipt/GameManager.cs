using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gameOverCanvas;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        AudioManager.Instance.musicSource.Stop();
         AudioManager.Instance.PlaySFX("GameOver");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.Instance.PlaySFX("Start");
        AudioManager.Instance.musicSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
         if (!AudioManager.Instance.musicSource.isPlaying)
        {
            AudioManager.Instance.musicSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
