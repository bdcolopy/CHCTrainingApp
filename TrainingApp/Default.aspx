<%@ Page Title="ECTP Training" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrainingApp._Default" %>

<%@ Register Src="~/ProductInfoControl.ascx" TagPrefix="uc1" TagName="ProductInfoControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div>
		<div class="CenterContent col-md-12 AWProducts">
			<div class="row col-md-6 col-md-offset-3">
				<asp:DropDownList  ID="DropDownCategory" width="40%" runat="server" AutoPostBack="true" OnTextChanged="getProductSubCategory" ></asp:DropDownList> 
				<asp:DropDownList ID="DropDownSubCategory" width="40%" class="col-md-offset-1" runat="server" AutoPostBack="true" OnTextChanged="getProduct"></asp:DropDownList>
			</div>
			<br />
			<hr />
			<div class="row col-md-6 col-md-offset-3" style="width:50%; height:100%;" >
				<asp:GridView ID="GridViewProducts" runat="server" class="col-md-12"  BorderWidth="1px" AutoGenerateColumns="false" AllowSorting="true" OnSorting="GridViewProducts_Sorting"
									width="100%" Font-Size="Small"  OnRowCommand="GridProductRowCommand" DataKeyNames="ProductId" >
					<HeaderStyle Font-Bold="true" BackColor="#d3d3d3" />
					<AlternatingRowStyle  BackColor="#f0f0f0"/>
					<Columns>
						<asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" HeaderStyle-Width="15px"  />
						<asp:BoundField DataField="ProductName"  HeaderText="Product" HeaderStyle-Width="100px" SortExpression="ProductName" />
						<asp:BoundField DataField="Color" HeaderText="Color" HeaderStyle-Width="100px" SortExpression="Color" />
						<asp:BoundField DataField="Price" HeaderText="Price" DataFormatString = "{0:c2}" HeaderStyle-Width="15px" SortExpression="Price" />
					</Columns>
				</asp:GridView>
				<div id="ProductInfo" style="width: 100%;" visible="false" runat="server">
					<uc1:ProductInfoControl runat="server" ID="ProductInfoControl" />
				</div>
			</div>			
		</div>
	</div>


</asp:Content>
