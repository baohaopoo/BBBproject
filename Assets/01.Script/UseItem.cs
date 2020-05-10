using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{

    public ParticleSystem particle;
    // Start is called before the first frame update
    List<ParticleCollisionEvent> collisionEvents;
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
        
    }
    private void OnParticleCollision(GameObject other)
    {
        //ParticlePhysicsExtensions.GetCollisionEvents(particle, other, collisionEvents);

        //for (int i = 0; i < collisionEvents.Count; ++i)
        //{ 
        //    EmitAtLacation(colli)
        //}

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {

            ParticleSystem.MainModule psMain = particle.main;

        }

    }
}
