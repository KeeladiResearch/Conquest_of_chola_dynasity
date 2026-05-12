using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public static RewardManager Instance;
    void Awake() { if (Instance == null) Instance = this; }

    public void UnlockReward(int level)
    {
        switch (level)
        {
            case 2: GrantNewWeapon(); break;
            case 3: GrantArmorBonus(); break;
            case 4: UnlockNewMap(); break;
        }
    }

    void GrantNewWeapon() => Debug.Log("Unlocked new weapon!");
    void GrantArmorBonus() => Debug.Log("Gained armor bonus!");
    void UnlockNewMap() => Debug.Log("New region unlocked!");
}
