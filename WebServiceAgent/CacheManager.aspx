<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CacheManager.aspx.cs" Inherits="WebServiceAgent.CacheManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        /*列表样式*/

        .List {
            width: 100%;
        }

            .List th, .List td {
                border: 1px solid #eaeaea;
                padding-top: 3px;
                padding-left: 3px;
                height: 25px;
                line-height: 25px;
            }

            .List th {
                /*   background-color: #DEEDF9;*/
                font-weight: bold;
                text-align: left;
                background: #eaeaea;
            }

            .List .Alternating td {
                background-color: #F7FBFF;
            }

            .List A:link {
                height: 19px;
                text-decoration: none;
            }

            .List A:visited {
                height: 19px;
                text-decoration: none;
            }

            .List A:hover {
                height: 19px;
                text-decoration: underline;
            }

            .List A:active {
                height: 19px;
                text-decoration: none;
                color: #4B4B4B;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="tbKeys" runat="server" AutoPostBack="True" OnTextChanged="tbKeys_TextChanged" Width="359px">ServiceBase.WebService.DynamicWebLoad</asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="刷新" OnClick="Button1_Click" />
            <asp:GridView ID="GVList" runat="server" AutoGenerateColumns="False" CssClass="List">
                <Columns>
                    <asp:BoundField HeaderText="缓存名称" DataField="Text" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Text").ToString() %>' OnCommand="LinkButton1_Command" Text="移除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
