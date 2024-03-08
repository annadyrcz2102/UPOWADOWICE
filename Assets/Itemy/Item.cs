using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="SO/CreateItem")]
public class Item : ScriptableObject
{
    public Sprite ItemSprite;
    public string ItemName;
    public float Cooldown;
}
