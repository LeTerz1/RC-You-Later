using UnityEngine;

public class CompteurManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform aiguilleAncre;
    private Speedometer speedometer;
    public float compteurRotationSpeed = 0.006f;
    void Start()
    {
        speedometer = GetComponentInChildren<Speedometer>();
    }

    // Update is called once per frame
    void Update()
    {
        aiguilleAncre.localRotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, -65), speedometer.kmPerHour * 0.006f);

        transform.localRotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 30, -25), speedometer.kmPerHour * compteurRotationSpeed);
    }
}
