using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_temporature
{
    internal class _session_Class
    {

    }
    //======================PLC类，一个session代表一个连接设备====================================
    public class PlcSession
    {
        public string Name { get; set; }    //plc名字
        public Plc PlcInstance { get; set; }        //plc实例
        public bool IsConnected { get; set; } = false;      //状态位
        public TemperatureData TemperatureData { get; set; }        //存储该PLC采集的温度数据
        //构造函数，创建实例时自动初始化实例
        public PlcSession(string name, CpuType CpuType, string ip, short rack = 0, short slot = 1)
        {
            Name = name;
            PlcInstance = new Plc(CpuType, ip, rack, slot);
            TemperatureData = new TemperatureData(120);
        }
        //===============异步连接方法=================
        public async Task connectAsync()
        {
            await PlcInstance.OpenAsync();
            IsConnected = PlcInstance.IsConnected;      //后面这个IsConnected是S7.Net自带的一个方法
        }
        //==============异步断开方法=================
        public void Disconnected()
        {
            if (PlcInstance != null && PlcInstance.IsConnected)
            {
                PlcInstance.Close();
                IsConnected = false;
            }
        }


    }
    //=========================SessionManager类，全局管理PLC,全局唯一=======================================================
    public static class SessionManager
    {
        //字典，存储已连接的PLC
        public static Dictionary<string, PlcSession> _sessions = new Dictionary<string, PlcSession>();
        //============将以连接的PLC站添加到数据字典里==========
        public static void Add(PlcSession session)
        {
            _sessions[session.Name] = session;  //已session.Name为主键，将session存入数据字典中
        }
        //===========获取单个站实例=================
        public static PlcSession Get(string name)
        {
            _sessions.TryGetValue(name, out var s);
            return s;
        }
        //==========移除单个站================
        public static void Remove(string name)
        {
            if (_sessions.TryGetValue(name, out var s))
            {
                s.Disconnected();
                _sessions.Remove(name);
            }
        }
        //=============获取所有的PLC名字，即数据字典里的Key========
        public static List<string> GetAllName()
        {
            return new List<string>(_sessions.Keys); //将主键列表转为列表
        }
        //=============获取数据字典里的所有值=============
        public static List<PlcSession> GetAll()
        {
            return new List<PlcSession>(_sessions.Values);
        }
        //==============清除数据字典内所有站=============
        public static void Clear()
        {
            foreach (var s in _sessions.Values)
            {
                s.Disconnected();
            }
            _sessions.Clear();
        }
    }
    //===============================数据传递类，用于在实时曲线ui上共享时间和数据两个双端数据队列===========================
    public class TemperatureData
    {
        //创建时间、数据两个双端队列
        public LinkedList<double> timeBuffer { get; set; }
        public LinkedList<int>[] dataBuffer { get; set; }
        public int MaxSize { get; set; }
        //温度阈值
        public int[] Thresholds { get; set; }
        //构造函数,作用是在创建类的实例时，自动初始化成员变量
        public TemperatureData(int maxSize = 120)
        {
            MaxSize = maxSize;
            timeBuffer = new LinkedList<double>();
            dataBuffer = new LinkedList<int>[4];
            for (int i = 0; i < 4; i++)
            {
                dataBuffer[i] = new LinkedList<int>();
            }
            Thresholds = new int[] { 1000, 1000, 1000, 1000 };
        }
        //添加数据到数据缓存区
        public void AddData(double time, int[] temperatures)
        {
            timeBuffer.AddLast(time);       //在双端队列末尾添加最新的时间
            if (timeBuffer.Count > MaxSize)
            {
                timeBuffer.RemoveFirst();
            }
            for (int i = 0; i < 4; i++)
            {
                dataBuffer[i].AddLast(temperatures[i]);
                if (dataBuffer[i].Count > MaxSize)
                {
                    dataBuffer[i].RemoveFirst();        //移除最早的那个数据
                }
            }
        }
        //清空所有缓存区
        public void Clear()
        {
            timeBuffer.Clear();
            for (int i = 0; i < 4; ++i)
            {
                dataBuffer[i].Clear();
            }
        }
        //获取时间数组
        public double[] GetTimeArray()
        {
            return timeBuffer.ToArray();
        }
        //获取温度数组
        public int[] GetTemperatureArray(int channelIndex)
        {
            return dataBuffer[channelIndex].ToArray();
        }
        //==========设置温度阈值=============
        public void SetThresholds(int[] thresholds)
        {
            if (thresholds.Length == 4)
                Array.Copy(thresholds, Thresholds, 4);
        }
        //=============检查温度是否超过阈值
        public int CheckAlarm(int zoneIndex, int currentTemp)
        {
            if (currentTemp > Thresholds[zoneIndex]) return 1;
            else return 0;
        }
    }
}
