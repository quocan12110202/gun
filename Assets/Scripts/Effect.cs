using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float life = 2f;
    void Start()
    {
        Destroy(gameObject, life);
    }

  
}
