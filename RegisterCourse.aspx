<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab6.RegisterCourse" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lab 6</title>
    <link href="App_Themes/style.css" rel="stylesheet" />
</head>
<body>
    <h1>Algonquin College Course Registration</h1>
    <form runat="server">
        <div>
            <div>
                Student Name: <asp:TextBox CssClass="inputField" ID="txtStudentName" runat="server"></asp:TextBox>
                <br />
                <div CssClass="errorLog">
                  <asp:Label runat="server" style="color:red;" CssClass="errorLabel" ID="lblNameError"></asp:Label>
                  <asp:Label runat="server" style="color:red;" CssClass="errorLabel" ID="lblStudentTypeError"></asp:Label>
                  <asp:Label runat="server" style="color:red;" CssClass="errorLabel" ID="lblCourseError"></asp:Label>
                  <asp:Label runat="server" style="color:red;" CssClass="errorLabel" ID="lblSelectionError"></asp:Label>
                </div>
                <br />
                <div>
                    <asp:RadioButtonList ID="rblStudentType" runat="server">
                        <asp:ListItem Text="Full Time" Value="Full Time" />
                        <asp:ListItem Text="Part Time" Value="Part Time" />
                        <asp:ListItem Text="Co-op" Value="Co-op" />
                    </asp:RadioButtonList>
                </div>
            </div>
            <br/>
            <asp:Label ID="lblCourseHeader" runat="server">Following courses are currently available for registration</asp:Label>
            <div ID="divCheckBoxSection">
                <asp:CheckBoxList ID="cbCourseSelection" runat="server">
                    <asp:ListItem Text="Introduction to Database Systems - 4 hours/week" Value="CST8282" />
                    <asp:ListItem Text="Web Programming II - 2 hours/week" Value="CST8253" />
                    <asp:ListItem Text="Web Programming Language I - 5 hours/week" Value="CST8256" />
                    <asp:ListItem Text="Web Imaging and Animations - 2 hours/week" Value="CST8255" />
                    <asp:ListItem Text="Network Operating System - 1 hours/week" Value="CST8254" />
                    <asp:ListItem Text="Data Warehouse Design - 3 hours/week" Value="CST2200" />
                    <asp:ListItem Text="Advance Database topics - 1 hours/week" Value="CST2240" />
                </asp:CheckBoxList>
            </div>
            <br/>
            <asp:PlaceHolder ID="phTable" runat="server"></asp:PlaceHolder>
            <asp:Label runat="server" CssClass="Message" ID="lblMessage"></asp:Label>
            <br />
            <button type="submit">Submit</button>
        </div>
    </form>
</body>
</html>
