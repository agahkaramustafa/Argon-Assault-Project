using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard;
    [SerializeField] int increaseAmount = 15;
    [SerializeField] int enemyHitPoints = 6;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        scoreBoard.IncreaseScore(increaseAmount);
        enemyHitPoints--;

        if (enemyHitPoints == 0)
        {
            KillEnemy();
        }

        /*
        switch (enemyHitPoints)
        {
            case 4:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
                break;

            case 3:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                break;

            case 2:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;

            case 1:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                break;

            case 0:
                KillEnemy();
                break;

            default:
                return;
        }
        */
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
