using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    [SerializeField] private float timeBeforeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,timeBeforeDestroy);
    }

   
}
