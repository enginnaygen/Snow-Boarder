using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] float delay = 0.5f;
    [SerializeField] ParticleSystem finishEffect;
    AudioSource _as;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        finishEffect.Play();
        _as.Play();
        Invoke("ReloadScene", delay);  
    }

    void ReloadScene()
    {
        Debug.Log("You Finishh!!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
