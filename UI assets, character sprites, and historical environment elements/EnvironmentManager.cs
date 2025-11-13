using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public GameObject[] environments; // 0=Temple, 1=Battlefield, 2=Fort
    private int currentEnvironment = 0;

    public void LoadEnvironment(int index)
    {
        if (index < 0 || index >= environments.Length) return;

        foreach (var env in environments)
            env.SetActive(false);

        environments[index].SetActive(true);
        currentEnvironment = index;
        Debug.Log($"Environment set to: {environments[index].name}");
    }
}
