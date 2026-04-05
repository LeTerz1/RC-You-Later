using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class VFXwindManager : MonoBehaviour
{
    public ParticleSystem particleSystem1; // Reference to the Particle System for wind effects
    public ParticleSystem particleSystem2; // Reference to the Particle System for other effects
    public ParticleSystem particleSystem3; // Reference to the Particle System for other effects
    public Speedometer speedometer; // Reference to the Speedometer script to get the current speed
    public float multiplier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        /*var main = particleSystem1.main;
        main.startSize = 0f;
        var main2 = particleSystem2.main;
        main2.startSize = 0f;
        var main3 = particleSystem3.main;
        main3.startSize = 0f;*/

    }

    // Update is called once per frame
    void Update()
    {
        if (speedometer.kmPerHour > 4f)
        {

            var main = particleSystem1.main;
            var main2 = particleSystem2.main;
            var main3 = particleSystem3.main;
            
            main.startSize = new ParticleSystem.MinMaxCurve(0.01f, 0.02f);
            main2.startSize = new ParticleSystem.MinMaxCurve(0.01f,0.02f );
            main3.startSize = new ParticleSystem.MinMaxCurve(0.01f, 0.02f);


            main.startSpeed = speedometer.kmPerHour * multiplier;
            main2.startSpeed = speedometer.kmPerHour * multiplier;
            main3.startSpeed = speedometer.kmPerHour * multiplier;


        }
        else
        {
            var main = particleSystem1.main;
            var main2 = particleSystem2.main;
            var main3 = particleSystem3.main;

            main.startSize = 0;
            main2.startSize = 0;
            main3.startSize = 0;
        }


        /*if (rb.linearVelocity.magnitude > 4f)
        {
            particleSystem1.Play();
        }
        else
        {

            particleSystem1.Stop();

        }*/
    }
}
