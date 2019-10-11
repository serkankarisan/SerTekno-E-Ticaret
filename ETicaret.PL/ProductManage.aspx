<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductManage.aspx.cs" Inherits="ETicaret.PL.ProductManage" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManagerProduct" runat="server"></asp:ScriptManager>
    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
        <ajaxToolkit:Accordion ID="AccordionProduct" runat="server" CssClass="" HeaderCssClass="btn btn-outline-success mb-2 mt-2 ml-2" HeaderSelectedCssClass="btn btn-success mb-2 mt-2 ml-2" FadeTransitions="true" TransitionDuration="500" AutoSize="None" SelectedIndex="0">
            <Panes>
                <ajaxToolkit:AccordionPane ID="AccordionEditProduct" CssClass="pt-3" runat="server" ContentCssClass="text-center table-responsive ">
                    <Header>
                        Ürünleri Düzenle
                    </Header>
                    <Content>
                        <asp:Panel ID="pnlAlertDivAccordionEdit" runat="server" role="alert" Visible="False">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <asp:Label ID="lblAlertDivAccordionEdit" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                        <asp:GridView CssClass="table table-responsive table-striped" runat="server" OnRowDeleting="gvProduct_RowDeleting" OnRowEditing="gvProduct_RowEditing" OnRowCancelingEdit="gvProduct_RowCancelingEdit" OnRowUpdating="gvProduct_RowUpdating" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" ID="gvProduct" ShowFooter="True" AllowPaging="True" DataKeyNames="Id">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbxAllDelete" runat="server" Text="Hepsini Seç" />
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        <button id="btnDeleteModal" type="button" class="btn btn-outline-danger pt-0 pb-0" data-toggle="modal" data-target="#DeleteConfirmModal" style="width: 125px;">Seçilenleri Sil</button>
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
                                                            <asp:Button CssClass="btn btn-success" ID="btnModalDelete" runat="server" Text="Onayla" Width="125px" OnClick="btnSelectedDelete_Click" />
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
                                    <HeaderStyle Width="130px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ProductName" HeaderText="Ürün Adı" />
                                <asp:BoundField DataField="BrandName" HeaderText="Marka" />
                                <asp:BoundField DataField="ModelName" HeaderText="Model" />
                                <asp:BoundField DataField="Origin" HeaderText="Menşei" />
                                <asp:BoundField DataField="WarrantyYearCount" HeaderText="Garanti Süresi" />
                                <asp:BoundField DataField="StockCount" HeaderText="Stok Miktarı" />
                                <asp:BoundField DataField="CriticalStockCount" HeaderText="Kritik Seviye" />
                                <asp:BoundField DataField="Price" HeaderText="Fiyat" />
                                <asp:BoundField DataField="CategoryName" HeaderText="Kategori" />
                                <asp:BoundField DataField="SubCategoryName" HeaderText="Alt Kategori" />
                                <asp:BoundField DataField="ProductCode" HeaderText="Ürün Kodu" />
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lbtnUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Değiştir"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="lbtnCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Vazgeç"></asp:LinkButton>
                                    </EditItemTemplate>
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
                <ajaxToolkit:AccordionPane ID="AccordionAddProduct" CssClass="pt-3" runat="server">
                    <Header>
                         Yeni Ürün Ekle
                    </Header>
                    <Content>
                        <asp:Panel ID="pnlAlertDiv" runat="server" role="alert" Visible="False">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <asp:Label ID="lblAlertDiv" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                        <div class="card-body">
                            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pt-5">
                                <div class="row">
                                    <div class="col-10 col-sm-10 col-md-8 col-lg-4 col-xl-4 offset-1 offset-sm-1 offset-md-2 offset-lg-1 offset-xl-1">
                                        <div class="form-group">
                                            <asp:Label ID="lblProductName" runat="server" Text="Ürün Adı" for="txtProductName" CssClass="text-success"></asp:Label><br />
                                            <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" name="txtProductName"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductName" runat="server" ErrorMessage="Ürün adı girmelisiniz!" ControlToValidate="txtProductName" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ProductValidate"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="lblOrigin" runat="server" Text="Menşei" for="txtOrigin" CssClass="text-success"></asp:Label><br />
                                            <asp:TextBox ID="txtOrigin" runat="server" name="Origin" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="lblDescription" runat="server" Text="Açıklama" for="txtDescription" CssClass="text-success"></asp:Label><br />
                                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" name="txtDescription"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="lblWarrantYearCount" runat="server" Text="Garanti Süresi" for="txtWarrantYearCount" CssClass="text-success"></asp:Label><br />
                                            <asp:TextBox ID="txtWarrantYearCount" runat="server" CssClass="form-control" name="txtWarrantYearCount" MaxLength="2"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="lblStockCount" runat="server" Text="Stok Sayısı" for="txtStockCount" CssClass="text-success"></asp:Label><br />
                                            <asp:TextBox ID="txtStockCount" runat="server" name="StockCount" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorStockCount" runat="server" ErrorMessage="Stok miktarı girmelisiniz!" ControlToValidate="txtStockCount" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ProductValidate"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="lblCriticalStockCount" runat="server" Text="Kritik Stok Miktarı" for="txtCriticalStockCount" CssClass="text-success"></asp:Label><br />
                                            <asp:TextBox ID="txtCriticalStockCount" runat="server" name="CriticalStockCount" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCriticalStockCount" runat="server" ErrorMessage="Kritik Seviye girmelisiniz!" ControlToValidate="txtCriticalStockCount" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ProductValidate"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="lblPrice" runat="server" Text="Fiyat" for="txtPrice" CssClass="text-success"></asp:Label><br />
                                            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" name="txtPrice"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" runat="server" ErrorMessage="Fiyat girmelisiniz!" ControlToValidate="txtPrice" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ProductValidate"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-10 col-sm-10 col-md-8 col-lg-4 col-xl-4 offset-1 offset-sm-1 offset-md-2 offset-lg-2 offset-xl-2">
                                        <div class="form-group">
                                            <asp:Label ID="lblBrand" runat="server" Text="Marka" for="ddlBrand" CssClass="text-success"></asp:Label><br />
                                            <div class="row">
                                                <asp:DropDownList ID="ddlBrand" runat="server" AutoPostBack="true" CssClass="dropdown form-control col-10 col-sm-10 col-md-10 col-lg-10 col-xl-10" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged">
                                                    <asp:ListItem Text="" Value="" />
                                                </asp:DropDownList>
                                                <button type="button" class="btn btn-outline-success col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2" data-toggle="modal" data-target="#BrandModal">
                                                    Ekle
                                                </button>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrand" runat="server" ErrorMessage="Marka seçmelisiniz!" ControlToValidate="ddlBrand" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ProductValidate"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="lblModel" runat="server" Text="Model" for="ddlModel" CssClass="text-success"></asp:Label><br />
                                            <div class="row">
                                                <asp:DropDownList ID="ddlModel" runat="server" CssClass="dropdown form-control col-10 col-sm-10 col-md-10 col-lg-10 col-xl-10">
                                                    <asp:ListItem Text="" Value="" />
                                                </asp:DropDownList>
                                                <button type="button" class="btn btn-outline-success col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2" data-toggle="modal" data-target="#ModelModal">
                                                    Ekle
                                                </button>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorModel" runat="server" ErrorMessage="Model seçmelisiniz!" ControlToValidate="ddlModel" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ProductValidate"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="lblCategory" runat="server" Text="Kategori" for="ddlCategory" CssClass="text-success"></asp:Label><br />
                                            <div class="row">
                                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="dropdown form-control col-10 col-sm-10 col-md-10 col-lg-10 col-xl-10" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Text="" Value="" />
                                                </asp:DropDownList>
                                                <button type="button" class="btn btn-outline-success col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2" data-toggle="modal" data-target="#CategoryModal">
                                                    Ekle
                                                </button>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server" ErrorMessage="Kategori seçmelisiniz!" ControlToValidate="ddlCategory" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ProductValidate"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="lblSubCategory" runat="server" Text="Alt Kategori" for="ddlSubCategory" CssClass="text-success"></asp:Label><br />
                                            <div class="row">
                                                <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="dropdown form-control col-10 col-sm-10 col-md-10 col-lg-10 col-xl-10">
                                                    <asp:ListItem Text="" Value="" />
                                                </asp:DropDownList>
                                                <button type="button" class="btn btn-outline-success col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2" data-toggle="modal" data-target="#SubCategoryModal">
                                                    Ekle
                                                </button>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCategory" runat="server" ErrorMessage="Alt Kategori seçmelisiniz!" ControlToValidate="ddlSubCategory" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ProductValidate"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="lblProperties" runat="server" Text="Özellikler" for="txtProperties" CssClass="text-success"></asp:Label><br />
                                            <asp:TextBox ID="txtProperties" runat="server" name="Properties" CssClass="form-control" TextMode="MultiLine" Columns="6" Rows="4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorProperties" runat="server" ErrorMessage="Özellikleri girmelisiniz!" ControlToValidate="txtProperties" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ProductValidate"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="lblCoverImage" runat="server" Text="Kapak Fotoğrafı" for="txtCoverImage" CssClass="text-success"></asp:Label><br />
                                            <div class="row">
                                                <div class="text-left col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6">
                                                    <asp:FileUpload ID="FileUploadCoverImage" runat="server" CssClass="btn btn-success" Style="width: 110px;" />
                                                </div>
                                                <div class="text-right col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6">
                                                    <asp:Button ID="btnKaydet" runat="server" Text="Ürünü Kaydet" CssClass="btn btn-outline-success btn-md" OnClick="btnKaydet_Click" ValidationGroup="ProductValidate" />
                                                </div>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCoverImage" runat="server" ErrorMessage="Kapak Fotoğrafı seçmelisiniz!" ControlToValidate="FileUploadCoverImage" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ProductValidate"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </Content>
                </ajaxToolkit:AccordionPane>
            </Panes>
        </ajaxToolkit:Accordion>
    </div>
    
    <asp:Panel ID="pnlBrandModal" runat="server" DefaultButton="btnModalBrandSave">
        <!-- BrandModal -->
        <div class="modal fade" id="BrandModal" tabindex="-1" role="dialog" aria-labelledby="BrandModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="BrandModalLabel">Marka Ekle</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:Label ID="lblModalBrand" runat="server" Text="Marka Adı" for="txtModalBrand" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtModalBrand" runat="server" CssClass="form-control" name="txtModalBrand"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorModalBrand" runat="server" ErrorMessage="Marka Adı girmelisiniz!" ControlToValidate="txtModalBrand" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ModalBrandValidate"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Vazgeç</button>
                        <asp:Button ValidationGroup="ModalBrandValidate" ID="btnModalBrandSave" runat="server" Text="Kaydet" CssClass="btn btn-success" OnClick="btnModalBrandSave_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- BrandModal End-->
    </asp:Panel>
    <asp:Panel ID="pnlModelModal" runat="server" DefaultButton="btnModalModelSave">
        <!-- ModelModal -->
        <div class="modal fade" id="ModelModal" tabindex="-1" role="dialog" aria-labelledby="ModelModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="ModelModalLabel">Model Ekle</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:Label ID="lblModalModel" runat="server" Text="Model Adı" for="txtModalModel" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtModalModel" runat="server" CssClass="form-control" name="txtModalModel"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorModalModel" runat="server" ErrorMessage="Model Adı girmelisiniz!" ControlToValidate="txtModalModel" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ModalModelValidate"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblModalModelBrand" runat="server" Text="Marka" for="ddlModalModelBrand" CssClass="text-success"></asp:Label><br />
                            <div class="row container-fluid">
                                <asp:DropDownList ID="ddlModalModelBrand" runat="server" CssClass="dropdown form-control">
                                    <asp:ListItem Text="" Value="" />
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorModalModelBrand" runat="server" ErrorMessage="Marka seçmelisiniz!" ControlToValidate="ddlModalModelBrand" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ModalModelValidate"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Vazgeç</button>
                        <asp:Button ValidationGroup="ModalModelValidate" ID="btnModalModelSave" runat="server" Text="Kaydet" CssClass="btn btn-success" OnClick="btnModalModelSave_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- ModelModal End-->
    </asp:Panel>
    <asp:Panel ID="pnlCategoryModal" runat="server" DefaultButton="btnModalCategorySave">
        <!-- CategoryModal -->
        <div class="modal fade" id="CategoryModal" tabindex="-1" role="dialog" aria-labelledby="CategoryModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="CategoryModalLabel">Kategori Ekle</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:Label ID="lblModalCategory" runat="server" Text="Kategori Adı" for="txtModalCategory" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtModalCategory" runat="server" CssClass="form-control" name="txtModalCategory"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorModalCategory" runat="server" ErrorMessage="Kategori Adı girmelisiniz!" ControlToValidate="txtModalCategory" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ModalCategoryValidate"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Vazgeç</button>
                        <asp:Button ID="btnModalCategorySave" runat="server" Text="Kaydet" CssClass="btn btn-success" ValidationGroup="ModalCategoryValidate" OnClick="btnModalCategorySave_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- CategoryModal End-->
    </asp:Panel>
    <asp:Panel ID="pnlModalSubCategory" runat="server" DefaultButton="btnModalSubCategorySave">
        <!-- SubCategoryModal -->
        <div class="modal fade" id="SubCategoryModal" tabindex="-1" role="dialog" aria-labelledby="SubCategoryModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="SubCategoryModalLabel">Alt Kategori Ekle</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:Label ID="lblModalSubCategory" runat="server" Text="Alt Kategori Adı" for="txtModalSubCategory" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtModalSubCategory" runat="server" CssClass="form-control" name="txtModalSubCategory"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorModalSubCategory" runat="server" ErrorMessage="Alt Katgegori Adı girmelisiniz!" ControlToValidate="txtModalSubCategory" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ModalSubCategoryValidate"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblModalSubCategoryCategory" runat="server" Text="Kategori" for="ddlModalSubCategoryCategory" CssClass="text-success"></asp:Label><br />
                            <div class="row container-fluid">
                                <asp:DropDownList ID="ddlModalSubCategoryCategory" runat="server" CssClass="dropdown form-control">
                                    <asp:ListItem Text="" Value="" />
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorModalSubCategoryCategory" runat="server" ErrorMessage="Kategori seçmelisiniz!" ControlToValidate="ddlModalSubCategoryCategory" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ModalSubCategoryValidate"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Vazgeç</button>
                        <asp:Button ID="btnModalSubCategorySave" runat="server" Text="Kaydet" CssClass="btn btn-success" ValidationGroup="ModalSubCategoryValidate" OnClick="btnModalSubCategorySave_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- SubCategoryModal End-->
    </asp:Panel>
    <script type="text/javascript">
        $(document).ready(function () {
            var rows = $("#ContentPlaceHolder1_gvProduct").find("tr").length - 1;
            $("#ContentPlaceHolder1_gvProduct_cbxAllDelete").click(function () {
                if (this.checked === true) {
                    for (var i = 0; i < rows; i++) {
                        var cbxID = "#ContentPlaceHolder1_gvProduct_cbxSelectDelete_" + i;
                        $(cbxID).prop('checked', true);
                    }
                }
                else {
                    for (var i = 0; i < rows; i++) {
                        var cbxID = "#ContentPlaceHolder1_gvProduct_cbxSelectDelete_" + i;
                        $(cbxID).prop('checked', false);
                    }
                };
            });
           
        });
</script>
</asp:Content>

