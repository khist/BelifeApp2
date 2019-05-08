<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClienteForm.aspx.cs" Inherits="BelifeWEB.ClienteForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblRut" runat="server" Text="RUT"></asp:Label>
        <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblNombres" runat="server" Text="Nombres"></asp:Label>
        <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblApellidos" runat="server" Text="Apellidos"></asp:Label>
        <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento"></asp:Label>
        <asp:Calendar ID="clFechaNacimiento" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
        <asp:Label ID="lblSexo" runat="server" Text="Sexo"></asp:Label>
        <asp:RadioButton ID="rbtHombre" runat="server" Checked="True" GroupName="sexo" Text="Hombre" />
        <asp:RadioButton ID="rbtMujer" runat="server" GroupName="sexo" Text="Mujer" />
        <br />
        <asp:Label ID="lblEstadoCivil" runat="server" Text="Estado Civil"></asp:Label>
        <asp:DropDownList ID="ddlEstadoCivil" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
        <br />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="gvClientes" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <br />
    
    </div>
    </form>
</body>
</html>
