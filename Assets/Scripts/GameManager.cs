using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action eventIsDead;
    public static Action eventWinner;
    public static GameManager Instance { get; private set; }

    public GameObject textWinner;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        textWinner.SetActive(false);
    }

    void Win()
    {
        textWinner.SetActive(true);
        Time.timeScale = 0;
    }

    void Dead()
    {
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        eventIsDead += Dead;
        eventWinner += Win;
    }

    private void OnDisable()
    {
        eventIsDead -= Dead;
        eventWinner -= Win;
    }
}
