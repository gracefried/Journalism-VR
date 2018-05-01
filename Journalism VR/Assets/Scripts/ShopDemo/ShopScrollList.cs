using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;
    //public Sprite icon;
    //public float price = 1f;
}

public class ShopScrollList : MonoBehaviour
{

    public List<string> itemList;
    public List<SampleButton> buttonList;
    public Transform contentPanel;
    //public ShopScrollList otherShop;/
    //public Text myGoldDisplay;
    public SimpleObjectPool buttonObjectPool;
    public float gold = 20f;
    public RectTransform scrollbar;
    public float delay;
    public int curBut;
    public bool headline;
    public bool canUse;


    // Use this for initialization
    void Start()
    {
        itemList = FindObjectOfType<InfoTriggers>().getHeadlines();
        //else { itemList = FindObjectOfType<InfoTriggers>().getComments(); }
        buttonList = new List<SampleButton>();
        curBut = 0;
        delay = 0;
        RefreshDisplay();
        //scrollbar.gameObject.SetActive(true);
    }

    void Update()
    {
        delay -= Time.deltaTime;
        if (canUse == true && buttonList.Count > 0) { listScroll(); }
    }

    public void RefreshDisplay()
    {
        //myGoldDisplay.text = "Gold: " + gold.ToString();
        RemoveButtons();
        AddButtons();
        curBut = 0;
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0) 
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++) 
        {
            string item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);
            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(item, this.transform.GetComponent<ShopScrollList>());
            buttonList.Add(sampleButton);
        }
    }

    /*public void TryTransferItemToOtherShop(Item item)
    {
        if (otherShop.gold > item.price) 
        {
            gold += item.price;
            otherShop.gold -= item.price;

            AddItem(item, otherShop);
            RemoveItem(item, this);

            RefreshDisplay();
            otherShop.RefreshDisplay();
            Debug.Log("enough gold");

        }
        Debug.Log("attempted");
    }*/

    void AddItem(string itemToAdd, ShopScrollList shopList)
    {
        shopList.itemList.Add(itemToAdd);
    }
/*
    private void RemoveItem(Item itemToRemove, ShopScrollList shopList)
    {
        for (int i = shopList.itemList.Count - 1; i > 0; i--) 
        {
            if (shopList.itemList[i] == itemToRemove)
            {
                shopList.itemList.RemoveAt(i);
            }
        }
    }*/

    void listScroll()
    {
        buttonList[curBut].nameLabel.GetComponent<Text>().color = new Color(255, 255, 0, 255);
        if(Input.GetAxis("Vertical") < 0 && delay <= 0) { Down(); }
        if(Input.GetAxis("Vertical") > 0 && delay <= 0) { Up(); }
        if (Input.GetKeyDown("z")) { buttonList[curBut].HandleClick(); }
        scrollbar.GetComponent<Scrollbar>().value = 1 - (float)curBut / (float)buttonList.Count;
    }

    void Up()
    {
        buttonList[curBut].nameLabel.GetComponent<Text>().color = new Color(0, 0, 0, 255);
        if (curBut == 0) { curBut = buttonList.Count - 1;}
        else { curBut--; }
        delay = 1;
        Debug.Log("Up");
    }

    void Down()
    {
        buttonList[curBut].nameLabel.GetComponent<Text>().color = new Color(0, 0, 0, 255);
        if (curBut == buttonList.Count - 1) { curBut = 0; }
        else { curBut++; }
        delay = 1;
    }
}
