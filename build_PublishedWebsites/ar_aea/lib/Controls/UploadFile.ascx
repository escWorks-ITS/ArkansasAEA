<%@ control language="C#" autoeventwireup="true" enableviewstate="False" inherits="lib_Controls_UploadFile, App_Web_11e1swey" %>
  <table border="0" cellpadding="0" cellspacing="0" width="100%">
   <asp:Panel ID="pnlUpload" runat="server" Visible="false">
        <div>
              
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        <br />
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" /><br />
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label><br />
        </div>
        </asp:Panel>
   </table>
