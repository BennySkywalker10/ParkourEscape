using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    public GameObject projectile;
    private float obstacleSpawnInterval = 2.5f;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacles");
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector2(0f, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObstacle()
    {
        
            Instantiate(projectile, new Vector3(transform.position.x, -0.5f, 0), Quaternion.identity);

    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(obstacleSpawnInterval);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        //gameManager.AddScore();
        Destroy(gameObject);
    }
}
