using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    public static ParticleSystem DustParticles;
    public GameObject _DustParticles;
    
    void Start()
    {
        DustParticles = _DustParticles.GetComponent<ParticleSystem>();
    }

    public static void CreateDust()
    {
        DustParticles.Play();
    }
}