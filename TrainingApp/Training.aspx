<%@ Page Title="ECTP Training" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Training.aspx.cs" Inherits="TrainingApp.Training" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hidden">
			<div class="row">
				<asp:Label ID="welcomeMessge" class="message" runat="server" Text="Welcome to the ECTP Training WebFrom Page!"></asp:Label>
			</div>
			<br />
			<div class="row">
				<asp:Label ID="textLabel" runat="server" Text="DataEntry"></asp:Label>
			</div>
			<div class="row">
				<asp:TextBox ID="textBox" runat="server"></asp:TextBox>
			</div>
			<div class="row">
				<asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateClick"/>
			</div>
		</div>
		<hr />
		
		<div class="productContainer col-md-12 hidden">
			<div class="row col-md-6 col-md-offset-3 dropDownRow">
				<asp:DropDownList ID="dropDownColor" width="30%" runat="server" AutoPostBack="true" OnTextChanged="getProductByColor" ></asp:DropDownList> 
				<asp:DropDownList ID="dropDownProduct" width="50%" class="col-md-offset-1" runat="server" AutoPostBack="true" OnTextChanged="getProductInfo"></asp:DropDownList>
			</div>
			<br />
			<hr />
			<div class="row col-md-4 col-md-offset-3 gridLabelRow">
				<asp:Label ID="dataGridLabel" class="col-md-12" Width="150%" runat="server" Text="Select a Color Then A Product Name"></asp:Label>
			</div>
			<div class="row col-md-6 col-md-offset-3" style="overflow:auto;width: 50%;">
				<asp:GridView ID="gridProduct" runat="server" class="col-md-12 "  BorderWidth="1px" AutoGenerateColumns="false"
									width="100%" AllowSorting="true" OnSorting="gridProduct_Sorted" Font-Size="Small" >
					  
				  <HeaderStyle CssClass="gridHeader" Font-Bold="true" BackColor="#d3d3d3" />
					<AlternatingRowStyle  BackColor="#f0f0f0"/>
				  <Columns>
					  <asp:BoundField DataField="Start Date"  HeaderText="Start Date" DataFormatString = "{0:d}" SortExpression="Start Date" />
					  <asp:BoundField DataField="Due Date" HeaderText="Due Date" DataFormatString = "{0:d}" SortExpression="Due Date" />
					  <asp:BoundField DataField="Order Quantity" HeaderText="Order Quantity" SortExpression="Order Quantity" />


				  </Columns>
				 </asp:GridView>
			</div>
		</div>
</asp:Content>

