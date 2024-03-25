using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Equipment;

public class Weapon : Item
{
   public int Damage { get; set; }

    public WeaponType wpType { get; set; }
    public Weapon(int id, string name, ItemType itemType, string des, int capacity, int buyprice, int sellprice, string sprite,int damage,WeaponType WpType 
        ) : base(id, name, itemType, des, capacity, buyprice, sellprice, sprite)
    {
       this.Damage = damage;
        this.wpType = WpType;
    }
    public enum WeaponType
    {
        MainHand,
    }
}
