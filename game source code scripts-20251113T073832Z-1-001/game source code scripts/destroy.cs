using UnityEngine;

public class destroy : MonoBehaviour
{
    public float time = 5;
    void Start()
    {
        Destroy(this.gameObject,time);
    }

}
