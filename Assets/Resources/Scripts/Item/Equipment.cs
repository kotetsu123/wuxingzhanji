using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{/// <summary>
/// 力量
/// </summary>
   public int Strength { get; set; }
    /// <summary>
    /// 智力
    /// </summary>
   public int Intellect { get; set; }
    /// <summary>
    /// 敏捷
    /// </summary>
   public int Agility { get; set; }
    /// <summary>
    /// 体力
    /// </summary>
    public int Stamina { get; set; }
    /// <summary>
    /// 装备类型
    /// </summary>
    public EquipmentType EquipType { get; set; }
    public Equipment(int id, string name, ItemType itemType, string des, int capacity, int buyprice, int sellprice, string sprite,int  str,int intellect,int Agi,int Sta,EquipmentType equiptype
        ):base(id, name, itemType, des, capacity, buyprice, sellprice, sprite)
    {
        this.Strength = str;
        this.Intellect = intellect;
        this.Agility = Agi;
        this.Stamina = Sta;
        this.EquipType = equiptype;
    }
    public enum EquipmentType
    {
        Head,
        Body,
        Leg,
        Boots
    }

}
