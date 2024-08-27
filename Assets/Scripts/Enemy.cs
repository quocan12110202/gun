using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movespeed = 2f;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject == null)
        {
            playerObject = FindObjectOfType<GameObject>();
        }
        if(playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.Log("no player");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (playerTransform != null)
            {
                Vector3 direction = (playerTransform.position - transform.position).normalized;
                transform.Translate(direction * movespeed * Time.deltaTime);
            }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Player")
        {
            collision.gameObject.SetActive(false);
            AudioManager.instance.PlayDeadClip();
            GameManager.Instance.EnemySkillPlayer();
        }
        if(collision.tag== "Bullet")
        {
            GameManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
