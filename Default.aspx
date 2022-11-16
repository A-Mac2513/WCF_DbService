<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP_WCF_DB._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <div style="text-decoration: underline; text-align: center; color: #FFFFFF; background-color: #CC3300;">
            <asp:Label ID="lblFormTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="USER REGISTRATION FORM"></asp:Label>
        </div>
    </p>
    <br />
    <p>
        <asp:Label ID="lblUserName" runat="server" Font-Bold="True" Font-Size="Large" Text="Name: "></asp:Label>
        <asp:TextBox ID="txbxName" runat="server" BorderColor="#333333" BorderStyle="Ridge" Font-Size="Medium"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblUserPswrd" runat="server" Font-Bold="True" Font-Size="Large" Text="Password:"></asp:Label>
        <asp:TextBox ID="txbxPswrd" runat="server" BorderColor="#333333" BorderStyle="Ridge" Font-Size="Medium"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblUserCountry" runat="server" Font-Bold="True" Font-Size="Large" Text="Country:"></asp:Label>
        <asp:TextBox ID="txbxCountry" runat="server" BorderColor="#333333" BorderStyle="Ridge" Font-Size="Medium"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblUserEmail" runat="server" Font-Bold="True" Font-Size="Large" Text="Email: "></asp:Label>
        <asp:TextBox ID="txbxEmail" runat="server" BorderColor="#333333" BorderStyle="Ridge" Font-Size="Medium"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnInsert" runat="server" BackColor="#009933" BorderColor="White" BorderStyle="Outset" Font-Bold="True" Font-Size="Medium" ForeColor="White" OnClick="btnInsert_Click" Text="INSERT" />
        <asp:Button ID="btnFindAll" runat="server" BackColor="#0033CC" BorderColor="White" BorderStyle="Outset" Font-Bold="True" Font-Size="Medium" ForeColor="White" OnClick="btnFindAll_Click" Text="ALL USERS" style="margin-left: 1em;" />
        <asp:Button ID="btnFindUser" runat="server" BackColor="#33CCFF" BorderColor="White" BorderStyle="Outset" Font-Bold="True" Font-Size="Medium" ForeColor="White" OnClick="btnFindUser_Click" Text="FIND USER" style="margin-left: 1em;" />
        <asp:Button ID="btnDelete" runat="server" BorderColor="White" BorderStyle="Outset" Font-Bold="True" Font-Size="Medium" ForeColor="White" OnClick="btnDelete_Click" Text="DELETE" style="margin-left: 1em;" CssClass="btn-danger" />
        <asp:Button ID="btnUpdate" runat="server" BackColor="#009933" BorderColor="White" BorderStyle="Outset" Font-Bold="True" Font-Size="Medium" ForeColor="White" OnClick="btnUpdate_Click" Text="UPDATE" style="margin-left: 1em;" />

        <asp:Button ID="Button1" runat="server" BackColor="#0033CC" BorderColor="White" BorderStyle="Outset" Font-Bold="True" Font-Size="Medium" ForeColor="White" OnClick="btnFindAll_Click" Text="ALL USERS" style="margin-left: 2em;" />
    </p>
    <p>
        <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#00CC00" Visible="False"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="gvAllUsers" runat="server" CellPadding="10" Font-Size="Small" 
            CellSpacing="4" CssClass="gvAllUsers" AllowSorting="True"></asp:GridView>       
    </p>


</asp:Content>