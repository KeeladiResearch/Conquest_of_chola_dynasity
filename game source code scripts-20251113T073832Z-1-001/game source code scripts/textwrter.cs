using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class textwrter : MonoBehaviour
{
    TextMeshProUGUI UItext;
    string text_to_write;
    int textindex;
    float timepertext;
    bool invisibletext;
    [SerializeField] float timer;
 

   public void Addwriter(TextMeshProUGUI UItext ,string text_to_write,float timepertext,bool invisibletext)
    {
        this.UItext = UItext;
        this.text_to_write = text_to_write;
        this.timepertext = timepertext;
        this.invisibletext = invisibletext;
        textindex = 0;


    }
    private void Update()
    {
        if (UItext!=null)
        {
            timer -= Time.deltaTime;
            while (timer <= 0)
            {
                timer += timepertext;
                textindex++;
                string text = text_to_write.Substring(0, textindex);
                if (invisibletext)
                {
                    text += "<color=#00000000>" + text_to_write.Substring(textindex) + "<color>";
                }
                UItext.text = text;
                if (textindex >=text_to_write.Length)
                {
                    UItext = null;
                
                    return;
                  
                }
                
               
            }
        }
    }
}
