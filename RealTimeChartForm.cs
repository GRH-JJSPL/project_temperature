using MySqlX.XDevAPI;
using S7.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace project_temporature
{
    public partial class RealTimeChartForm : Form
    {
        private PlcSession _session;
        private TemperatureData temperatureData;
        private int[] temperatureOffSets = { 0, 2, 4, 6 };
        private Color[] chartColors = { Color.Red, Color.Green, Color.Blue, Color.Orange };
        //构造函数，用于接受上一张ui的实例
        public RealTimeChartForm(PlcSession session)
        {
            InitializeComponent();
            _session = session;
            temperatureData =_session.TemperatureData;

            
        }
        private void RealTimeChartForm_Load(object sender, EventArgs e)
        {
            if (!_session.PlcInstance.IsConnected)
            {
                MessageBox.Show("PLC未连接，请重新连接PLC！");
                this.Close();
                return;
            }
            //清空数据缓存区
            temperatureData.Clear();
            chart1.Series[0].Color = chartColors[0];  // 红色
            chart2.Series[0].Color = chartColors[1];  // 绿色
            chart3.Series[0].Color = chartColors[2];  // 蓝色
            chart4.Series[0].Color = chartColors[3];  // 橙色
            // ====== 新增：设置X轴刻度为整数秒，间隔1秒 ======
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart3.ChartAreas[0].AxisX.Interval = 1;
            chart4.ChartAreas[0].AxisX.Interval = 1;

            // 设置X轴标签格式为整数（不带小数）
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "0";
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "0";
            chart3.ChartAreas[0].AxisX.LabelStyle.Format = "0";
            chart4.ChartAreas[0].AxisX.LabelStyle.Format = "0";
            // =========数字倾斜角度===============
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart3.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart4.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            // ====== 用StripLine添加阈值线（不影响Series） ======
            Chart[] charts = { chart1, chart2, chart3, chart4 };

            for (int i = 0; i < 4; i++)
            {
                // 确保ChartAreas存在
                if (charts[i].ChartAreas.Count == 0)
                {
                    charts[i].ChartAreas.Add(new ChartArea($"Area{i}"));
                }
                StripLine thresholdLine = new StripLine();
                thresholdLine.Interval = 0;
                thresholdLine.IntervalOffset = temperatureData.Thresholds[i];
                thresholdLine.StripWidth = 0;
                thresholdLine.BorderColor = Color.Red;
                thresholdLine.BorderWidth = 2;
                thresholdLine.BorderDashStyle = ChartDashStyle.Dash;
                charts[i].ChartAreas[0].AxisY.StripLines.Add(thresholdLine);
            }
            updateTimer.Start();
        }

        private void RealTimeChartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateTimer.Stop();
        }


        private async void timer1_Tick(object sender, EventArgs e)
        {
            await ReadPLCDataAndUpdateChart();
        }
        private async Task ReadPLCDataAndUpdateChart()
        {
            if(!_session.PlcInstance.IsConnected)
            {
                MessageBox.Show("PLC未连接！");
                return;
            }

            try
            {
                int[] temperatures = new int[4];

                for (int i = 0; i < 4; i++)
                {
                    byte[] buffer = await Task.Run(() =>
                        _session.PlcInstance.ReadBytes(DataType.DataBlock, 1, temperatureOffSets[i], 2));

                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(buffer);

                    temperatures[i] = BitConverter.ToInt16(buffer, 0);
                }

                UpdateDisplay(temperatures);
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"数据采集失败：{ex.Message}");
                });
            }
        }

        // 更新显示
        private void UpdateDisplay(int[] temperatures)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // 更新温度标签
                chart1.Titles[0].Text = temperatures[0].ToString() + "℃";
                chart2.Titles[0].Text = temperatures[1].ToString() + "℃";
                chart3.Titles[0].Text = temperatures[2].ToString() + "℃";
                chart4.Titles[0].Text = temperatures[3].ToString() + "℃";

                // 更新图表
                UpdateCharts();
            });
        }
        // 更新图表
        private void UpdateCharts()
        {
            double[] times = temperatureData.GetTimeArray();
            if (times.Length == 0) return;

            UpdateSingleChart(chart1, 0, times);
            UpdateSingleChart(chart2, 1, times);
            UpdateSingleChart(chart3, 2, times);
            UpdateSingleChart(chart4, 3, times);
        }
        // =============================更新单个图表==================================
        private void UpdateSingleChart(Chart chart, int channelIndex, double[] times)
        {
            int[] temps = temperatureData.GetTemperatureArray(channelIndex);        //自定义类数据的方法
            if (temps.Length == 0) return;

            chart.Series[0].Points.Clear();         //一个表里面只有一条曲线，所以是Sereis[0],这里是清除旧曲线

            for (int j = 0; j < times.Length && j < temps.Length; j++)
            {
                chart.Series[0].Points.AddXY(times[j], temps[j]);       //将数据点加到曲线上
            }

            // 更新X轴范围（显示最近60秒）
            double minX = Math.Max(0, times[times.Length - 1] - 60);
            double maxX = times[times.Length - 1];

            chart.ChartAreas[0].AxisX.Minimum = minX;
            chart.ChartAreas[0].AxisX.Maximum = maxX;

            chart.ChartAreas[0].RecalculateAxesScale();         //让x轴范围变化
        }
    }

}

