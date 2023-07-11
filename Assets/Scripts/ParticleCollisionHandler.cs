using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionHandler : MonoBehaviour
{
    private ParticleSystem myparticleSystem;

    private void Start()
    {
        myparticleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[myparticleSystem.GetSafeCollisionEventSize()];
        int numCollisionEvents = myparticleSystem.GetCollisionEvents(other, collisionEvents);

        // Aquí puedes implementar la lógica para manejar las colisiones internas de partículas.
        // Puedes acceder a la información de las partículas y realizar acciones personalizadas.

        // Ejemplo de acción: Destruir las partículas que colisionan entre sí.
        for (int i = 0; i < numCollisionEvents; i++)
        {
            ParticleCollisionEvent collisionEvent = collisionEvents[i];
            Destroy(collisionEvent.colliderComponent.gameObject);
        }
    }
}
