﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            // Считываем с формы требуемые значения 
            double Xmin = -1.5;
            double Xmax = 3.5;
            double Step = 0.5;
            textBoxStep.Text = Step.ToString();
            textBoxXmin.Text = Xmin.ToString();
            textBoxXmax.Text = Xmax.ToString();
            // Количество точек графика
            double p = (Xmax - Xmin)/Step ;
            int count = (int)Math.Ceiling(p)+1;
            // Массив значений X – общий для обоих графиков
            double[] x = new double[count];
            // Два массива Y – по одному для каждого графика
            double[] y1 = new double[count];
            double[] y2 = new double[count];



            // Расчитываем точки для графиков функции
            for (int i = 0; i < count; i++)
            {
                double a = -1.25;
                double b = -1.5;
                double c = 0.75;
                // Вычисляем значение X 
                x[i] = Xmin + Step * i;
                // Вычисляем значение функций в точке X 
                y1[i] = (1/100)*c*b/x[i] + Math.Cos(Math.Sqrt(Math.Pow(a, 3) * x[i]));
                y2[i] = Math.Cos(x[i]);
            }

            // Настраиваем оси графика 
            chart1.ChartAreas[0].AxisX.Minimum = Xmin;
            chart1.ChartAreas[0].AxisX.Maximum = Xmax;

            // Определяем шаг сетки
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Step;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            // Добавляем вычисленные значения в графики 
            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[1].Points.DataBindXY(x, y2);
        }


    }
}
