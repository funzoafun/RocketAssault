using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] private ParticleSystem explosion;
    int currentSceneIndex;


    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter(Collider other) {
        StartCrashSequence();
        
    }

    void StartCrashSequence()
    {
        explosion.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerControl>().StopLasers();
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadScene",2f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
