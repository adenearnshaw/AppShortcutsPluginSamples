﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppShortcutsMasterDetailTest.Models;

namespace AppShortcutsMasterDetailTest.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = "Item_1", Text = "First item", Description="This is an item description." },
                new Item { Id = "Item_2", Text = "Second item", Description="This is an item description." },
                new Item { Id = "Item_3", Text = "Third item", Description="This is an item description." },
                new Item { Id = "Item_4", Text = "Fourth item", Description="This is an item description." },
                new Item { Id = "Item_5", Text = "Fifth item", Description="This is an item description." },
                new Item { Id = "Item_6", Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}