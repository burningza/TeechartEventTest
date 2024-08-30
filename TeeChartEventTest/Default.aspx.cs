using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Steema.TeeChart.Styles;
using System.Drawing;

namespace TeeChartEventTest
{
    public partial class _Default : Page
    {
        private int clickedX;
        private int clickedY;
        private string msgText;

        protected void Page_Load(object sender, EventArgs e)
        {
            Steema.TeeChart.Chart ch1 = WebChart1.Chart;
            MemoryStream tmpChart = new MemoryStream();

            if (Session["ch3"] == null)
            {
                //setup Chart
                if (ch1.Series.Count < 2)
                {
                    ch1.Series.Add(new Steema.TeeChart.Styles.Points());
                    ch1.Series.Add(new Steema.TeeChart.Styles.Points());
                }

                //this.seriesHotspot1 = new Steema.TeeChart.Tools.SeriesHotspot(ch1);

                ((Points)ch1.Series[0]).Pointer.Pen.Visible = false;
                ((Points)ch1.Series[1]).Pointer.Pen.Color = Color.FromArgb(79, 79, 255);

                ch1.Series[0].Color = Color.FromArgb(255, 199, 26);
                ch1.Series[1].Color = Color.FromArgb(106, 106, 255);

                ch1.Series[0].FillSampleValues(6);
                ch1.Series[1].FillSampleValues(6);
                //export Chart to a MemoryStream template
                ch1.Export.Template.Save(tmpChart);
                //save template to a Session variable
                Session.Add("ch3", tmpChart);
            }
            else
            {
                //retrieve the session stored Chart
                tmpChart = (MemoryStream)Session["ch3"];
                //set the Stream position to 0 as the last read/write
                //will have moved the position to the end of the stream
                tmpChart.Position = 0;
                //import saved Chart
                ch1.Import.Template.Load(tmpChart);
            }
        }

        protected void WebChart1_ClickBackground(object sender, ImageClickEventArgs e)
        {
            Steema.TeeChart.Chart tChart = ((Steema.TeeChart.Web.WebChart)sender).Chart;
            //int index = WebChart2.Chart.Legend.Clicked(e.X, e.Y);

            //event triggered when any point on the Chart is clicked. If the ClickSeries event is active
            //it will take precedence when a Series is clicked.
            clickedX = e.X;
            clickedY = e.Y;
            msgText = "Clicked background\n\rX:" + tChart.Axes.Bottom.CalcPosPoint(clickedX).ToString("#0.00")
               + ", Y:" + tChart.Axes.Left.CalcPosPoint(clickedY).ToString("#0.00");
        }

        protected void WebChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            if (clickedX > 0)
            {
                g.Font.Bold = true;
                g.Font.Color = Color.Blue;
                g.TextOut(clickedX, clickedY, msgText);
            }
        }

        protected void WebChart1_ClickSeries(object sender, Series s, int valueIndex, EventArgs e)
        {
            Steema.TeeChart.Chart tChart = ((Steema.TeeChart.Web.WebChart)sender).Chart;

            clickedX = s.CalcXPos(valueIndex);
            clickedY = s.CalcYPos(valueIndex);
            msgText = "Series: " + tChart.Series.IndexOf(s).ToString() + "\n\rValue: " + s.YValues[valueIndex].ToString("#0.00");
        }
    }
}