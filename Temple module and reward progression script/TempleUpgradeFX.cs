using UnityEngine;

public class TempleUpgradeFX : MonoBehaviour
{
    public ParticleSystem upgradeFX;
    public AudioSource upgradeSound;

    public void PlayFX()
    {
        upgradeFX.Play();
        upgradeSound.Play();
    }
}
