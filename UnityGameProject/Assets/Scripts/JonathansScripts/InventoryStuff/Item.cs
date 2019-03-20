﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	public string ItemName;
	public string ItemDesc;
	public Sprite ItemSprite;
	public Sprite ItemInvImage;
	public GameObject ItemObject;
	public bool IsNotCollectable;

	private InventoryScript InvScript;


	public void Start()                            // Setting up the item when it is on a object to have default values
	{
		InvScript = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();
		ItemSetup();
	}


	public void ItemSetup()
	{
		ItemObject = gameObject;

		if (ItemName == "")
		{
			ItemName = gameObject.name;
		}
	}


	public void AddToInv(Item i)
	{
		if (!IsNotCollectable)
		{
			InvScript.AddItem(i);
		}
	}

	public void RemoveItemFromInv()
	{
		InvScript.RemoveItem();
	}


	private void OnCollisionExit2D(Collision2D collision)
	{
		if (GetComponent<Item>().enabled == false)
		{
			GetComponent<Item>().enabled = true;
		}
	}


	internal bool IsSpriteNull(Sprite Input)
	{
		if (Input != null) { return false; }
		else { return true; }
	}
}
