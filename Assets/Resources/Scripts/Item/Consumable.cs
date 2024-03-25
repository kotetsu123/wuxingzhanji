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
    public Consumable(int id, string name, ItemType itemType, string des, int capacity,int buyprice,int sellprice,string sprite, int hp, int mp)
        :base(id,name,itemType,des,capacity,buyprice,sellprice,sprite)
    {
        this.Hp = hp;
        this.Mp = mp;
    }


    public override string ToString()
    {
        string s = "";
        s += ID.ToString();
        s += itemType;
        s += Description;
        s += Capacity;
        s += BuyPrice;
        s += SellPrice;
        s += sprite;
        s += Hp;
        s += Mp;
        return s;
    }
}
