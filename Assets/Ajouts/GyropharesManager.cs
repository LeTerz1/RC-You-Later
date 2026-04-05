using UnityEngine;
using System.Collections;

public class GyropharesManager : MonoBehaviour
{
    public GameObject gyroBleu;
    public GameObject gyroRouge;
    public float switchInterval = 0.5f; // Intervalle de temps entre les changements de couleur
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Switch());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Switch()
    {
        gyroBleu.SetActive(true);
        gyroRouge.SetActive(false);
        yield return new WaitForSeconds(switchInterval); // Attendre 0.5 seconde
        gyroBleu.SetActive(false);
        gyroRouge.SetActive(true);
        yield return new WaitForSeconds(switchInterval); // Attendre 0.5 seconde
        StartCoroutine(Switch()); // Relancer la coroutine pour continuer à alterner les couleurs
    }
}
