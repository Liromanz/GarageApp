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
    internal class ApiConnector : DataSender
    {
        public static async Task<ObservableCollection<T>> GetAll<T>(string tableName)
        {
            string responseBody = await GetRequest(tableName);
            return (ObservableCollection<T>)JsonConvert.DeserializeObject(responseBody, typeof(ObservableCollection<T>));
        }
    }
}
