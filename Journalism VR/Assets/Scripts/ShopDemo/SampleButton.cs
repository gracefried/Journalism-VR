﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{

    public Button buttonComponent;
    public Text nameLabel;
    //public Image iconImage;
    //public Text priceText;


    private string item;
    private ShopScrollList scrollList;

    // Use this for initialization
    void Start()
    {
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void Setup(string currentItem, ShopScrollList currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item;
        //iconImage.sprite = item.icon;
        //priceText.text = item.price.ToString();
        scrollList = currentScrollList;

    }

    public void HandleClick()
    {
        //scrollList.TryTransferItemToOtherShop(item);
        FindObjectOfType<InfoTriggers>().headline = nameLabel.text;
        Debug.Log("click");
    }
}
