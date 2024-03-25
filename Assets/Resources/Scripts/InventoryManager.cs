using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using Defective.JSON;

public class InventoryManager : MonoBehaviour
{
    #region 单例模式
    private static InventoryManager instance;

    public static InventoryManager Instance {
        get {
            if(instance == null)
            {
                //只会执行一次
                instance = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();//查找物品是非常消耗资源的，但是在此处使用是因为该功能只使用一次因此才会使用GameObject.Find方法
            }
            return instance;
        }
        set { 

        }
    }
    #endregion
    /// <summary>
    /// 物品信息的列表
    /// </summary>
    private List<Item> itemList;
    /// <summary>
    /// 解析物品信息
    /// </summary>

    private void Start()
    {
        ParseItemJson();
    }
    void ParseItemJson()
    {
        itemList = new List<Item>();
        //文本在unity里是TextAsset类型的
        TextAsset itemAsset = Resources.Load<TextAsset>("Scripts/Item/Item");
        string itemJson = itemAsset.text;//物品信息的json格式
        //JsonMapper
        //Debug.Log(itemJson);
        JSONObject j = new JSONObject(itemJson);
        foreach(JSONObject temp in j.list)
        {
           // Debug.Log(temp["id"].ToString() + temp["name"].ToString());
            string typeStr = temp["type"].stringValue;
           // print(typeStr);
            Item.ItemType type = (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), typeStr);

            //解析对象里面的公有属性
            int id = (int)(temp["id"].floatValue);
            string name= temp["name"].stringValue;
            string description = temp["description"].stringValue;
            int capacity = (int)(temp["capacity"].floatValue);
            int buyPrice = (int)(temp["buyprice"].floatValue);
            int sellPrice = (int)(temp["sellprice"].floatValue);
            string sprite = temp["sprite"].stringValue;

            Item item = null;
           
            switch (type)
            {
                case Item.ItemType.Consumable:
                    int hp = (int)(temp["hp"].floatValue);
                    int mp = (int)(temp["mp"].floatValue);
                    item = new Consumable(id, name, type, description, capacity, buyPrice, sellPrice, sprite, hp, mp);
                    break;
                case Item.ItemType.Equipment:
                    //TODO
                    break;
                case Item.ItemType.Material:
                    //TODO
                    break;
                case Item.ItemType.Weapon:
                    //TODO
                    break;
               
            }
            itemList.Add(item);
            //Debug.Log(item);
        }
        
    }
}
