﻿using GarageApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Data
{
    public class ApiConnector : DataSender
    {
        public static async Task<ObservableCollection<T>> GetAll<T>(string tableName)
        {
            string responseBody = await GetRequest(tableName);
            return (ObservableCollection<T>)JsonConvert.DeserializeObject(responseBody, typeof(ObservableCollection<T>));
        }
        public static async Task<Users> GetUser<T>(string tableName, object value)
        {
            string responseBody = await AuthRequest(tableName, value);
            return (Users)JsonConvert.DeserializeObject(responseBody, typeof(Users));
        }
    }
}
