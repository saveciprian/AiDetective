using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Characters")]
public class SO_CharacterPanel : ScriptableObject {

    public string characterName;
    public string dialogueName;
    public string description;
    public Sprite image;
    public float width;
    public float height;
    public float posX;
    public float posY;
    public Color hexCodeMenu;
    public Color scrollBar;
    public ColorBlock scrollBarColors;


}
