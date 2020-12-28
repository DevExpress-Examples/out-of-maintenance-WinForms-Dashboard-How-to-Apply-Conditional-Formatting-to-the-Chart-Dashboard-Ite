Imports DevExpress.DashboardCommon
Imports DevExpress.XtraEditors
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace ChartFormatRulesSample
	Partial Public Class Form1
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()
			dashboardDesigner1.CreateRibbon()
			dashboardDesigner1.LoadDashboard("nwindDashboard.xml")
			Dim chart1 As ChartDashboardItem = CType(dashboardDesigner1.Dashboard.Items("chartDashboardItem1"), ChartDashboardItem)
			Dim chart2 As ChartDashboardItem = CType(dashboardDesigner1.Dashboard.Items("chartDashboardItem2"), ChartDashboardItem)
			AddFormatRulesToBarSeries(chart1)
			AddFormatRulesToLineSeries(chart2)
		End Sub
		Public Sub AddFormatRulesToBarSeries(ByVal chart As ChartDashboardItem)
			Dim series As SimpleSeries = TryCast(chart.Panes(0).Series(0), SimpleSeries)
			Dim gradientRule As New ChartItemFormatRule(series.Value, series)
			Dim condition As New FormatConditionRangeGradient(FormatConditionRangeGradientPredefinedType.RedBlue)
			gradientRule.Condition = condition
			gradientRule.ShowInLegend = False
			chart.FormatRules.Add(gradientRule)
		End Sub
		Public Sub AddFormatRulesToLineSeries(ByVal chart As ChartDashboardItem)
			Dim series As SimpleSeries = TryCast(chart.Panes(0).Series(0), SimpleSeries)
			Dim valueRule1 As New ChartItemFormatRule(series.Value, series)
			Dim valueCondition1 As New FormatConditionValue(DashboardFormatCondition.Greater, 3000)
			valueCondition1.StyleSettings = New ColorStyleSettings(Color.Green)
			valueRule1.Condition = valueCondition1
			valueRule1.ShowInLegend = True
			valueRule1.DisplayName = "UnitPrice is greater than $3K"
			chart.FormatRules.Add(valueRule1)

			Dim valueRule2 As New ChartItemFormatRule(series.Value, series)
			Dim valueCondition2 As New FormatConditionValue(DashboardFormatCondition.Less, 3000)
			valueCondition2.StyleSettings = New ColorStyleSettings(Color.Red)
			valueRule2.Condition = valueCondition2
			valueRule2.ShowInLegend = True
			valueRule2.DisplayName = "UnitPrice is less than $3K"
			chart.FormatRules.Add(valueRule2)
		End Sub
	End Class
End Namespace
