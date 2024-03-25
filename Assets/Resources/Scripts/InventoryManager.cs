using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using Defective.JSON;

public class InventoryManager : MonoBehaviour
{
    #region ����ģʽ
    private static InventoryManager instance;

    public static InventoryManager Instance {
        get {
            if(instance == null)
            {
                //ֻ��ִ��һ��
                instance = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();//������Ʒ�Ƿǳ�������Դ�ģ������ڴ˴�ʹ������Ϊ�ù���ֻʹ��һ����˲Ż�ʹ��GameObject.Find����
            }
            return instance;
        }
        set { 

        }
    }
    #endregion
    /// <summary>
    /// ��Ʒ��Ϣ���б�
    /// </summary>
    private List<Item> itemList;
    /// <summary>
    /// ������Ʒ��Ϣ
    /// </summary>

    private void Start()
    {
        ParseItemJson();
    }
    void ParseItemJson()
    {
        itemList = new List<Item>();
        //�ı���unity����TextAsset���͵�
        TextAsset itemAsset = Resources.Load<TextAsset>("Scripts/Item/Item");
        string itemJson = itemAsset.text;//��Ʒ��Ϣ��json��ʽ
        //JsonMapper
        //Debug.Log(itemJson);
        JSONObject j = new JSONObject(itemJson);
        foreach(JSONObject temp in j.list)
        {
           // Debug.Log(temp["id"].ToString() + temp["name"].ToString());
            string typeStr = temp["type"].stringValue;
           // print(typeStr);
            Item.ItemType type = (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), typeStr);

            //������������Ĺ�������
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
