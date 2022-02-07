using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    [Header("GameControl Reference")]
    public GameControlScript GCSref;
    [Header("Particle System Reference")]
    public ParticleSystem ps;
    [Header("Variables")]
    public bool ParticlePlayed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GCSref.gamePlaying == true )
        {
            if(ParticlePlayed == false && GCSref.won == false)
            {
                ps.Play();
                ParticlePlayed = true;
            }
            else if(GCSref.won == true)
            {
                ps.Stop();
                ParticlePlayed = false;
            }
        }

        /*
        Makes sure the particle system plays once the game has been started and stops once the game 
        has been won so it can be restarted again.
        */
    }

    void OnParticleTrigger()
    {
        // particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        // get
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        GCSref.DustCollected += (float)numEnter;

        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.remainingLifetime = 0;
            enter[i] = p;
        }
        
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        //ParticleSystem.Particle.remainingLifetime = 0;

        /*
        Gets each particle that enters the trigger box on player: KillParticle
        Adds particles to a list then for each particle, increments the DustCollected value
        and deletes said particle. This ensures the particles cannot be double counted and allows 
        for a win condition of 50 particles to be met once DustCollected == 50 in the GameControl script
        */
            
    }
}
