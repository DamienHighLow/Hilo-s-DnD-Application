using DnDApplication.Classes.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace DnDApplication.Classes
{
    internal class Inventory
    {
        private ItemTable itemTable = new ItemTable();
        private Dictionary<string, int> items = new Dictionary<string, int>();
        private Dictionary<string, bool> relics = new Dictionary<string, bool>(); 
        private int maxWeight { get; set; }
        private int totalWeight { get; set; }
        private int money { get; set; }

        private bool ValidateItem(string itemName)
        {
            // Ensures that an item is a real applicable item.
            if (ItemTable.GetItem(itemName) == null) return false;
            else return true;
        }

        private string GetRelicType(string relicName)
        {
            return "";
        }

        public string DisplayInventory()
        {
            string formattedInv = "";

            if (items.Count > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    formattedInv += $"{items.Keys.ElementAt(i)} - {items.Keys.ElementAt(i)}x";
                }
            }

            return formattedInv;
        }

        public List<object>? GetItem(string itemName)
        {
            List<object> item = new List<object>();
            if (items.ContainsKey(itemName))
            {
                item.Add(itemName);
                item.Add(items[itemName]);

                return item;
            }

            return null;
        }

        public List<string> GetItems()
        {
            List<string> currentItems = new List<string>();

            for (int i = 0; i < currentItems.Count; i++)
            {
                currentItems.Add(currentItems[i]);
            }

            return currentItems;
        } 

        public void AddItem(string itemName, int amount)
        {
            // Ensures the item exists
            if (ValidateItem(itemName))
            {
                // Checks to see if the user has the item in their inventory
                if (items.ContainsKey(itemName))
                {
                    // Checks if an int was entered and if it's valid.
                    if (amount > 0)
                    {
                        // adds the amount to the item
                        items[itemName] += amount;
                    }
                    else
                    {
                        // adds a single item
                        items[itemName]++;
                    }
                }
                else
                {
                    if (amount > 0)
                    {
                        // Initializes the item with the specified amount
                        items[itemName] = amount;
                    }
                    else
                    {
                        // Initialized the item with a single amount
                        items[itemName] = 1;
                    }
                }
            }
        }

        public void RemoveItem(string itemName, int amount=0)
        {
            // Ensures the item exists
            if (ValidateItem(itemName))
            {
                // Checks to see if the user has the item in their inventory
                if (items.ContainsKey(itemName))
                {
                    // Checks if an int was entered and if it's valid.
                    if (amount > 0)
                    {
                        // If the item's amount would be 0 or under 0, removes the item from the player's inventory
                        if (items[itemName] - amount <= 0)
                        {
                            items.Remove(itemName);
                        }
                        else
                        {
                            // Removes the amount from the item
                            items[itemName] -= amount;
                        }
                    }
                    else
                    { 
                        // Removes the item if an item isn't given or amount is invalid.
                        items.Remove(itemName);
                    }
                }
            }
        }

        public void AddRelic(string relicName)
        {
            // Adds a relic to the inventory
            relics.Add(relicName, false);
        }

        public void RemoveRelic(string relicName)
        {
            // Ensures the relic exists before removing it.
            if (relics.ContainsKey(relicName))
            {
                relics.Remove(relicName);
            }
        }

        public void EquipRelic(string relicName)
        {
            // Equips a Relic
            if (relics.ContainsKey(relicName))
            {
                relics[relicName] = true;
            }
        }

        public void UnequipRelic(string relicName) {
            // Unequips a Relic
            if (relics.ContainsKey(relicName))
            {
                relics[relicName] = false;
            }
        }
    }
}
