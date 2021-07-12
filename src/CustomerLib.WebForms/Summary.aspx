<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="CustomerLib.WebForms.CustomerList" %>
<%@ Import Namespace="CustomerLib" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #name {
            width: 102px;
        }
        #email {
            width: 102px;
        }
    </style>
</head>
<body>
        <h2>Приглашения</h2>

    <h3>Люди которые были приглашены: </h3>
    <table>
        <thead>
            <tr>
                <th>Имя</th>
                <th>Email</th>
                <th>Телефон</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (CustomerLib.Entities.Customer customer in Customers) {
                   string htmlString = String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td>",
                       customer.FirstName, customer.LastName, customer.PhoneNumber);
                   Response.Write(htmlString);
               } %>
        </tbody>
    </table>
</body>
</html>
