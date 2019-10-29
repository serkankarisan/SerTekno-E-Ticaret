<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="ETicaret.PL.UserManage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManagerUser" runat="server"></asp:ScriptManager>
    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
        <ajaxToolkit:Accordion ID="AccordionUser" runat="server" CssClass="" HeaderSelectedCssClass="btn btn-success mb-2 mt-2 ml-2" FadeTransitions="true" TransitionDuration="500" AutoSize="None" SelectedIndex="0">
            <Panes>
                <ajaxToolkit:AccordionPane ID="AccordionListUsers" HeaderCssClass="btn btn-outline-success mb-2 mt-2 ml-2" CssClass="pt-3" runat="server" ContentCssClass="text-center">
                    <Header>
                        Kullanıcıları Görüntüle
                    </Header>
                    <Content>
                        <asp:Panel ID="pnlAlertDiv" runat="server" role="alert" Visible="False">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <asp:Label ID="lblAlertDiv" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                        <asp:GridView CssClass="table table-responsive table-striped text-left" OnRowEditing="gvUsers_RowEditing" OnRowDeleting="gvUsers_RowDeleting" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="1px" CellPadding="1" GridLines="Horizontal" ID="gvUsers" ShowFooter="True" AllowPaging="True" DataKeyNames="Id" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbxAllDelete" runat="server" Text="Hepsini Seç" />
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        <button id="btnDeleteModal" type="button" class="btn btn-outline-danger pt-0 pb-0" data-toggle="modal" data-target="#DeleteConfirmModal" style="width: 100px;">Seçilenleri Sil</button>
                                        <asp:Panel ID="pnlDeleteConfirm" runat="server" DefaultButton="btnModalDelete">
                                            <!-- DeleteConfirmModal -->
                                            <div class="modal fade" id="DeleteConfirmModal" tabindex="-1" role="dialog" aria-labelledby="DeleteConfirmModalLabel" aria-hidden="true">
                                                <div class="modal-dialog" role="document">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <h5 class="modal-title text-danger" id="DeleteConfirmModalLabel">Uyarı!</h5>
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                <span aria-hidden="true">&times;</span>
                                                            </button>
                                                        </div>
                                                        <div class="modal-body">
                                                            Silmek istiyor musunuz? 
                                                        </div>
                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-danger" data-dismiss="modal">Vazgeç</button>
                                                            <asp:Button CssClass="btn btn-success" ID="btnModalDelete" runat="server" Text="Onayla" Width="125px" OnClick="btnModalDelete_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- DeleteConfirmModal End-->
                                        </asp:Panel>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxSelectDelete" runat="server" Text="&nbsp;Seç" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                    <HeaderStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email" ItemStyle-Width="325px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmailList" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="text-wrap" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Telefon">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPhoneNumberList" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Adı" ItemStyle-Width="180px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNameList" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Soyadı" ItemStyle-Width="180px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSurNameList" runat="server" Text='<%# Bind("SurName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Adres">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdressList" runat="server" Text='<%# Bind("Adress") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="wordwrap minwidthAdress" Width="250px"/>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="Posta Kodu">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdressZipCodeList" runat="server" Text='<%# Bind("AdressZipCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Cinsiyet">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGenderList" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEdit" CssClass="btn btn-outline-warning pt-0 pb-0" runat="server" CausesValidation="False" CommandName="Edit" Text="Düzenle"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnDel" runat="server" CausesValidation="False" CommandName="Delete" Text="Sil" OnClientClick="return confirm('Silmek İstiyor munuz?')" CssClass="btn btn-outline-danger pt-0 pb-0" CommandArgument='<%#Eval("Id")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#333333" />
                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="White" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                        </asp:GridView>
                    </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionEditUser" CssClass="pt-3" runat="server">
                    <Header>
                    </Header>
                    <Content>
                        <asp:Panel ID="pnlUserUpdate" runat="server" DefaultButton="btnUserUpdate">
                            <div class="card-body">
                                <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pt-5">
                                    <div class="row">
                                        <div class="col-10 col-sm-10 col-md-8 col-lg-4 col-xl-4 offset-1 offset-sm-1 offset-md-2 offset-lg-1 offset-xl-1">
                                            <div class="form-group">
                                                <asp:Label ID="lblName" runat="server" Text="Ad" for="txtName" CssClass="text-success"></asp:Label><br />
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" name="txtName"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Adınızı girmelisiniz!" ControlToValidate="txtName" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="UserValidate"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblSurName" runat="server" Text="Soyad" for="txtSurName" CssClass="text-success"></asp:Label><br />
                                                <asp:TextBox ID="txtSurName" runat="server" name="SurName" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSurName" runat="server" ErrorMessage="Soyadınızı girmelisiniz!" ControlToValidate="txtSurName" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="UserValidate"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblEmail" runat="server" Text="Email" for="txtEmail" CssClass="text-success"></asp:Label><br />
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" name="txtEmail"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Email girmelisiniz!" ControlToValidate="txtEmail" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="UserValidate"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Geçerli bir Email girmelisiniz!" ControlToValidate="txtEmail" ForeColor="#990000" SetFocusOnError="True" ValidationExpression="[\w-]+@([\w-]+\.)+[\w-]+" Display="Dynamic" ValidationGroup="UserValidate"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Telefon( 5XXXXXXXXX )" for="txtPhoneNumber" CssClass="text-success"></asp:Label><br />
                                                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" name="txtPhoneNumber" MaxLength="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhoneNumber" runat="server" ErrorMessage="Telefon numarası girmelisiniz!" ControlToValidate="txtPhoneNumber" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="UserValidate"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhoneNumber" runat="server" ErrorMessage="Geçerli bir telefon numarası girmelisiniz!" ControlToValidate="txtPhoneNumber" ForeColor="#990000" SetFocusOnError="True" ValidationExpression="(([\+]90?)|([0]?))([ ]?)((\([0-9]{3}\))|([0-9]{3}))([ ]?)([0-9]{3})(\s*[\-]?)([0-9]{2})(\s*[\-]?)([0-9]{2})" Display="Dynamic" ValidationGroup="UserValidate"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblAdress" runat="server" Text="Adres" for="txtAdress" CssClass="text-success"></asp:Label><br />
                                                <asp:TextBox ID="txtAdress" runat="server" CssClass="form-control" TextMode="MultiLine" name="txtAdress" Rows="4" Columns="6"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdress" runat="server" ErrorMessage="Adres girmelisiniz!" ControlToValidate="txtAdress" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="UserValidate"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-10 col-sm-10 col-md-8 col-lg-4 col-xl-4 offset-1 offset-sm-1 offset-md-2 offset-lg-2 offset-xl-2">
                                            <div class="form-group">
                                                <asp:Label ID="lblZipCode" runat="server" Text="Alan Kodu" for="txtZipCode" CssClass="text-success"></asp:Label><br />
                                                <asp:TextBox ID="txtZipCode" runat="server" name="ZipCode" CssClass="form-control" MaxLength="5"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorZipCode" runat="server" ErrorMessage="Alan kodu girmelisiniz!" ControlToValidate="txtZipCode" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="UserValidate"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorZipCode" runat="server" ErrorMessage="Geçerli bir Alan kodu girmelisiniz!" ControlToValidate="txtZipCode" ForeColor="#990000" SetFocusOnError="True" ValidationExpression="^[-+]?\d+$" Display="Dynamic" ValidationGroup="UserValidate"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblProvince" runat="server" Text="Şehir" for="txtProvince" CssClass="text-success"></asp:Label><br />
                                                <asp:TextBox ID="txtProvince" runat="server" CssClass="form-control" name="txtProvince"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorProvinve" runat="server" ErrorMessage="Şehir adı girmelisiniz!" ControlToValidate="txtProvince" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="UserValidate"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblDistrict" runat="server" Text="İlçe" for="txtDistrict" CssClass="text-success"></asp:Label><br />
                                                <asp:TextBox ID="txtDistrict" runat="server" name="District" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDistrict" runat="server" ErrorMessage="İlçe adı girmelisiniz!" ControlToValidate="txtDistrict" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="UserValidate"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblGender" runat="server" Text="Cinsiyet" for="ddlGender" CssClass="text-success"></asp:Label><br />
                                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="dropdown form-control">
                                                    <asp:ListItem Text="" Value="" />
                                                    <asp:ListItem Text="Erkek" Value="Erkek" />
                                                    <asp:ListItem Text="Kadın" Value="Kadın" />
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ErrorMessage="Cinsiyet seçmelisiniz!" ControlToValidate="ddlGender" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="UserValidate"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="row">
                                                <div class="col-xl-6 text-center">
                                                    <asp:Image ID="UserManageProfileImg" runat="server" CssClass="rounded-circle" alt="ProfilResmi" Width="180" Height="180" />
                                                </div>
                                                <div class="col-xl-6 text-center">
                                                    <asp:FileUpload ID="FileUploadProfileImage" runat="server" CssClass="btn btn-success" Style="width: 110px;" ValidationGroup="UserValidate" /><br /><br />
                                                    <asp:Button ID="btnUserUpdate" runat="server" Text="Kullanıcıyı Güncelle" CssClass="btn btn-outline-success btn-md" OnClick="btnUserUpdate_Click" ValidationGroup="UserValidate" /><br /><br />
                                                     <asp:Button ID="btnVazgec" runat="server" Text="Vazgeç" CssClass="btn btn-outline-info btn-md" OnClick="btnVazgec_Click" />
                                                </div>
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </Content>
                </ajaxToolkit:AccordionPane>
            </Panes>
        </ajaxToolkit:Accordion>
    </div>
     <script type="text/javascript">
        $(document).ready(function () {
            var rows = $("#ContentPlaceHolder1_gvUsers").find("tr").length - 1;
            $("#ContentPlaceHolder1_gvUsers_cbxAllDelete").click(function () {
                if (this.checked === true) {
                    for (var i = 0; i < rows; i++) {
                        var cbxID = "#ContentPlaceHolder1_gvUsers_cbxSelectDelete_" + i;
                        $(cbxID).prop('checked', true);
                    }
                }
                else {
                    for (var i = 0; i < rows; i++) {
                        var cbxID = "#ContentPlaceHolder1_gvUsers_cbxSelectDelete_" + i;
                        $(cbxID).prop('checked', false);
                    }
                };
            });

        });
    </script>
</asp:Content>
