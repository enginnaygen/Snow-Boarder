using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CruhsHead : MonoBehaviour
{
    [SerializeField] float delay=0.5f;
    [SerializeField] ParticleSystem crushEffect;
    [SerializeField]AudioClip ac;
    bool _crash=false;

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Ground" && !_crash)
        {
            _crash = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crushEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(ac);
            Invoke("ReloadScene", delay);
        }
    }


    void ReloadScene()
    {
        FindObjectOfType<PlayerController>().ActiveControls();
        Debug.Log("Hit my head,Ouchh");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _crash = false;
    }
}
