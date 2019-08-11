using Newtonsoft.Json;
using PoolApiClientLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PoolApiClientLibrary
{
    public static class PoolStatusProccesor
    {
        public static MinerStatistics GetPoolStats(string minerAddress, string poolName)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Type myType = currentAssembly.GetType($"{currentAssembly.FullName.Substring(0, currentAssembly.FullName.IndexOf(','))}.{poolName}");
                        
            string methodName = "GetMiner";

            object[] parametersArray = new object[] { minerAddress };

            MethodInfo methodInfo = myType.GetMethod(methodName);
            Object classInstance = Activator.CreateInstance(myType, new object[] { });

            Miner miner = (Miner)methodInfo.Invoke(classInstance, parametersArray);
           
            MinerStatistics miningStatistics = null;

            try
            {
                miningStatistics = miner.GetStatisticsAsync().Result;
                var workerStatistics = miner.GetWorkersAsync().Result;
            }
            catch (Exception)
            {               
            }
            //string filePath = new FileInfo(Assembly.GetEntryAssembly().Location).Directory.ToString();
            //FileProcessor.WriteFile(miningStatistics, filePath);

            return miningStatistics;
        }
    }
}
