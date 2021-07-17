<%@ Page Title="Customer List" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Summary.aspx.cs" Inherits="CustomerLib.WebForms.CustomerList" %>
<%@ Register assembly="CustomerLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" namespace="CustomerLib.Entities" tagprefix="rsweb" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
	<!--<table>-->
	<h2 class="">Customer List</h2>

	<div class="accordion" id="customersAccordion">
	  <% foreach (var customer in Customers)
	      { %>
		<div class="card">
			<div class="bg-dark" id="heading<%=customer.CustomerID%>">
			  <h2 class="mb-0">
			    <button class="btn btn-dark btn-block text-left" 
					type="button" data-toggle="collapse" 
					data-target="#collapse<%=customer.CustomerID%>" 
					aria-expanded="true" 
					aria-controls="collapse<%=customer.CustomerID%>">
			      #<% =customer.CustomerID %> 
			      <% =customer.FirstName %> 
			      <% =customer.LastName %> 
			    </button>
			  </h2>
			</div>
	
			<div id="collapse<%=customer.CustomerID%>" 
				class="collapse show" 
				aria-labelledby="heading<%=customer.CustomerID%>" 
				data-parent="#customersAccordion">
				<div class="card-body">
					<p> Last name: <%= customer.LastName %> </p>
					<p> Last name: <%= customer.FirstName %> </p>
					<p> Email: <%= customer.Email %> </p> 
					<p> Phone: <%= customer.PhoneNumber %> </p>
					<p> Total purchases amount: <%= customer.TotalPurchasesAmount %> </p>
	
					<!-- Addresses -->
					<div class="accordion" id="addressAccordion">
						<div class="card">
							<div class="bg-dark" id="heading<%=customer.CustomerID%>Addresses">
								<h2 class="mb-0">
									<button class="btn btn-dark btn-block text-left" type="button" data-toggle="collapse" data-target="#collapse<%=customer.CustomerID%>Addresses" aria-expanded="true" aria-controls="collapse<%=customer.CustomerID%>Addresses">
									Addresses
									</button>
								</h2>
							</div>
						</div>
						<div id="collapse<%=customer.CustomerID%>Addresses" class="collapse show" 
							aria-labelledby="heading<%=customer.CustomerID%>Addresses" data-parent="#addressAccordion">
							<div class="card-body">
						     <!-- Each Address by Customer -->
							<% foreach (var address in customer.Addresses)
                               { %>
							<div class="accordion" id="C<%=customer.CustomerID%>A<%=address.AddressID%>Accordion">
								<div class="card">
									<div class="bg-dark" id="headingC<%=customer.CustomerID%>A<%=address.AddressID%>">
									  <h2 class="mb-0">
									    <button class="btn btn-dark btn-block text-left" 
											type="button" data-toggle="collapse" 
											data-target="#collapseC<%=customer.CustomerID%>A<%=address.AddressID%>" 
											aria-expanded="true" 
											aria-controls="collapseC<%=customer.CustomerID%>A<%=address.AddressID%>">
											#<%= address.AddressID %> <%= address.Line1%>
									    </button>
									  </h2>
									</div>

									<div id="collapseC<%=customer.CustomerID%>A<%=address.AddressID%>" 
										class="collapse show" 
										aria-labelledby="headingC<%=customer.CustomerID%>A<%=address.AddressID%>" 
										data-parent="#C<%=customer.CustomerID%>A<%=address.AddressID%>Accordion">
										<div class="card-body">
											<p>Additional Line: <%=(address.Line2 != null ? address.Line2 : "none")%>
											<p>ID: <%=address.AddressID%></p>
											<p>City: <%=address.City%></p>
											<p>State: <%=address.State%></p>
											<p>Country: <%=address.Country%></p>
											<p>Postal code: <%=address.PostalCode%></p>
											<p>Type: <%=address.AddressType%></p>
									    </div>
									</div>
								</div>
							</div>
						<%	} %>
								
							</div>
						</div>
					</div>
	
					<!-- Notes -->
					<div class="accordion" id="C<%=customer.CustomerID%>NotesAccordion">							
						<div class="card">
							<div class="bg-dark" id="headingC<%=customer.CustomerID%>Notes">
							  <h2 class="mb-0">
							    <button class="btn btn-dark btn-block text-left" 
									type="button" data-toggle="collapse" 
									data-target="#collapseC<%=customer.CustomerID%>Notes" 
									aria-expanded="true" 
									aria-controls="collapseC<%=customer.CustomerID%>Notes">
									Notes
							    </button>
							  </h2>
							</div>
	
							<div id="collapseC<%=customer.CustomerID%>Notes" 
								class="collapse show" 
								aria-labelledby="headingC<%=customer.CustomerID%>Notes" 
								data-parent="#C<%=customer.CustomerID%>NotesAccordion">
								<div class="card-body">
									<%foreach (var note in customer.Notes)
										{ %>
										<p> <%= note.Line %> </p> 
									<% } %>
							    </div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	
	<% } %>
	</div>
</asp:Content>
