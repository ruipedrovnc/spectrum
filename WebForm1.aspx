<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>    
    <%--<link rel="stylesheet" href="css/bootstrap.min.css" />--%>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="center-block" style="width: 300px; background-color: #ccc; margin: auto;margin-top:10%;padding:15px;text-align:center;">
                    <div class="input-group">
                        <asp:TextBox runat="server" id="TextBoxPesquisa" name="Pesquisa" CssClass="form-control" placeholder="Pesquisar..." type="Text"/>
                        <div class="input-group-btn">
                            <asp:LinkButton runat="server" OnClick="ButtonPesquisa_Click"  class="btn btn-default"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>
                        </div>
                    </div>
                    <%--Labels--%>
                    <div>
                        Erros: <asp:Label ID="LabelErros" runat="server" Height="20px" Width="100px"></asp:Label>
                        <br />
                        Registos: <asp:Label ID="LabelRegistos" runat="server"></asp:Label>
                        <br />
                        Coluna: <asp:Label ID="LabelColuna" runat="server"></asp:Label>
                        <br />
                        IP: <asp:Label ID="LabelIP" runat="server"></asp:Label>
                    </div>
                    <%--Repeater--%>
                    <div>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <HeaderTemplate>
                                <table border="1">
                                    <tr>
                                        <td><b>IXP</b></td>
                                        <td><b>IXS1</b></td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# DataBinder.Eval(Container.DataItem, "ixp") %> </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "ixs1") %> </td>
                                    <td><asp:LinkButton ID="LinkButtonVerFicheiro" runat="server" CommandName="ClickVerFicheiro" CommandArgument='<%# Eval("ip") %>' Text="Ver Ficheiro"></asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div>
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
