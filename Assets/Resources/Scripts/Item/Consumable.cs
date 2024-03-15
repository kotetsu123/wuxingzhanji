using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ÏûºÄÆ·
/// </summary>
public class Consumable : Item
{
    public int Hp { get; set; }
    public int Mp { get; set; }
    public Consumable(int id, string name, ItemType itemType, string des, int capacity,string sprite, int hp, int mp)
        :base(id,name,itemType,des,capacity,sprite)
    {
        this.Hp = hp;
        this.Mp = mp;
    }
}
