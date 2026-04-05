using Unity.Cinemachine;
using UnityEngine;

public class GestionCam : MonoBehaviour
{
    public Rigidbody rb;
    private float acceleration;
    private float lastVelocity;
    private float currentVelocity;

    public float VitesseMouv = 0.1f;
    public Speedometer speedometer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currentVelocity = rb.linearVelocity.magnitude;
        acceleration = ((currentVelocity - lastVelocity) / Time.deltaTime);
        lastVelocity = currentVelocity;

        GetComponent<CinemachineCamera>().Lens.FieldOfView = Mathf.Lerp(50, 80, speedometer.kmPerHour * 0.0075f);

        if (Vector3.Dot(transform.forward, rb.linearVelocity) < 0)
        {
            GetComponent<CinemachineCamera>().Lens.FieldOfView = 50;

        }

        GetComponent<CinemachineFollow>().FollowOffset.z = Mathf.Lerp(-6,-7, speedometer.kmPerHour * VitesseMouv);

       
    }
}
