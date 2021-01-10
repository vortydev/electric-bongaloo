using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float dmg;
    [SerializeField] Roaming roaming;

    public void Die()
    {
        gameObject.SetActive(false);
        roaming.SetDestination(gameObject);

    }

    public void Respawn()
    {
        gameObject.transform.position = gameObject.transform.parent.transform.position;
        gameObject.SetActive(true);
    }

    public float GetDmg()
    {
        return dmg;
    }
}