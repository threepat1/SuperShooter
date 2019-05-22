using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SuperShooter
{

    public class Enemy : MonoBehaviour
    {

        public int health = 100;
        public int damage = 25;

        public Transform player;
        private NavMeshAgent nav;

        // ------------------------------------------------- //

        public void DealDamage(int amount)
        {
            // Deal DMG
            health -= amount;

            // Dead
            if (health <= 0)
                Destroy(gameObject);
        }


        // ------------------------------------------------- //
        public void Start()
        {
            nav = GetComponent<NavMeshAgent>();
        }
        public void Update()
        {
            nav.SetDestination(player.position);
        }
        public void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == ("Player"))
            {
                DealDamage(damage);
                print("yes!!");
            }
        }
    }


    }

