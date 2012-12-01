using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BinxEd
{
	/// <summary>
	/// MainForm is the main View for the application.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private Controller	controller_;
		private ContextMenu tv1Menu;
		private TreeNode targetNode_;
		private	int	RightPaneWidth_;
//		private bool defineMode_;

		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemNew;
		private System.Windows.Forms.MenuItem menuItemOpen;
		private System.Windows.Forms.MenuItem menuItemSave;
		private System.Windows.Forms.MenuItem menuItemSaveAs;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemEdit;
		private System.Windows.Forms.MenuItem menuItemAddAfter;
		private System.Windows.Forms.MenuItem menuItemAddChild;
		private System.Windows.Forms.MenuItem menuItemDefine;
		private System.Windows.Forms.MenuItem menuItemDefineStruct;
		private System.Windows.Forms.MenuItem menuItemDefineUnion;
		private System.Windows.Forms.MenuItem menuItemDefineArray;
		private System.Windows.Forms.MenuItem menuItemUtility;
		private System.Windows.Forms.MenuItem menuItemValidate;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemDocument;
		private System.Windows.Forms.MenuItem menuItemSchema;
		private System.Windows.Forms.MenuItem menuItemSave0;
		private System.Windows.Forms.MenuItem menuItemAboutMe;
		private System.Windows.Forms.ToolBarButton toolBarButtonNew;
		private System.Windows.Forms.ToolBarButton toolBarButtonOpen;
		private System.Windows.Forms.ToolBarButton toolBarButtonSave;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.MenuItem menuItemFile3;
		private System.Windows.Forms.MenuItem menuItemDelete;
		private System.Windows.Forms.MenuItem menuItemFile7;
		private System.Windows.Forms.MenuItem menuItemBigEndian;
		private System.Windows.Forms.ToolBarButton toolBarButtonDelete;
		private System.Windows.Forms.MenuItem menuItemBrowse;
		private PropertyView listView1;
		private System.Windows.Forms.ImageList imageListNodeIcons;
		private System.Windows.Forms.MenuItem menuItemAddBefore;
		private System.Windows.Forms.MenuItem menuItemPrimitiveBefore;
		private System.Windows.Forms.MenuItem menuItemDefinedBefore;
		private System.Windows.Forms.MenuItem menuItemStructBefore;
		private System.Windows.Forms.MenuItem menuItemUnionBefore;
		private System.Windows.Forms.MenuItem menuItemArrayBefore;
		private System.Windows.Forms.MenuItem menuItemCaseBefore;
		private System.Windows.Forms.MenuItem menuItemPrimitiveAfter;
		private System.Windows.Forms.MenuItem menuItemDefinedAfter;
		private System.Windows.Forms.MenuItem menuItemStructAfter;
		private System.Windows.Forms.MenuItem menuItemUnionAfter;
		private System.Windows.Forms.MenuItem menuItemArrayAfter;
		private System.Windows.Forms.MenuItem menuItemCaseAfter;
		private System.Windows.Forms.MenuItem menuItemPrimitiveChild;
		private System.Windows.Forms.MenuItem menuItemDefinedChild;
		private System.Windows.Forms.MenuItem menuItemStructChild;
		private System.Windows.Forms.MenuItem menuItemUnionChild;
		private System.Windows.Forms.MenuItem menuItemArrayChild;
		private System.Windows.Forms.MenuItem menuItemCaseChild;
		private System.Windows.Forms.MenuItem menuItemDimChild;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItemFontPlus;
		private System.Windows.Forms.MenuItem menuItemFontMinus;
		private System.Windows.Forms.ToolBarButton toolBarButtonSeparator2;
		private System.Windows.Forms.ToolBarButton toolBarButtonFontPlus;
		private System.Windows.Forms.ToolBarButton toolBarButtonFontMinus;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItemImport;
		private System.Windows.Forms.ToolBarButton toolBarButtonBrowse;
		private System.Windows.Forms.ToolBarButton toolBarButtonValidate;
		private System.Windows.Forms.ToolBarButton toolBarButtonSeparator3;
		private System.Windows.Forms.ToolBarButton toolBarButtonImport;
		private System.Windows.Forms.ToolBarButton toolBarButtonSeparator1;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			controller_ = new Controller(this);
			RightPaneWidth_ = this.Width - splitter1.SplitPosition;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButtonNew = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonOpen = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSave = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSeparator1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonDelete = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSeparator2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonFontPlus = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonFontMinus = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSeparator3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonBrowse = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonValidate = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonImport = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItemFile = new System.Windows.Forms.MenuItem();
			this.menuItemNew = new System.Windows.Forms.MenuItem();
			this.menuItemOpen = new System.Windows.Forms.MenuItem();
			this.menuItemSave = new System.Windows.Forms.MenuItem();
			this.menuItemSaveAs = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItemExit = new System.Windows.Forms.MenuItem();
			this.menuItemEdit = new System.Windows.Forms.MenuItem();
			this.menuItemAddBefore = new System.Windows.Forms.MenuItem();
			this.menuItemPrimitiveBefore = new System.Windows.Forms.MenuItem();
			this.menuItemDefinedBefore = new System.Windows.Forms.MenuItem();
			this.menuItemStructBefore = new System.Windows.Forms.MenuItem();
			this.menuItemUnionBefore = new System.Windows.Forms.MenuItem();
			this.menuItemArrayBefore = new System.Windows.Forms.MenuItem();
			this.menuItemCaseBefore = new System.Windows.Forms.MenuItem();
			this.menuItemAddAfter = new System.Windows.Forms.MenuItem();
			this.menuItemPrimitiveAfter = new System.Windows.Forms.MenuItem();
			this.menuItemDefinedAfter = new System.Windows.Forms.MenuItem();
			this.menuItemStructAfter = new System.Windows.Forms.MenuItem();
			this.menuItemUnionAfter = new System.Windows.Forms.MenuItem();
			this.menuItemArrayAfter = new System.Windows.Forms.MenuItem();
			this.menuItemCaseAfter = new System.Windows.Forms.MenuItem();
			this.menuItemAddChild = new System.Windows.Forms.MenuItem();
			this.menuItemPrimitiveChild = new System.Windows.Forms.MenuItem();
			this.menuItemDefinedChild = new System.Windows.Forms.MenuItem();
			this.menuItemStructChild = new System.Windows.Forms.MenuItem();
			this.menuItemUnionChild = new System.Windows.Forms.MenuItem();
			this.menuItemArrayChild = new System.Windows.Forms.MenuItem();
			this.menuItemCaseChild = new System.Windows.Forms.MenuItem();
			this.menuItemDimChild = new System.Windows.Forms.MenuItem();
			this.menuItemFile3 = new System.Windows.Forms.MenuItem();
			this.menuItemDelete = new System.Windows.Forms.MenuItem();
			this.menuItemFile7 = new System.Windows.Forms.MenuItem();
			this.menuItemBigEndian = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItemFontPlus = new System.Windows.Forms.MenuItem();
			this.menuItemFontMinus = new System.Windows.Forms.MenuItem();
			this.menuItemDefine = new System.Windows.Forms.MenuItem();
			this.menuItemDefineStruct = new System.Windows.Forms.MenuItem();
			this.menuItemDefineUnion = new System.Windows.Forms.MenuItem();
			this.menuItemDefineArray = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItemImport = new System.Windows.Forms.MenuItem();
			this.menuItemUtility = new System.Windows.Forms.MenuItem();
			this.menuItemBrowse = new System.Windows.Forms.MenuItem();
			this.menuItemValidate = new System.Windows.Forms.MenuItem();
			this.menuItemHelp = new System.Windows.Forms.MenuItem();
			this.menuItemDocument = new System.Windows.Forms.MenuItem();
			this.menuItemSchema = new System.Windows.Forms.MenuItem();
			this.menuItemSave0 = new System.Windows.Forms.MenuItem();
			this.menuItemAboutMe = new System.Windows.Forms.MenuItem();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imageListNodeIcons = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.listView1 = new BinxEd.PropertyView();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButtonNew,
																						this.toolBarButtonOpen,
																						this.toolBarButtonSave,
																						this.toolBarButtonSeparator1,
																						this.toolBarButtonDelete,
																						this.toolBarButtonSeparator2,
																						this.toolBarButtonFontPlus,
																						this.toolBarButtonFontMinus,
																						this.toolBarButtonSeparator3,
																						this.toolBarButtonBrowse,
																						this.toolBarButtonValidate,
																						this.toolBarButtonImport});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(752, 29);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButtonNew
			// 
			this.toolBarButtonNew.ImageIndex = 0;
			this.toolBarButtonNew.Tag = "NEW";
			this.toolBarButtonNew.ToolTipText = "Create new BinX document";
			// 
			// toolBarButtonOpen
			// 
			this.toolBarButtonOpen.ImageIndex = 1;
			this.toolBarButtonOpen.Tag = "OPEN";
			this.toolBarButtonOpen.ToolTipText = "Open a BinX document";
			// 
			// toolBarButtonSave
			// 
			this.toolBarButtonSave.ImageIndex = 2;
			this.toolBarButtonSave.Tag = "SAVE";
			this.toolBarButtonSave.ToolTipText = "Save BinX document";
			// 
			// toolBarButtonSeparator1
			// 
			this.toolBarButtonSeparator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonDelete
			// 
			this.toolBarButtonDelete.Enabled = false;
			this.toolBarButtonDelete.ImageIndex = 6;
			this.toolBarButtonDelete.Tag = "DELETE";
			this.toolBarButtonDelete.ToolTipText = "Delete the selected node";
			// 
			// toolBarButtonSeparator2
			// 
			this.toolBarButtonSeparator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonFontPlus
			// 
			this.toolBarButtonFontPlus.ImageIndex = 7;
			this.toolBarButtonFontPlus.Tag = "FONT+";
			this.toolBarButtonFontPlus.ToolTipText = "Increase Font size in TreeView";
			// 
			// toolBarButtonFontMinus
			// 
			this.toolBarButtonFontMinus.ImageIndex = 8;
			this.toolBarButtonFontMinus.Tag = "FONT-";
			this.toolBarButtonFontMinus.ToolTipText = "Decrease Font size in TreeView";
			// 
			// toolBarButtonSeparator3
			// 
			this.toolBarButtonSeparator3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonBrowse
			// 
			this.toolBarButtonBrowse.ImageIndex = 3;
			this.toolBarButtonBrowse.Tag = "BROWSE";
			this.toolBarButtonBrowse.ToolTipText = "View BinX document in Browser";
			// 
			// toolBarButtonValidate
			// 
			this.toolBarButtonValidate.ImageIndex = 4;
			this.toolBarButtonValidate.Tag = "VALIDATE";
			this.toolBarButtonValidate.ToolTipText = "Validate a BinX document";
			// 
			// toolBarButtonImport
			// 
			this.toolBarButtonImport.ImageIndex = 5;
			this.toolBarButtonImport.Tag = "IMPORT";
			this.toolBarButtonImport.ToolTipText = "Import type definitions from another BinX document";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "xml";
			this.openFileDialog1.Filter = "BinX document|*.xml";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "xml";
			this.saveFileDialog1.Filter = "BinX document|*.xml";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 565);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(752, 16);
			this.statusBar1.TabIndex = 1;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemFile,
																					  this.menuItemEdit,
																					  this.menuItemDefine,
																					  this.menuItemUtility,
																					  this.menuItemHelp});
			// 
			// menuItemFile
			// 
			this.menuItemFile.Index = 0;
			this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemNew,
																						 this.menuItemOpen,
																						 this.menuItemSave,
																						 this.menuItemSaveAs,
																						 this.menuItem6,
																						 this.menuItemExit});
			this.menuItemFile.Text = "&File";
			// 
			// menuItemNew
			// 
			this.menuItemNew.Index = 0;
			this.menuItemNew.Text = "&New";
			this.menuItemNew.Click += new System.EventHandler(this.menuItemNew_Click);
			// 
			// menuItemOpen
			// 
			this.menuItemOpen.Index = 1;
			this.menuItemOpen.Text = "&Open";
			this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
			// 
			// menuItemSave
			// 
			this.menuItemSave.Index = 2;
			this.menuItemSave.Text = "&Save";
			this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
			// 
			// menuItemSaveAs
			// 
			this.menuItemSaveAs.Index = 3;
			this.menuItemSaveAs.Text = "Save &As";
			this.menuItemSaveAs.Click += new System.EventHandler(this.menuItemSaveAs_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 4;
			this.menuItem6.Text = "-";
			// 
			// menuItemExit
			// 
			this.menuItemExit.Index = 5;
			this.menuItemExit.Text = "E&xit";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// menuItemEdit
			// 
			this.menuItemEdit.Index = 1;
			this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemAddBefore,
																						 this.menuItemAddAfter,
																						 this.menuItemAddChild,
																						 this.menuItemFile3,
																						 this.menuItemDelete,
																						 this.menuItemFile7,
																						 this.menuItemBigEndian,
																						 this.menuItem1,
																						 this.menuItemFontPlus,
																						 this.menuItemFontMinus});
			this.menuItemEdit.Text = "&Edit";
			// 
			// menuItemAddBefore
			// 
			this.menuItemAddBefore.Enabled = false;
			this.menuItemAddBefore.Index = 0;
			this.menuItemAddBefore.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							  this.menuItemPrimitiveBefore,
																							  this.menuItemDefinedBefore,
																							  this.menuItemStructBefore,
																							  this.menuItemUnionBefore,
																							  this.menuItemArrayBefore,
																							  this.menuItemCaseBefore});
			this.menuItemAddBefore.Text = "Add Before";
			// 
			// menuItemPrimitiveBefore
			// 
			this.menuItemPrimitiveBefore.Index = 0;
			this.menuItemPrimitiveBefore.Text = "Primitive";
			this.menuItemPrimitiveBefore.Click += new System.EventHandler(this.menuItemPrimitiveBefore_Click);
			// 
			// menuItemDefinedBefore
			// 
			this.menuItemDefinedBefore.Index = 1;
			this.menuItemDefinedBefore.Text = "Defined";
			this.menuItemDefinedBefore.Click += new System.EventHandler(this.menuItemDefinedBefore_Click);
			// 
			// menuItemStructBefore
			// 
			this.menuItemStructBefore.Index = 2;
			this.menuItemStructBefore.Text = "Struct";
			this.menuItemStructBefore.Click += new System.EventHandler(this.menuItemStructBefore_Click);
			// 
			// menuItemUnionBefore
			// 
			this.menuItemUnionBefore.Index = 3;
			this.menuItemUnionBefore.Text = "Union";
			this.menuItemUnionBefore.Click += new System.EventHandler(this.menuItemUnionBefore_Click);
			// 
			// menuItemArrayBefore
			// 
			this.menuItemArrayBefore.Index = 4;
			this.menuItemArrayBefore.Text = "Array";
			this.menuItemArrayBefore.Click += new System.EventHandler(this.menuItemArrayBefore_Click);
			// 
			// menuItemCaseBefore
			// 
			this.menuItemCaseBefore.Index = 5;
			this.menuItemCaseBefore.Text = "Case";
			this.menuItemCaseBefore.Click += new System.EventHandler(this.menuItemCaseBefore_Click);
			// 
			// menuItemAddAfter
			// 
			this.menuItemAddAfter.Enabled = false;
			this.menuItemAddAfter.Index = 1;
			this.menuItemAddAfter.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.menuItemPrimitiveAfter,
																							 this.menuItemDefinedAfter,
																							 this.menuItemStructAfter,
																							 this.menuItemUnionAfter,
																							 this.menuItemArrayAfter,
																							 this.menuItemCaseAfter});
			this.menuItemAddAfter.Text = "Add After";
			// 
			// menuItemPrimitiveAfter
			// 
			this.menuItemPrimitiveAfter.Index = 0;
			this.menuItemPrimitiveAfter.Text = "Primitive";
			this.menuItemPrimitiveAfter.Click += new System.EventHandler(this.menuItemPrimitiveAfter_Click);
			// 
			// menuItemDefinedAfter
			// 
			this.menuItemDefinedAfter.Index = 1;
			this.menuItemDefinedAfter.Text = "Defined";
			this.menuItemDefinedAfter.Click += new System.EventHandler(this.menuItemDefinedAfter_Click);
			// 
			// menuItemStructAfter
			// 
			this.menuItemStructAfter.Index = 2;
			this.menuItemStructAfter.Text = "Struct";
			this.menuItemStructAfter.Click += new System.EventHandler(this.menuItemStructAfter_Click);
			// 
			// menuItemUnionAfter
			// 
			this.menuItemUnionAfter.Index = 3;
			this.menuItemUnionAfter.Text = "Union";
			this.menuItemUnionAfter.Click += new System.EventHandler(this.menuItemUnionAfter_Click);
			// 
			// menuItemArrayAfter
			// 
			this.menuItemArrayAfter.Index = 4;
			this.menuItemArrayAfter.Text = "Array";
			this.menuItemArrayAfter.Click += new System.EventHandler(this.menuItemArrayAfter_Click);
			// 
			// menuItemCaseAfter
			// 
			this.menuItemCaseAfter.Index = 5;
			this.menuItemCaseAfter.Text = "Case";
			this.menuItemCaseAfter.Click += new System.EventHandler(this.menuItemCaseAfter_Click);
			// 
			// menuItemAddChild
			// 
			this.menuItemAddChild.Enabled = false;
			this.menuItemAddChild.Index = 2;
			this.menuItemAddChild.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.menuItemPrimitiveChild,
																							 this.menuItemDefinedChild,
																							 this.menuItemStructChild,
																							 this.menuItemUnionChild,
																							 this.menuItemArrayChild,
																							 this.menuItemCaseChild,
																							 this.menuItemDimChild});
			this.menuItemAddChild.Text = "Add Child";
			// 
			// menuItemPrimitiveChild
			// 
			this.menuItemPrimitiveChild.Index = 0;
			this.menuItemPrimitiveChild.Text = "Primitive";
			this.menuItemPrimitiveChild.Click += new System.EventHandler(this.menuItemPrimitiveChild_Click);
			// 
			// menuItemDefinedChild
			// 
			this.menuItemDefinedChild.Index = 1;
			this.menuItemDefinedChild.Text = "Defined";
			this.menuItemDefinedChild.Click += new System.EventHandler(this.menuItemDefinedChild_Click);
			// 
			// menuItemStructChild
			// 
			this.menuItemStructChild.Index = 2;
			this.menuItemStructChild.Text = "Struct";
			this.menuItemStructChild.Click += new System.EventHandler(this.menuItemStructChild_Click);
			// 
			// menuItemUnionChild
			// 
			this.menuItemUnionChild.Index = 3;
			this.menuItemUnionChild.Text = "Union";
			this.menuItemUnionChild.Click += new System.EventHandler(this.menuItemUnionChild_Click);
			// 
			// menuItemArrayChild
			// 
			this.menuItemArrayChild.Index = 4;
			this.menuItemArrayChild.Text = "Array";
			this.menuItemArrayChild.Click += new System.EventHandler(this.menuItemArrayChild_Click);
			// 
			// menuItemCaseChild
			// 
			this.menuItemCaseChild.Index = 5;
			this.menuItemCaseChild.Text = "Case";
			this.menuItemCaseChild.Click += new System.EventHandler(this.menuItemCaseChild_Click);
			// 
			// menuItemDimChild
			// 
			this.menuItemDimChild.Index = 6;
			this.menuItemDimChild.Text = "Dim";
			this.menuItemDimChild.Click += new System.EventHandler(this.menuItemDimChild_Click);
			// 
			// menuItemFile3
			// 
			this.menuItemFile3.Index = 3;
			this.menuItemFile3.Text = "-";
			// 
			// menuItemDelete
			// 
			this.menuItemDelete.Enabled = false;
			this.menuItemDelete.Index = 4;
			this.menuItemDelete.Text = "Delete";
			this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
			// 
			// menuItemFile7
			// 
			this.menuItemFile7.Index = 5;
			this.menuItemFile7.Text = "-";
			// 
			// menuItemBigEndian
			// 
			this.menuItemBigEndian.Index = 6;
			this.menuItemBigEndian.RadioCheck = true;
			this.menuItemBigEndian.Text = "Big-Endian";
			this.menuItemBigEndian.Click += new System.EventHandler(this.menuItemBigEndian_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 7;
			this.menuItem1.Text = "-";
			// 
			// menuItemFontPlus
			// 
			this.menuItemFontPlus.Index = 8;
			this.menuItemFontPlus.Text = "Font +";
			this.menuItemFontPlus.Click += new System.EventHandler(this.menuItemFontPlus_Click);
			// 
			// menuItemFontMinus
			// 
			this.menuItemFontMinus.Index = 9;
			this.menuItemFontMinus.Text = "Font -";
			this.menuItemFontMinus.Click += new System.EventHandler(this.menuItemFontMinus_Click);
			// 
			// menuItemDefine
			// 
			this.menuItemDefine.Index = 2;
			this.menuItemDefine.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.menuItemDefineStruct,
																						   this.menuItemDefineUnion,
																						   this.menuItemDefineArray,
																						   this.menuItem2,
																						   this.menuItemImport});
			this.menuItemDefine.Text = "&Define";
			// 
			// menuItemDefineStruct
			// 
			this.menuItemDefineStruct.Index = 0;
			this.menuItemDefineStruct.Text = "struct";
			this.menuItemDefineStruct.Click += new System.EventHandler(this.menuItemDefineStruct_Click);
			// 
			// menuItemDefineUnion
			// 
			this.menuItemDefineUnion.Index = 1;
			this.menuItemDefineUnion.Text = "union";
			this.menuItemDefineUnion.Click += new System.EventHandler(this.menuItemDefineUnion_Click);
			// 
			// menuItemDefineArray
			// 
			this.menuItemDefineArray.Index = 2;
			this.menuItemDefineArray.Text = "array";
			this.menuItemDefineArray.Click += new System.EventHandler(this.menuItemDefineArray_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 3;
			this.menuItem2.Text = "-";
			// 
			// menuItemImport
			// 
			this.menuItemImport.Index = 4;
			this.menuItemImport.Text = "Import";
			this.menuItemImport.Click += new System.EventHandler(this.menuItemImport_Click);
			// 
			// menuItemUtility
			// 
			this.menuItemUtility.Index = 3;
			this.menuItemUtility.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItemBrowse,
																							this.menuItemValidate});
			this.menuItemUtility.Text = "&Utility";
			// 
			// menuItemBrowse
			// 
			this.menuItemBrowse.Index = 0;
			this.menuItemBrowse.Text = "View in Browser";
			this.menuItemBrowse.Click += new System.EventHandler(this.menuItemBrowse_Click);
			// 
			// menuItemValidate
			// 
			this.menuItemValidate.Index = 1;
			this.menuItemValidate.Text = "&Validate a Document";
			this.menuItemValidate.Click += new System.EventHandler(this.menuItemValidate_Click);
			// 
			// menuItemHelp
			// 
			this.menuItemHelp.Index = 4;
			this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemDocument,
																						 this.menuItemSchema,
																						 this.menuItemSave0,
																						 this.menuItemAboutMe});
			this.menuItemHelp.Text = "&Help";
			// 
			// menuItemDocument
			// 
			this.menuItemDocument.Index = 0;
			this.menuItemDocument.Text = "Documentation";
			this.menuItemDocument.Click += new System.EventHandler(this.menuItemDocument_Click);
			// 
			// menuItemSchema
			// 
			this.menuItemSchema.Index = 1;
			this.menuItemSchema.Text = "BinX Schema";
			this.menuItemSchema.Click += new System.EventHandler(this.menuItemSchema_Click);
			// 
			// menuItemSave0
			// 
			this.menuItemSave0.Index = 2;
			this.menuItemSave0.Text = "-";
			// 
			// menuItemAboutMe
			// 
			this.menuItemAboutMe.Index = 3;
			this.menuItemAboutMe.Text = "About me";
			this.menuItemAboutMe.Click += new System.EventHandler(this.menuItemAboutMe_Click);
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.treeView1.ImageIndex = 1;
			this.treeView1.ImageList = this.imageListNodeIcons;
			this.treeView1.Location = new System.Drawing.Point(0, 29);
			this.treeView1.Name = "treeView1";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				  new System.Windows.Forms.TreeNode("BinX Document")});
			this.treeView1.SelectedImageIndex = 1;
			this.treeView1.ShowRootLines = false;
			this.treeView1.Size = new System.Drawing.Size(552, 536);
			this.treeView1.TabIndex = 6;
			this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// imageListNodeIcons
			// 
			this.imageListNodeIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.imageListNodeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListNodeIcons.ImageStream")));
			this.imageListNodeIcons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(552, 29);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(4, 536);
			this.splitter1.TabIndex = 5;
			this.splitter1.TabStop = false;
			this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
			// 
			// listView1
			// 
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.LabelWrap = false;
			this.listView1.Location = new System.Drawing.Point(556, 29);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(196, 536);
			this.listView1.TabIndex = 4;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.Resize += new System.EventHandler(this.listView1_Resize);
			this.listView1.PropertyUpdateHandler += new BinxEd.PropertyView.PropertyUpdateEvent(this.listView1_PropertyUpdateHandler);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(752, 581);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.toolBar1);
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "BinX Editor 1.0";
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			//add context menu for treeviews
			tv1Menu = new ContextMenu();
			controller_.initializeTree(treeView1.TopNode);
		}

		/// <summary>
		/// File->Exit menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Main window closing event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (controller_.isDocumentModified()) 
			{
				DialogResult r = MessageBox.Show(this,"Save file before exit?","Warning", MessageBoxButtons.YesNo);
				if (r == DialogResult.Yes) 
				{
					if (saveFileDialog1.ShowDialog(this)==DialogResult.OK)
					{
						controller_.saveDocument(saveFileDialog1.FileName, false);
					}
				}
			}
		}

		/// <summary>
		/// File->New menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemNew_Click(object sender, System.EventArgs e)
		{
			if (controller_.isDocumentModified())
			{
				DialogResult r = MessageBox.Show(this, "Save file before open another one?", "Warning", MessageBoxButtons.YesNo);
				if (r == DialogResult.Yes)
				{
					if (saveFileDialog1.ShowDialog(this)==DialogResult.OK)
					{
						controller_.saveDocument(saveFileDialog1.FileName, false);
					}
				}
			}
			controller_.clearData();
			controller_.initializeTree(treeView1.TopNode);
			this.Text = "BinX Editor 1.0";
		}

		/// <summary>
		/// File->Open menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemOpen_Click(object sender, System.EventArgs e)
		{
			if (controller_.isDocumentModified())
			{
				DialogResult r = MessageBox.Show(this, "Save file before open another one?", "Warning", MessageBoxButtons.YesNo);
				if (r == DialogResult.Yes)
				{
					if (saveFileDialog1.ShowDialog(this)==DialogResult.OK)
					{
						controller_.saveDocument(saveFileDialog1.FileName, false);
					}
				}
			}
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK) 
			{
				Cursor.Current = Cursors.WaitCursor;
				controller_.loadDocument(openFileDialog1.FileName);
				controller_.populateDataTree(treeView1.TopNode);
				menuItemBigEndian.Checked = controller_.isBigEndian();
				Cursor.Current = Cursors.Default;
				this.Text = "BinX Editor 1.0 - " + openFileDialog1.FileName;
			}
		}

		/// <summary>
		/// File->Save menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemSave_Click(object sender, System.EventArgs e)
		{
			if (controller_.requireFileName()) 
			{
				menuItemSaveAs_Click(sender, e);
			} 
			else 
			{
				controller_.saveDocument();
			}
		}

		/// <summary>
		/// File->Save As menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemSaveAs_Click(object sender, System.EventArgs e)
		{
			if (saveFileDialog1.ShowDialog(this)==DialogResult.OK)
			{
				controller_.saveDocument(saveFileDialog1.FileName, true);
				this.Text = "BinX Editor 1.0 - " + saveFileDialog1.FileName;
				((DataNode)treeView1.TopNode.LastNode).updateText();
			}
		}

		/// <summary>
		/// Toolbar button click event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button.Tag.Equals("NEW")) 
			{
				menuItemNew_Click(sender, e);
			} 
			else if (e.Button.Tag.Equals("OPEN")) 
			{
				menuItemOpen_Click(sender, e);
			} 
			else if (e.Button.Tag.Equals("SAVE"))
			{
				menuItemSave_Click(sender, e);
			} 
			else if (e.Button.Tag.Equals("DELETE"))
			{
				menuItemDelete_Click(sender, e);
			}
			else if (e.Button.Tag.Equals("FONT+"))
			{
				menuItemFontPlus_Click(sender, e);
			}
			else if (e.Button.Tag.Equals("FONT-"))
			{
				menuItemFontMinus_Click(sender, e);
			}
			else if (e.Button.Tag.Equals("BROWSE"))
			{
				menuItemBrowse_Click(sender, e);
			}
			else if (e.Button.Tag.Equals("VALIDATE"))
			{
				menuItemValidate_Click(sender, e);
			}
			else if (e.Button.Tag.Equals("IMPORT"))
			{
				menuItemImport_Click(sender, e);
			}
		}

		/// <summary>
		/// Mouse down event on treeview1 for assigning correct context menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right) 
			{
				this.treeView1.ContextMenu = null;
				targetNode_ = treeView1.GetNodeAt(e.X, e.Y);
				if (targetNode_ != null && targetNode_ != treeView1.TopNode) 
				{
					DataNode dn = (DataNode)targetNode_;
					ArrayList siblings = dn.validSiblingTypes();
					ArrayList children = dn.validChildTypes();

					tv1Menu.MenuItems.Clear();
					if (siblings != null && siblings.Count > 0 && !isArrayElement(dn) && !isCaseBody(dn)) 
					{
						MenuItem mnu = this.menuItemAddBefore.CloneMenu();
						showMenuItemsToAdd(mnu, ref siblings);
						tv1Menu.MenuItems.Add(mnu);
						MenuItem mnu2 = this.menuItemAddAfter.CloneMenu();
						showMenuItemsToAdd(mnu2, ref siblings);
						tv1Menu.MenuItems.Add(mnu2);
					}
					if (children != null && children.Count > 0) 
					{
						MenuItem mnu = this.menuItemAddChild.CloneMenu();
						showMenuItemsToAdd(mnu, ref children);
						tv1Menu.MenuItems.Add(mnu);
					}
					if (dn.canDelete()) 
					{
						MenuItem mnu = this.menuItemDelete.CloneMenu();
						mnu.Enabled = true;
						tv1Menu.MenuItems.Add(mnu);
					}
					if (tv1Menu.MenuItems.Count > 0) 
					{
						this.treeView1.ContextMenu = tv1Menu;
					} 
				}
			} 
			//left-click will incur a treeView1_AfterSelect event which is handled elsewhere
		}

		/// <summary>
		/// Define->struct menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemDefineStruct_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)treeView1.TopNode.Nodes[0];
			controller_.addStructTypeNode(node, node.Nodes.Count, true);
		}

		/// <summary>
		/// Define->Union menu
		/// </summary>
		/// TODO: Add case else support and &lt; void-0 > case body
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemDefineUnion_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)treeView1.TopNode.Nodes[0];
			controller_.addUnionTypeNode(node, node.Nodes.Count, true);
		}

		/// <summary>
		/// Define->Array menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemDefineArray_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)treeView1.TopNode.Nodes[0];
			controller_.addArrayTypeNode(node, node.Nodes.Count, true);
		}

		/// <summary>
		/// Locate the current active node. If right-clicked, targetNode_ is the interested node, otherwise, the SelectedNode.
		/// targetNode_ must be cleared after use.
		/// </summary>
		/// <returns></returns>
		private TreeNode GetActiveNode()
		{
			TreeNode thisNode = (targetNode_ != null)?targetNode_:treeView1.SelectedNode;
			targetNode_ = null;
			return thisNode;
		}

		/// <summary>
		/// Edit->Delete menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemDelete_Click(object sender, System.EventArgs e)
		{
			TreeNode tn = GetActiveNode();
			if (tn != null) 
			{
				controller_.deleteNode((DataNode)tn);
			}
		}

		/// <summary>
		/// Edit->Big-Endian menu as a check button.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemBigEndian_Click(object sender, System.EventArgs e)
		{
			menuItemBigEndian.Checked = !menuItemBigEndian.Checked;
			controller_.setBigEndian( menuItemBigEndian.Checked );
			treeView1.TopNode.Nodes[1].Text = controller_.getDatasetNodeText();
		}

		/// <summary>
		/// Help->About menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemAboutMe_Click(object sender, System.EventArgs e)
		{
			FormAbout fa = new FormAbout();
			fa.ShowDialog();
		}

		/// <summary>
		/// Make a valid path.
		/// </summary>
		/// <returns></returns>
		private string GetApplicationPath()
		{
			string sPath = Application.StartupPath;
			if (sPath.EndsWith("Debug")) 
			{
				sPath = sPath.Substring(0, sPath.Length-6);
			} 
			else if (sPath.EndsWith("Release"))
			{
				sPath = sPath.Substring(0, sPath.Length - 8);
			}
			if (sPath.EndsWith("bin")) 
			{
				sPath = sPath.Substring(0, sPath.Length-4);
			}
			return sPath;
		}

		/// <summary>
		/// Help->Documentation menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemDocument_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process.Start("IExplore.exe", GetApplicationPath() + "\\help.htm");
		}

		/// <summary>
		/// Help->BinX schema menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemSchema_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process.Start("IExplore.exe", GetApplicationPath() + "\\binx.xsd");		
		}

		/// <summary>
		/// Utility->Validate menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemValidate_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK) 
			{
				Cursor.Current = Cursors.WaitCursor;
				Validator.Validate(GetApplicationPath()+"\\binx.xsd", openFileDialog1.FileName);
				Cursor.Current = Cursors.Default;
			}
		}

		/// <summary>
		/// Utility->View in browser
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemBrowse_Click(object sender, System.EventArgs e)
		{
			if (controller_.isDocumentEmpty())
			{
				MessageBox.Show(this, "Document is empty");
				return;
			}
			if (controller_.isDocumentModified()) 
			{
				menuItemSave_Click(sender, e);	//save the document first
			}
			System.Diagnostics.Process.Start("IExplore.exe", controller_.getDocumentFilePath());
		}

		/// <summary>
		/// Set related menu items visible according to strings in the array list.
		/// </summary>
		/// <remarks>If items contains 'any' then all data types apply, else only 'define','dim', and 'case' nodes are supported.</remarks>
		/// <param name="baseMenu"></param>
		/// <param name="items"></param>
		private void showMenuItemsToAdd(MenuItem baseMenu, ref ArrayList items)
		{
//			defineMode_ = false;
			baseMenu.Enabled = true;
			if (items[0].Equals("any")) 
			{
				for (int i=0; i<5; i++) 
				{
					baseMenu.MenuItems[i].Visible = true;
				}
				baseMenu.MenuItems[5].Visible = false;
				if (baseMenu.MenuItems.Count > 6)
					baseMenu.MenuItems[6].Visible = false;
			} 
			else if (items[0].Equals("define"))
			{
//				defineMode_ = true;
				baseMenu.MenuItems[0].Visible = baseMenu.MenuItems[1].Visible = false;
				for (int i=2; i<5; i++) 
				{
					baseMenu.MenuItems[i].Visible = true;
				}
				baseMenu.MenuItems[5].Visible = false;
				if (baseMenu.MenuItems.Count > 6)
					baseMenu.MenuItems[6].Visible = false;
			}
			else if (items[0].Equals("dim"))
			{
				for (int i=0; i<6; i++)
					baseMenu.MenuItems[i].Visible = false;
				baseMenu.MenuItems[6].Visible = true;
			}
			else if (items[0].Equals("case"))
			{
				for (int i=0; i<baseMenu.MenuItems.Count; i++)
					baseMenu.MenuItems[i].Visible = false;
				baseMenu.MenuItems[5].Visible = true;
			}
		}

		/// <summary>
		/// Test whether the given node is an element of an array node.
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		private bool isArrayElement(DataNode node)
		{
			if (!node.Parent.Equals(treeView1.TopNode)) 
			{
				AbstractNode parent = ((DataNode)node.Parent).getDataNode();
				if (parent.GetType().Equals(typeof(ArrayNode))) 
				{
					return true;
				} 
				else if (parent.GetType().Equals(typeof(DefineTypeNode))) 
				{
					if (((DefineTypeNode)parent).getBaseType().GetType().Equals(typeof(ArrayNode))) 
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Test whether the given node is a case body node of a case node.
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		private bool isCaseBody(DataNode node)
		{
			if (!node.Parent.Equals(treeView1.TopNode))
			{
				AbstractNode parent = ((DataNode)node.Parent).getDataNode();
				if (parent.GetType().Equals(typeof(CaseNode)))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// After a node is selected (left click on it), update the menu items.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Node.Equals(treeView1.TopNode)) 
			{
				menuItemAddBefore.Enabled = false;
				menuItemAddAfter.Enabled = false;
				menuItemAddChild.Enabled = false;
				menuItemDelete.Enabled = toolBarButtonDelete.Enabled = false;
				listView1.Items.Clear();
			} 
			else 
			{
				DataNode dn = (DataNode)e.Node;
				menuItemDelete.Enabled = toolBarButtonDelete.Enabled = dn.canDelete();
				ArrayList siblings = dn.validSiblingTypes();
				if (siblings != null && siblings.Count > 0 && !isArrayElement(dn) && !isCaseBody(dn)) 
				{
					showMenuItemsToAdd(menuItemAddBefore, ref siblings);
					showMenuItemsToAdd(menuItemAddAfter, ref siblings);
				} 
				else 
				{
					menuItemAddBefore.Enabled = false;
					menuItemAddAfter.Enabled = false;
				}
				ArrayList children = dn.validChildTypes();
				if (children != null && children.Count > 0)
				{
					showMenuItemsToAdd(menuItemAddChild, ref children);
				} 
				else 
				{
					menuItemAddChild.Enabled = false;
				}
				listView1.setProperties(dn.getProperties());
			}
		}

		private void menuItemPrimitiveBefore_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			DataNode parent = (DataNode)node.Parent;
			controller_.addPrimitiveNode(parent, parent.Nodes.IndexOf(node));
		}

		private void menuItemPrimitiveAfter_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			DataNode parent = (DataNode)node.Parent;
			controller_.addPrimitiveNode(parent, parent.Nodes.IndexOf(node)+1);
		}

		private void menuItemPrimitiveChild_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			controller_.addPrimitiveNode(node, node.Nodes.Count);
			node.Expand();
		}

		private void menuItemDefinedBefore_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			DataNode parent = (DataNode)node.Parent;
			controller_.addUseTypeNode(parent, parent.Nodes.IndexOf(node));
		}

		private void menuItemDefinedAfter_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			DataNode parent = (DataNode)node.Parent;
			controller_.addUseTypeNode(parent, parent.Nodes.IndexOf(node)+1);
		}

		private void menuItemDefinedChild_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			controller_.addUseTypeNode(node, node.Nodes.Count);
			node.Expand();
		}

		private void menuItemStructBefore_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			DataNode parent = (DataNode)node.Parent;
			controller_.addStructTypeNode(parent, parent.Nodes.IndexOf(node), parent.Equals(treeView1.TopNode.Nodes[0]));
		}

		private void menuItemStructAfter_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			DataNode parent = (DataNode)node.Parent;
			controller_.addStructTypeNode(parent, parent.Nodes.IndexOf(node)+1, parent.Equals(treeView1.TopNode.Nodes[0]));
		}

		private void menuItemStructChild_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			controller_.addStructTypeNode(node, node.Nodes.Count, node.Equals(treeView1.TopNode.Nodes[0]));
		}

		private void menuItemUnionBefore_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			DataNode parent = (DataNode)node.Parent;
			controller_.addUnionTypeNode(parent, parent.Nodes.IndexOf(node), parent.Equals(treeView1.TopNode.Nodes[0]));
		}

		private void menuItemUnionAfter_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			DataNode parent = (DataNode)node.Parent;
			controller_.addUnionTypeNode(parent, parent.Nodes.IndexOf(node)+1, parent.Equals(treeView1.TopNode.Nodes[0]));
		}

		private void menuItemUnionChild_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			controller_.addUnionTypeNode(node, node.Nodes.Count, node.Equals(treeView1.TopNode.Nodes[0]));
		}

		private void menuItemArrayBefore_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			DataNode parent = (DataNode)node.Parent;
			controller_.addArrayTypeNode(parent, parent.Nodes.IndexOf(node), parent.Equals(treeView1.TopNode.Nodes[0]));
		}

		private void menuItemArrayAfter_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			DataNode parent = (DataNode)node.Parent;
			controller_.addArrayTypeNode(parent, parent.Nodes.IndexOf(node)+1, parent.Equals(treeView1.TopNode.Nodes[0]));
		}

		private void menuItemArrayChild_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			controller_.addArrayTypeNode(node, node.Nodes.Count, node.Equals(treeView1.TopNode.Nodes[0]));
		}

		private void menuItemCaseBefore_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			DataNode parent = (DataNode)node.Parent;
			controller_.addCaseNode(parent, parent.Nodes.IndexOf(node));
		}

		private void menuItemCaseAfter_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			DataNode parent = (DataNode)node.Parent;
			controller_.addCaseNode(parent, parent.Nodes.IndexOf(node)+1);
		}

		private void menuItemCaseChild_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			controller_.addCaseNode(node, node.Nodes.Count);
		}

		private void menuItemDimChild_Click(object sender, System.EventArgs e)
		{
			DataNode node = (DataNode)GetActiveNode();
			controller_.addDimNode(node, node.Nodes.Count);
		}

		/// <summary>
		/// Make the tree view font larger until 18pt.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemFontPlus_Click(object sender, System.EventArgs e)
		{
			if (treeView1.Font.Size < 18.0)
			{
				treeView1.Font = new Font(treeView1.Font.Name, treeView1.Font.Size + 1.0f);
			}
		}

		/// <summary>
		/// Make the tree view font smaller until 9pt.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemFontMinus_Click(object sender, System.EventArgs e)
		{
			if (treeView1.Font.Size > 9.0)
			{
				treeView1.Font = new Font(treeView1.Font.FontFamily, treeView1.Font.Size - 1.0f);
			}
		}

		/// <summary>
		/// Import only the definitions from an external BinX document, and the duplicated types are ignored.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemImport_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK) 
			{
				Cursor.Current = Cursors.WaitCursor;
				controller_.importDefinitions(openFileDialog1.FileName);
				treeView1.BeginUpdate();
				controller_.populateDataTree(treeView1.TopNode);
				treeView1.EndUpdate();
				Cursor.Current = Cursors.Default;
			}
		}

		/// <summary>
		/// Catch this event to adjust the property columns after the property view size is changed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listView1_Resize(object sender, System.EventArgs e)
		{
			listView1.ResizeView(listView1.Size);
		}

		/// <summary>
		/// Called by PropertyView when update of properties occurs.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="propertyValue"></param>
		private void listView1_PropertyUpdateHandler(string propertyName, string propertyValue)
		{
			Console.WriteLine(":" + propertyName + "," + propertyValue);
			DataNode node = (DataNode)treeView1.SelectedNode;
			if (node != null) 
			{
				node.setProperty(propertyName, propertyValue);
				node.updateText();
				if (propertyName.Equals("Array Type"))
				{
					((DataNode)node.LastNode).updateText();
				}
			}
		}

		/// <summary>
		/// Catch this event to make sure the right-hand pane (property view) size remain the same after resizing the main window.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Resize(object sender, System.EventArgs e)
		{
			splitter1.SplitPosition = this.Width - RightPaneWidth_;
		}

		/// <summary>
		/// Catch this event to remember the new property view size after split bar is moved.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void splitter1_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
		{
			RightPaneWidth_ = this.Width - splitter1.SplitPosition;
		}

	}
}
