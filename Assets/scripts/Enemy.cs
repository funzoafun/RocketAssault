using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject deathVfx;
    [SerializeField] GameObject hitVfx;
    GameObject parent;

    ScoreBoard scoreBoard;
    [SerializeField] int scorePerPoint = 10;
    
    [SerializeField] int hitPoint = 3;

    void Start()
    {
        scoreBoard = FindFirstObjectByType<ScoreBoard>();
        parent = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();
    }

    private void OnParticleCollision(GameObject other) {

        ProcessHit();

        if(hitPoint < 1)
        {
            DestroyEnemy();
        }
       
    }

    void DestroyEnemy()
    {
        GameObject vfx = Instantiate(deathVfx,transform.position,Quaternion.identity);
        vfx.transform.parent = parent.transform;
        Destroy(this.gameObject);
    }

    void ProcessHit()
    {
        hitPoint--;
        GameObject enemyHitVfx = Instantiate(hitVfx, transform.position , Quaternion.identity);
        enemyHitVfx.transform.parent = parent.transform;
        scoreBoard.IncreaseScore(scorePerPoint);
    }

    void AddRigidBody()
    {
        
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;

    }
}
