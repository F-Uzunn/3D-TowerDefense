using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();

        target = AIPaths.paths[0];
    }

    void Update()
    {
        transform.LookAt(target);
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            NextPath();
        }

        enemy.speed = enemy.startSpeed;

    }


    void NextPath()
    {
        if (wavepointIndex >= AIPaths.paths.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = AIPaths.paths[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawn.EnemiesAlive--;
        Destroy(gameObject);
    }
}
