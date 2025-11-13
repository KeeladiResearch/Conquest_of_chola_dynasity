using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour
{
    public Image characterDisplay;
    public Sprite[] characterSprites; // index: 0=CholaKing, 1=Soldier, 2=Enemy

    public void SetCharacter(int index)
    {
        if (index < 0 || index >= characterSprites.Length) return;
        characterDisplay.sprite = characterSprites[index];
    }
}
