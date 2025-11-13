using UnityEngine;

public class RewardChest : MonoBehaviour
{
    public Animator chestAnimator;
    public AudioSource rewardSound;

    public void OpenChest()
    {
        chestAnimator.SetTrigger("Open");
        rewardSound.Play();
        GrantTemplePoints();
    }

    void GrantTemplePoints()
    {
        TempleSystem.Instance.AddTemplePoints(Random.Range(10, 25));
    }
}
