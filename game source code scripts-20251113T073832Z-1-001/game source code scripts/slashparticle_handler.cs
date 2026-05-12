using UnityEngine;
using UnityEngine.UI;

public class slashparticle_handler : MonoBehaviour
{
   
    [SerializeField] GameObject slash2;
    [SerializeField] GameObject slash3;
    [SerializeField] GameObject slash4;
    [SerializeField] GameObject jumpslash4;
    [SerializeField] public Text cointext;

    public static slashparticle_handler instance {  get; private set; }

    private void Awake()
    {
        instance = this;
    }



    public void enableslash2()
    {
        slash2.SetActive(true);
    }

    public void disableslash2()
    {
        slash2.SetActive(false);
    }

    public void enableslash3()
    {
        slash3.SetActive(true);
    }

    public void disableslash3()
    {
        slash3.SetActive(false);
    }

    public void enableslash4()
    {
        slash4.SetActive(true);
    }

    public void disableslash4()
    {
        slash4.SetActive(false);
    }

    public void enablejumpslash4()
    {
        jumpslash4.SetActive(true);
    }

    public void disablejumpslash4()
    {
        jumpslash4.SetActive(false);
    }
}
