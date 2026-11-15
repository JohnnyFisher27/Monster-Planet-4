using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int health;
    int maxhealth;
    void Start()
    {
        maxhealth = 10;
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
