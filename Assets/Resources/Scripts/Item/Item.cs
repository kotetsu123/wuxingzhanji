using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物品基类
/// </summary>
public class Item 
{
    public int ID { get; set; }
    public string Name { get; set; }

    public ItemType itemType { get; set; }

    public string Description { get; set; }
    public int Capacity { get; set; }

    public int BuyPrice { get; set; }

    public int SellPrice { get; set; }
    public string sprite { get; set; }

    public Item()
    {
        this.ID = -1;
    }
    public Item(int id,string name,ItemType itemType,string des,int capacity,int buyprice,int sellprice,string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.itemType = itemType;
        this.Description= des;
        this.Capacity = capacity;
        this.BuyPrice = buyprice;
        this.SellPrice = sellprice;
        this.sprite = sprite;
    }
    /// <summary>
    /// 物品类型
    /// </summary>
    public enum ItemType
    {
        Consumable,
        Equipment,
        Material,
        Weapon,
    }
   
}
