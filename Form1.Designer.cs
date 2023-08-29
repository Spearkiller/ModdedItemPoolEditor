namespace ModdedItemPoolEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importItemsxmlToolStripMenuItem = new ToolStripMenuItem();
            loadItempoolsxmlToolStripMenuItem = new ToolStripMenuItem();
            saveItempoolsxmlToolStripMenuItem = new ToolStripMenuItem();
            newItempoolsxmlToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            showNamesInItemViewToggle = new ToolStripMenuItem();
            showNamesInPoolViewToggle = new ToolStripMenuItem();
            autoLoadPoolsToggle = new ToolStripMenuItem();
            iconSizeToolStripMenuItem = new ToolStripComboBox();
            showHiddenItemsToolStripMenuItem = new ToolStripMenuItem();
            showItemsAlreadyInPoolToolStripMenuItem = new ToolStripMenuItem();
            allowDuplicatesToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem1 = new ToolStripMenuItem();
            howToUseToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            itemView = new ListView();
            itemSpriteList = new ImageList(components);
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            poolView = new ListView();
            label1 = new Label();
            label2 = new Label();
            searchBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            itemPoolSelection = new ComboBox();
            addRandomButton = new Button();
            removeSelectedButton = new Button();
            removeAllButton = new Button();
            selectedCountLabel = new Label();
            openItemsXMLDialogue = new OpenFileDialog();
            savePoolsXMLDialogue = new SaveFileDialog();
            openPoolsXMLDialogue = new OpenFileDialog();
            greedPoolAutoFillButton = new Button();
            weightChanger = new NumericUpDown();
            decreaseChanger = new NumericUpDown();
            removeChanger = new NumericUpDown();
            searchCounter = new Label();
            removeDuplicates = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)weightChanger).BeginInit();
            ((System.ComponentModel.ISupportInitialize)decreaseChanger).BeginInit();
            ((System.ComponentModel.ISupportInitialize)removeChanger).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.InactiveBorder;
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem, helpToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importItemsxmlToolStripMenuItem, loadItempoolsxmlToolStripMenuItem, saveItempoolsxmlToolStripMenuItem, newItempoolsxmlToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // importItemsxmlToolStripMenuItem
            // 
            importItemsxmlToolStripMenuItem.Name = "importItemsxmlToolStripMenuItem";
            importItemsxmlToolStripMenuItem.Size = new Size(179, 22);
            importItemsxmlToolStripMenuItem.Text = "Import items.xml";
            importItemsxmlToolStripMenuItem.Click += ClickLoadItems;
            // 
            // loadItempoolsxmlToolStripMenuItem
            // 
            loadItempoolsxmlToolStripMenuItem.Name = "loadItempoolsxmlToolStripMenuItem";
            loadItempoolsxmlToolStripMenuItem.Size = new Size(179, 22);
            loadItempoolsxmlToolStripMenuItem.Text = "Load itempools.xml";
            loadItempoolsxmlToolStripMenuItem.Click += ClickLoadItemPools;
            // 
            // saveItempoolsxmlToolStripMenuItem
            // 
            saveItempoolsxmlToolStripMenuItem.Name = "saveItempoolsxmlToolStripMenuItem";
            saveItempoolsxmlToolStripMenuItem.Size = new Size(179, 22);
            saveItempoolsxmlToolStripMenuItem.Text = "Save itempools.xml";
            saveItempoolsxmlToolStripMenuItem.Click += ClickSaveItemPools;
            // 
            // newItempoolsxmlToolStripMenuItem
            // 
            newItempoolsxmlToolStripMenuItem.Name = "newItempoolsxmlToolStripMenuItem";
            newItempoolsxmlToolStripMenuItem.Size = new Size(179, 22);
            newItempoolsxmlToolStripMenuItem.Text = "New itempools.xml";
            newItempoolsxmlToolStripMenuItem.Click += ClickNewItemPools;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showNamesInItemViewToggle, showNamesInPoolViewToggle, autoLoadPoolsToggle, iconSizeToolStripMenuItem, showHiddenItemsToolStripMenuItem, showItemsAlreadyInPoolToolStripMenuItem, allowDuplicatesToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(61, 20);
            helpToolStripMenuItem.Text = "Options";
            // 
            // showNamesInItemViewToggle
            // 
            showNamesInItemViewToggle.Checked = true;
            showNamesInItemViewToggle.CheckOnClick = true;
            showNamesInItemViewToggle.CheckState = CheckState.Checked;
            showNamesInItemViewToggle.Name = "showNamesInItemViewToggle";
            showNamesInItemViewToggle.Size = new Size(273, 22);
            showNamesInItemViewToggle.Text = "Show item names in list";
            showNamesInItemViewToggle.Click += ToggleShowItemNamesMaster;
            // 
            // showNamesInPoolViewToggle
            // 
            showNamesInPoolViewToggle.Checked = true;
            showNamesInPoolViewToggle.CheckOnClick = true;
            showNamesInPoolViewToggle.CheckState = CheckState.Checked;
            showNamesInPoolViewToggle.Name = "showNamesInPoolViewToggle";
            showNamesInPoolViewToggle.Size = new Size(273, 22);
            showNamesInPoolViewToggle.Text = "Show item names in pools";
            showNamesInPoolViewToggle.Click += ToggleShowItemNamesPool;
            // 
            // autoLoadPoolsToggle
            // 
            autoLoadPoolsToggle.Checked = true;
            autoLoadPoolsToggle.CheckOnClick = true;
            autoLoadPoolsToggle.CheckState = CheckState.Checked;
            autoLoadPoolsToggle.Name = "autoLoadPoolsToggle";
            autoLoadPoolsToggle.Size = new Size(273, 22);
            autoLoadPoolsToggle.Text = "Auto-load itempools";
            autoLoadPoolsToggle.Click += ClickAutoLoadPoolsToggle;
            // 
            // iconSizeToolStripMenuItem
            // 
            iconSizeToolStripMenuItem.Items.AddRange(new object[] { "Small", "Large", "List", "Tiles" });
            iconSizeToolStripMenuItem.Name = "iconSizeToolStripMenuItem";
            iconSizeToolStripMenuItem.Size = new Size(213, 23);
            iconSizeToolStripMenuItem.Text = "Icon Display Style";
            iconSizeToolStripMenuItem.Click += UpdateItemIconSize;
            // 
            // showHiddenItemsToolStripMenuItem
            // 
            showHiddenItemsToolStripMenuItem.Name = "showHiddenItemsToolStripMenuItem";
            showHiddenItemsToolStripMenuItem.Size = new Size(273, 22);
            showHiddenItemsToolStripMenuItem.Text = "Show hidden items";
            showHiddenItemsToolStripMenuItem.Click += ToggleAutoItemLoads;
            // 
            // showItemsAlreadyInPoolToolStripMenuItem
            // 
            showItemsAlreadyInPoolToolStripMenuItem.Name = "showItemsAlreadyInPoolToolStripMenuItem";
            showItemsAlreadyInPoolToolStripMenuItem.Size = new Size(273, 22);
            showItemsAlreadyInPoolToolStripMenuItem.Text = "Show items already in pool";
            showItemsAlreadyInPoolToolStripMenuItem.Click += ToggleShowItemListDuplicates;
            // 
            // allowDuplicatesToolStripMenuItem
            // 
            allowDuplicatesToolStripMenuItem.Name = "allowDuplicatesToolStripMenuItem";
            allowDuplicatesToolStripMenuItem.Size = new Size(273, 22);
            allowDuplicatesToolStripMenuItem.Text = "Allow duplicates";
            allowDuplicatesToolStripMenuItem.Click += ToggleAllowDuplicatesInPools;
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { howToUseToolStripMenuItem, aboutToolStripMenuItem });
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new Size(44, 20);
            helpToolStripMenuItem1.Text = "Help";
            // 
            // howToUseToolStripMenuItem
            // 
            howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            howToUseToolStripMenuItem.Size = new Size(134, 22);
            howToUseToolStripMenuItem.Text = "How to use";
            howToUseToolStripMenuItem.Click += ClickHowTo;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(134, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += ClickAbout;
            // 
            // itemView
            // 
            itemView.AutoArrange = false;
            itemView.FullRowSelect = true;
            itemView.GridLines = true;
            itemView.LargeImageList = itemSpriteList;
            itemView.Location = new Point(12, 57);
            itemView.MultiSelect = false;
            itemView.Name = "itemView";
            itemView.ShowItemToolTips = true;
            itemView.Size = new Size(450, 464);
            itemView.SmallImageList = itemSpriteList;
            itemView.Sorting = SortOrder.Ascending;
            itemView.TabIndex = 1;
            itemView.TileSize = new Size(200, 36);
            itemView.UseCompatibleStateImageBehavior = false;
            itemView.View = View.List;
            itemView.SelectedIndexChanged += SelectedItemUpdate;
            // 
            // itemSpriteList
            // 
            itemSpriteList.ColorDepth = ColorDepth.Depth32Bit;
            itemSpriteList.ImageSize = new Size(32, 32);
            itemSpriteList.TransparentColor = Color.Transparent;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            columnHeader3.Width = 120;
            // 
            // poolView
            // 
            poolView.AutoArrange = false;
            poolView.FullRowSelect = true;
            poolView.GridLines = true;
            poolView.LargeImageList = itemSpriteList;
            poolView.Location = new Point(522, 57);
            poolView.Name = "poolView";
            poolView.Size = new Size(450, 403);
            poolView.SmallImageList = itemSpriteList;
            poolView.Sorting = SortOrder.Ascending;
            poolView.TabIndex = 2;
            poolView.UseCompatibleStateImageBehavior = false;
            poolView.View = View.List;
            poolView.SelectedIndexChanged += SelectedItemsUpdate;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(89, 19);
            label1.TabIndex = 3;
            label1.Text = "Search items:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(522, 29);
            label2.Name = "label2";
            label2.Size = new Size(124, 19);
            label2.TabIndex = 4;
            label2.Text = "Select an itempool:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(107, 30);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(355, 23);
            searchBox.TabIndex = 5;
            searchBox.TextAlign = HorizontalAlignment.Right;
            searchBox.TextChanged += OnSearchUpdate;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(522, 498);
            label3.Name = "label3";
            label3.Size = new Size(55, 19);
            label3.TabIndex = 6;
            label3.Text = "Weight:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(661, 498);
            label4.Name = "label4";
            label4.Size = new Size(86, 19);
            label4.TabIndex = 7;
            label4.Text = "Decrease by:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(822, 498);
            label5.Name = "label5";
            label5.Size = new Size(81, 19);
            label5.TabIndex = 8;
            label5.Text = "Remove on:";
            // 
            // itemPoolSelection
            // 
            itemPoolSelection.FormattingEnabled = true;
            itemPoolSelection.Location = new Point(652, 30);
            itemPoolSelection.Name = "itemPoolSelection";
            itemPoolSelection.Size = new Size(320, 23);
            itemPoolSelection.TabIndex = 9;
            itemPoolSelection.Text = "Select an itempool...";
            itemPoolSelection.SelectedIndexChanged += OnItemPoolChange;
            // 
            // addRandomButton
            // 
            addRandomButton.Location = new Point(242, 526);
            addRandomButton.Name = "addRandomButton";
            addRandomButton.Size = new Size(220, 23);
            addRandomButton.TabIndex = 15;
            addRandomButton.Text = "Add Random Item";
            addRandomButton.UseVisualStyleBackColor = true;
            addRandomButton.Click += ClickRandomItem;
            // 
            // removeSelectedButton
            // 
            removeSelectedButton.BackColor = Color.FromArgb(255, 128, 128);
            removeSelectedButton.Location = new Point(852, 524);
            removeSelectedButton.Name = "removeSelectedButton";
            removeSelectedButton.Size = new Size(120, 23);
            removeSelectedButton.TabIndex = 16;
            removeSelectedButton.Text = "Remove All Items";
            removeSelectedButton.UseVisualStyleBackColor = false;
            removeSelectedButton.Click += ClickRemoveAll;
            // 
            // removeAllButton
            // 
            removeAllButton.Location = new Point(522, 524);
            removeAllButton.Name = "removeAllButton";
            removeAllButton.Size = new Size(150, 23);
            removeAllButton.TabIndex = 17;
            removeAllButton.Text = "Remove Selected Items";
            removeAllButton.UseVisualStyleBackColor = true;
            removeAllButton.Click += ClickRemoveSelected;
            // 
            // selectedCountLabel
            // 
            selectedCountLabel.AutoSize = true;
            selectedCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            selectedCountLabel.Location = new Point(522, 468);
            selectedCountLabel.Name = "selectedCountLabel";
            selectedCountLabel.Size = new Size(136, 19);
            selectedCountLabel.TabIndex = 18;
            selectedCountLabel.Text = "Selected 0 of 0 items";
            // 
            // openItemsXMLDialogue
            // 
            openItemsXMLDialogue.FileName = "items.xml";
            // 
            // openPoolsXMLDialogue
            // 
            openPoolsXMLDialogue.FileName = "itempools.xml";
            // 
            // greedPoolAutoFillButton
            // 
            greedPoolAutoFillButton.BackColor = Color.Gold;
            greedPoolAutoFillButton.Location = new Point(753, 466);
            greedPoolAutoFillButton.Name = "greedPoolAutoFillButton";
            greedPoolAutoFillButton.Size = new Size(219, 23);
            greedPoolAutoFillButton.TabIndex = 20;
            greedPoolAutoFillButton.Text = "Lazy-fill greed pools";
            greedPoolAutoFillButton.UseVisualStyleBackColor = false;
            greedPoolAutoFillButton.Click += greedAutoFillButton;
            // 
            // weightChanger
            // 
            weightChanger.DecimalPlaces = 2;
            weightChanger.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            weightChanger.Location = new Point(589, 498);
            weightChanger.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            weightChanger.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            weightChanger.Name = "weightChanger";
            weightChanger.Size = new Size(63, 23);
            weightChanger.TabIndex = 21;
            weightChanger.Value = new decimal(new int[] { 10, 0, 0, 65536 });
            weightChanger.ValueChanged += OnWeightUpdate;
            // 
            // decreaseChanger
            // 
            decreaseChanger.DecimalPlaces = 2;
            decreaseChanger.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            decreaseChanger.Location = new Point(749, 498);
            decreaseChanger.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            decreaseChanger.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            decreaseChanger.Name = "decreaseChanger";
            decreaseChanger.Size = new Size(63, 23);
            decreaseChanger.TabIndex = 22;
            decreaseChanger.Value = new decimal(new int[] { 1, 0, 0, 0 });
            decreaseChanger.ValueChanged += OnDecreaseUpdate;
            // 
            // removeChanger
            // 
            removeChanger.DecimalPlaces = 2;
            removeChanger.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            removeChanger.Location = new Point(909, 498);
            removeChanger.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            removeChanger.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            removeChanger.Name = "removeChanger";
            removeChanger.Size = new Size(63, 23);
            removeChanger.TabIndex = 23;
            removeChanger.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            removeChanger.ValueChanged += OnRemoveUpdate;
            // 
            // searchCounter
            // 
            searchCounter.AutoSize = true;
            searchCounter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            searchCounter.Location = new Point(12, 528);
            searchCounter.Name = "searchCounter";
            searchCounter.Size = new Size(138, 19);
            searchCounter.TabIndex = 24;
            searchCounter.Text = "Showing 0 of 0 items";
            // 
            // removeDuplicates
            // 
            removeDuplicates.Location = new Point(678, 524);
            removeDuplicates.Name = "removeDuplicates";
            removeDuplicates.Size = new Size(150, 23);
            removeDuplicates.TabIndex = 25;
            removeDuplicates.Text = "Remove Duplicate Items";
            removeDuplicates.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(984, 561);
            Controls.Add(removeDuplicates);
            Controls.Add(searchCounter);
            Controls.Add(removeChanger);
            Controls.Add(decreaseChanger);
            Controls.Add(weightChanger);
            Controls.Add(greedPoolAutoFillButton);
            Controls.Add(selectedCountLabel);
            Controls.Add(removeAllButton);
            Controls.Add(removeSelectedButton);
            Controls.Add(addRandomButton);
            Controls.Add(itemPoolSelection);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(searchBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(poolView);
            Controls.Add(itemView);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MaximumSize = new Size(1000, 600);
            MinimumSize = new Size(1000, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modded Itempool Editor";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)weightChanger).EndInit();
            ((System.ComponentModel.ISupportInitialize)decreaseChanger).EndInit();
            ((System.ComponentModel.ISupportInitialize)removeChanger).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem importItemsxmlToolStripMenuItem;
        private ToolStripMenuItem loadItempoolsxmlToolStripMenuItem;
        private ToolStripMenuItem saveItempoolsxmlToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ListView itemView;
        private ListView poolView;
        private Label label1;
        private Label label2;
        private TextBox searchBox;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox itemPoolSelection;
        private Button addRandomButton;
        private Button removeSelectedButton;
        private Button removeAllButton;
        private Label selectedCountLabel;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripMenuItem showNamesInItemViewToggle;
        private ToolStripMenuItem showNamesInPoolViewToggle;
        private ToolStripMenuItem howToUseToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private OpenFileDialog openItemsXMLDialogue;
        private SaveFileDialog savePoolsXMLDialogue;
        private ImageList itemSpriteList;
        private OpenFileDialog openPoolsXMLDialogue;
        private ToolStripComboBox iconSizeToolStripMenuItem;
        private ToolStripMenuItem autoLoadPoolsToggle;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button greedPoolAutoFillButton;
        private NumericUpDown weightChanger;
        private NumericUpDown decreaseChanger;
        private NumericUpDown removeChanger;
        private Label searchCounter;
        private ToolStripMenuItem showHiddenItemsToolStripMenuItem;
        private ToolStripMenuItem showItemsAlreadyInPoolToolStripMenuItem;
        private ToolStripMenuItem allowDuplicatesToolStripMenuItem;
        private Button removeDuplicates;
        private ToolStripMenuItem newItempoolsxmlToolStripMenuItem;
    }
}