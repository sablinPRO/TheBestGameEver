﻿using UnityEngine;
using UnityEngine.UIElements;

public class Fireball : MonoBehaviour

{
    public float speed;
    public float lifetime;
    public float damage = 10;

    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward* speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyFireball();
    }
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.value -= damage;
            if (enemyHealth.value <= 0)
            {
                Destroy(enemyHealth.gameObject);
            }
        }
    }
}
