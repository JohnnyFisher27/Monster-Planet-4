using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject bullet;

    void Awake()
    {
        GameManager.Instance.projectileManager = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(Vector2 spawn, Vector2 direction, int dmg, Vector2 momentum = default(Vector2))
    {
        GameObject projectile = Instantiate(bullet, spawn + direction.normalized, Quaternion.FromToRotation(Vector2.right, direction));
        ProjectileDamage traits = projectile.AddComponent<ProjectileDamage>();
        traits.damage = dmg;
        traits.direction = (direction).normalized;
        traits.playerMomentum = momentum;
        StartCoroutine(Expire(projectile));
    }

    private IEnumerator Expire(GameObject obj)
    {
        yield return new WaitForSeconds(5);
        Destroy(obj);
    }
}
