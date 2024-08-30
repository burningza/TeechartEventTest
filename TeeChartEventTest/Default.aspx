<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TeeChartEventTest._Default" %>

<%@ Register Assembly="TeeChart" Namespace="Steema.TeeChart.Web" TagPrefix="tchart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <h2>TeeChart Demo</h2>
            <p>
                <tchart:WebChart ID="WebChart1" AutoPostback="True" TempChart="Httphandler" runat="server" OnAfterDraw="WebChart1_AfterDraw" OnClickBackground="WebChart1_ClickBackground" OnClickSeries="WebChart1_ClickSeries" Config="AAEAAAD/////AQAAAAAAAAAMAgAAAFFUZWVDaGFydCwgVmVyc2lvbj00LjEuMjAxNS4zMTE5LCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTljODEyNjI3NmM3N2JkYjcFAQAAABVTdGVlbWEuVGVlQ2hhcnQuQ2hhcnQFAAAADC5DYW5jZWxNb3VzZRAuQ3VzdG9tQ2hhcnRSZWN0DS5IZWFkZXIuTGluZXMZLkFzcGVjdC5Db2xvclBhbGV0dGVJbmRleA8uQXhlcy5BdXRvbWF0aWMAAAYAAAEBCAECAAAAAAAJAwAAAAAAAAABEQMAAAABAAAABgQAAAARVEhJUyBJUyBUSEUgVElUTEUL" GetChartFile="" Height="300px" Width="400px" />
            </p>
        </div>
    </div>

</asp:Content>
