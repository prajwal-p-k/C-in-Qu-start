<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="dropdwon.Category1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding=10px;border:solid 1px wheat;margin:10px">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                
                <ItemTemplate>
                    <div style="border:solid 1px blue;margin:3px;padding:5px">
                        <div style="display:inline-block;margin:3px;width:160px;border:solid thin wheat;padding:3px">
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="120px" ImageUrl='<%# Eval("CategoryImage") %>' Width="150px"  />

                        </div>
                        <div style="float:right;width:240px;margin:3px;padding:3px;border:solid thin wheat;height:123px">
                            <div>
                                Product Description
                                Product Description
                                Product Description
                                Product Description
                            </div>
                            <hr />
                            <asp:LinkButton ID="btnlist" runat="server" CommandArgument='<%# Eval("CatId") %>' Text='<%# Eval("CategoryName") %>'></asp:LinkButton>


                        </div>

                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                     <div style="border:solid 1px blue;margin:3px;padding:5px">
    
     <div style="display:inline-block;width:240px;margin:3px;padding:3px;border:solid thin wheat;height:123px">
         <div>
             <table>
                 <tr>
                     <th> name</th>
                     <th> age</th>
                     <th> name</th>
                 </tr>
             </table>
         </div>
         <hr />
         <asp:LinkButton ID="btnlist" runat="server" CommandArgument='<%# Eval("CatId") %>' Text='<%# Eval("CategoryName") %>'></asp:LinkButton>


     </div <div style="float:right;margin:3px;width:240px;padding:3px;border:solid thin wheat;padding:3px">
     <asp:ImageButton ID="ImageButton1" runat="server" Height="120px" ImageUrl='<%# Eval("CategoryImage") %>' Width="150px"  />

 </div>


 </div>
                </AlternatingItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
