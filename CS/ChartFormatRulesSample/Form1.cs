using DevExpress.DashboardCommon;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartFormatRulesSample {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();
            dashboardDesigner1.CreateRibbon();
            dashboardDesigner1.LoadDashboard("nwindDashboard.xml");
            ChartDashboardItem chart1 = (ChartDashboardItem)dashboardDesigner1.Dashboard.Items["chartDashboardItem1"];
            ChartDashboardItem chart2 = (ChartDashboardItem)dashboardDesigner1.Dashboard.Items["chartDashboardItem2"];
            AddFormatRulesToBarSeries(chart1);
            AddFormatRulesToLineSeries(chart2);
        }
        public void AddFormatRulesToBarSeries(ChartDashboardItem chart) {
            SimpleSeries series = chart.Panes[0].Series[0] as SimpleSeries;
            ChartItemFormatRule gradientRule = new ChartItemFormatRule(series.Value, series.Value);
            FormatConditionRangeGradient condition = new FormatConditionRangeGradient(FormatConditionRangeGradientPredefinedType.RedBlue);
            gradientRule.Condition = condition;
            gradientRule.ShowInLegend = false;
            chart.FormatRules.Add(gradientRule);
        }
        public void AddFormatRulesToLineSeries(ChartDashboardItem chart) {
            SimpleSeries series = chart.Panes[0].Series[0] as SimpleSeries;
            ChartItemFormatRule valueRule1 = new ChartItemFormatRule(series.Value, series.Value);
            FormatConditionValue valueCondition1 = new FormatConditionValue(DashboardFormatCondition.Greater, 3000);
            valueCondition1.StyleSettings = new AppearanceSettings(Color.Green);
            valueRule1.Condition = valueCondition1;
            valueRule1.ShowInLegend = true;
            valueRule1.Description = "UnitPrice greater than $3K";
            chart.FormatRules.Add(valueRule1);

            ChartItemFormatRule valueRule2 = new ChartItemFormatRule(series.Value, series.Value);
            FormatConditionValue valueCondition2 = new FormatConditionValue(DashboardFormatCondition.Less, 3000);
            valueCondition2.StyleSettings = new AppearanceSettings(Color.Red);
            valueRule2.Condition = valueCondition2;
            valueRule2.ShowInLegend = true;
            valueRule2.Description = "UnitPrice less than $3K";
            chart.FormatRules.Add(valueRule2);
        }
    }
}
