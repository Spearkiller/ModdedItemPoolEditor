using System.Reflection;
using System.Xml;
using static System.Windows.Forms.ListView;

namespace ModdedItemPoolEditor
{
    public partial class Form1 : Form
    {
        private string gfxroot = "";
        private List<ListViewItem> MasterItemsList = new List<ListViewItem>();
        private List<KeyValuePair<string, List<ListViewItem>>> Pools = new List<KeyValuePair<string, List<ListViewItem>>>();
        private int bookmarkSelectionIndex = -1;


        public Form1()
        {
            InitializeComponent();
            RegisterPools();
            itemPoolSelection.SelectedIndex = 0;
            weightChanger.ResetText();
            decreaseChanger.ResetText();
            removeChanger.ResetText();
        }

        public void RenderList(List<ListViewItem> thisList, ListView view)
        {
            view.Items.Clear();
            foreach (ListViewItem item in thisList)
            {
                view.Items.Add(item);
            }
            if (view.Equals(itemView))
            {
                updateSearchCountDisplay(thisList.Count);
            }
            if (view.Equals(poolView))
            {
                updateSelectCountDisplay();
            }
        }

        private void updateSearchCountDisplay(int count)
        {
            searchCounter.Text = $"Showing {count} of {MasterItemsList.Count} items";
        }

        private void updateSelectCountDisplay()
        {
            selectedCountLabel.Text = $"Selected {poolView.SelectedItems.Count} of {poolView.Items.Count} items";
        }

        //TODO: Some sort of logging system? If the player hits delete, they may not be able to undo but they can see what they did to remind themselves and fix it.

        //TODO
        //The lazy way: just set a flag every time the user either loads an xml, or puts something into a pool.
        //The good way: compare current itempools to loaded itempools.xml. If no xml is loaded, check if map is empty.
        public bool unsavedChanges()
        {
            return false;
        }

        //The method used when clicking an item in the item pane.
        public void addItemToPool(ListViewItem i)
        {
            if (itemPoolSelection.SelectedIndex >= 0)
            {
                ListViewItem item = new ListViewItem(i.Name);
                item.Name = i.Name;
                item.SubItems.Add("1");
                item.SubItems.Add("1");
                item.SubItems.Add("0.1");
                item.ImageKey = i.ImageKey;
                if (item.ForeColor != null) { item.ForeColor = i.ForeColor; }
                Pools[itemPoolSelection.SelectedIndex].Value.Add(item);
                RenderList(Pools[itemPoolSelection.SelectedIndex].Value, poolView);
            }
            else
            {
                MessageBox.Show("Please select a valid pool!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void removeItemsFromPool(List<ListViewItem> items)
        {
            if (itemPoolSelection.SelectedIndex >= 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Pools[itemPoolSelection.SelectedIndex].Value.Remove(items[i]);
                }
                RenderList(Pools[itemPoolSelection.SelectedIndex].Value, poolView);
            }
            else
            {
                MessageBox.Show("Please select a valid pool!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Keeping this here incase its needed!
        public void addItemToPool(ListViewItem item, int poolID)
        {
            /*foreach (KeyValuePair<String, List<ListViewItem>> kvp in Pools)
            {
                if (poolName.Equals(kvp.Key))
                {
                    kvp.Value.Add(item);
                    return;
                }
            }*/
            Pools[poolID].Value.Add(item);
        }

        //Should be used only by the pool loader!
        /*public void addItemToPool(ListViewItem item, string poolName)
        {
            foreach (KeyValuePair<String, List<ListViewItem>> kvp in Pools)
            {
                if (poolName.Equals(kvp.Key))
                {
                    kvp.Value.Add(item);
                    return;
                }
            }
        }*/

        public int getPoolIDByName(string poolName)
        {
            foreach (KeyValuePair<String, List<ListViewItem>> kvp in Pools)
            {
                if (poolName.Equals(kvp.Key))
                {
                    return Pools.IndexOf(kvp);
                }
            }
            return -1;
        }

        public ListViewItem getItemByName(string name)
        {
            foreach (ListViewItem i in MasterItemsList)
            {
                if (i.Name.Equals(name))
                {
                    //print(i.Name);
                    return i;
                }
            }
            return null;
        }

        /*public void printItemPools()
        {
            foreach (var pool in Pools)
            {
                print(pool.Key);
                foreach (var item in pool.Value)
                {
                    print("\t" + item.ToString());
                }
            }
        }*/

        public String poolToString()
        {
            string output = "";

            foreach (var pool in Pools)
            {
                output += pool.Key;
                foreach (var item in pool.Value)
                {
                    output += "\t" + item.ToString();
                }
            }

            return output;
        }

        //-----------------------------------------------------------------
        //                       UI Action Events
        //-----------------------------------------------------------------

        //File - Click Load Items.xml
        private void ClickLoadItems(object sender, EventArgs e)
        {
            if (openItemsXMLDialogue.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MasterItemsList = new List<ListViewItem>();

                    XmlDocument itemsXml = new XmlDocument();
                    string fileName = openItemsXMLDialogue.FileName;
                    itemsXml.Load(fileName);
                    gfxroot = fileName.Replace("content\\items.xml", "resources\\");
                    XmlNode rootNode = itemsXml.DocumentElement;
                    if (rootNode == null)
                    {
                        MessageBox.Show("No root node found in items.xml.\nEnsure the selected xml file begins with '<items>'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    char[] root = rootNode.Attributes["gfxroot"].Value.ToCharArray();
                    for (int c = 0; c < root.Length; c++) //oh aye
                    { if (root[c] == '/') { root[c] = '\\'; } }

                    gfxroot += string.Join("", root) + "collectibles\\";
                    //gfxroot now points to the folder item sprites are stored in for this mod. Yippee!
                    int count = 0;
                    //print(rootNode.ChildNodes.Count);

                    //For each item
                    foreach (XmlNode itemNode in rootNode.ChildNodes)
                    {
                        if (itemNode.NodeType.Equals(XmlNodeType.Comment))
                        {
                            continue;
                        }
                        //TODO: make this case-insensitive.
                        if (itemNode.Name.ToLower().Equals("passive")
                            || itemNode.Name.ToLower().Equals("active")
                            || itemNode.Name.ToLower().Equals("familiar"))
                        {
                            bool hiddenItem = false;
                            //handle errors
                            if (itemNode.Attributes["hidden"] != null &&
                                itemNode.Attributes["hidden"].Value.Equals("true"))
                            {
                                hiddenItem = true;
                            }
                            if (itemNode.Attributes["name"] == null) { continue; }

                            ListViewItem item = new ListViewItem(itemNode.Attributes["name"].Value);
                            item.Name = itemNode.Attributes["name"].Value;
                            item.ImageKey = itemNode.Attributes["gfx"].Value;

                            if (hiddenItem) { item.ForeColor = Color.Red; }
                            //item.ToolTipText = itemNode.Attributes["name"].Value;

                            MasterItemsList.Add(item);
                            count++;
                        }
                    }

                    MessageBox.Show($"Successfully loaded {count} items!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Load images into memory
                    itemSpriteList.Images.Clear();
                    for (int i = 0; i < MasterItemsList.Count - 1; i++)
                    {
                        string spriteName = null;
                        string filepath = null;

                        if (MasterItemsList[i].ImageKey != null) {
                            spriteName = MasterItemsList[i].ImageKey;
                            filepath = gfxroot + spriteName;
                        }
                        //print(filepath);
                        Image icon = null;
                        if (File.Exists(filepath))
                        {
                            //print("Found image: " + filepath);
                            icon = Image.FromFile(filepath);
                        }
                        else
                        {
                            //print("Could not find image for " + MasterItemsList[i].Name);
                            icon = Properties.Resources.questionmark;
                        }
                        itemSpriteList.Images.Add(spriteName, icon);
                    }
                    RenderList(MasterItemsList, itemView);

                    //TODO: If a mod has a .txt file called 'custompools.txt' in the main directory, read the file and add its pools to the pool list.

                    if (Properties.Settings.Default.AutoLoadPools)
                    {
                        string poolFile = fileName.Replace("items.xml", "itempools.xml");
                        try
                        {
                            bookmarkSelectionIndex = itemPoolSelection.SelectedIndex;
                            loadItemPoolFromXml(poolFile);
                        }
                        catch
                        {
                            MessageBox.Show($"Could not autoload pools from {poolFile}!\nYou will need to manually load your itempools.xml.\nThis may occur when loading xmls from non-standard directories, or when using non-standard xml file names.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occured while reading the file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    print(ex.StackTrace);
                    return;
                }
            }
        }

        //File - Click Load Itempools.xml
        private void ClickLoadItemPools(object sender, EventArgs e)
        {
            bookmarkSelectionIndex = itemPoolSelection.SelectedIndex;
            if (openPoolsXMLDialogue.ShowDialog() == DialogResult.OK)
            {
                if (MasterItemsList.Count == 0)
                {
                    MessageBox.Show("Please import an items.xml file first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    RegisterPools();
                    //TODO: Move everything from here to a seperate method, allowing itempool loading to be done without a dialogue popup, provided we know where the itempools.xml is located.
                    //This means we can automatically load pools when the user opens items.xml.
                    loadItemPoolFromXml(openPoolsXMLDialogue.FileName);
                    print(poolToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occured while reading the file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    print(ex.StackTrace);
                    return;
                }
            }
        }

        //TODO: Make bookmarkSelectionIndex not needed to be passed in as a parameter.
        private void loadItemPoolFromXml(string fileName)
        {

            XmlDocument poolsXML = new XmlDocument();
            poolsXML.Load(fileName);
            XmlNode rootNode = poolsXML.DocumentElement;
            if (rootNode == null)
            {
                MessageBox.Show("No root node found in itempoolss.xml.\nEnsure the selected xml file begins with '<ItemPools>'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //print(rootNode.ChildNodes.Count);

            //For each pool
            foreach (XmlNode poolNode in rootNode.ChildNodes)
            {

                //XmlNode poolNode = rootNode.SelectNodes(pool.Key)[0];
                if (poolNode == null) { continue; }
                if (poolNode.NodeType.Equals(XmlNodeType.Comment))
                { continue; }

                //We do it this way so that we can load pools even if theyre out of order
                int currentPool = getPoolIDByName(poolNode.Attributes["Name"].Value);
                //itemPoolSelection.Items.Add(currentPool);

                int count = 0;
                //For each item in the pool
                foreach (XmlNode itemNode in poolNode.ChildNodes)
                {
                    if (itemNode.NodeType.Equals(XmlNodeType.Comment))
                    { continue; }

                    //TODO: make this case-insensitive.
                    ListViewItem item = new ListViewItem(itemNode.Attributes["Name"].Value);
                    item.Name = itemNode.Attributes["Name"].Value;
                    item.SubItems.Add(itemNode.Attributes["Weight"].Value);
                    item.SubItems.Add(itemNode.Attributes["DecreaseBy"].Value);
                    item.SubItems.Add(itemNode.Attributes["RemoveOn"].Value);

                    ListViewItem masterCopy = getItemByName(item.Name);
                    if (masterCopy == null)
                    {
                        print($"Found {item.Name} in pool, but item does not exist in items.xml, or is hidden!");
                        continue;
                    }
                    item.ImageKey = getItemByName(item.Name).ImageKey;
                    if (getItemByName(item.Name).ForeColor != null) { item.ForeColor = getItemByName(item.Name).ForeColor; }

                    addItemToPool(item, currentPool);
                    count++;
                }
                //print(poolNode.ChildNodes.Count);
            }

            MessageBox.Show("Successfully loaded itempools!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //printItemPools();
            //MessageBox.Show($"{bookmarkSelectionIndex}");
            itemPoolSelection.SelectedIndex = bookmarkSelectionIndex;
            RenderList(Pools[itemPoolSelection.SelectedIndex].Value, poolView);
        }

        //File - Click Save Itempools.xml
        private void ClickSaveItemPools(object sender, EventArgs e)
        {
            if (savePoolsXMLDialogue.ShowDialog() == DialogResult.OK)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "\t";
                using (XmlWriter writer = XmlWriter.Create(savePoolsXMLDialogue.FileName, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("ItemPools");

                    foreach (KeyValuePair<String, List<ListViewItem>> s in Pools)
                    {
                        writer.WriteStartElement("Pool");
                        writer.WriteAttributeString("Name", s.Key);
                        foreach (ListViewItem item in s.Value)
                        {
                            writer.WriteStartElement("Item");
                            writer.WriteAttributeString("Name", item.Name);
                            writer.WriteAttributeString("Weight", item.SubItems[1].Text);
                            writer.WriteAttributeString("DecreaseBy", item.SubItems[2].Text);
                            writer.WriteAttributeString("RemoveOn", item.SubItems[3].Text);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                MessageBox.Show("File Saved!", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //File - New Itempools
        private void ClickNewItemPools(object sender, EventArgs e)
        {

        }

        //Options - Show Item Names in Master View
        private void ToggleShowItemNamesMaster(object sender, EventArgs e)
        {
            Properties.Settings.Default.ListItemNames = showNamesInItemViewToggle.Checked;
            Properties.Settings.Default.Save();
        }

        //Options - Show Item Names in Pool View
        private void ToggleShowItemNamesPool(object sender, EventArgs e)
        {
            Properties.Settings.Default.PoolItemNames = showNamesInPoolViewToggle.Checked;
            Properties.Settings.Default.Save();
        }

        //Options - Automatically load Itempools.xml from same dir. as Items.xml
        private void ClickAutoLoadPoolsToggle(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoLoadPools = autoLoadPoolsToggle.Checked;
            Properties.Settings.Default.Save();
        }

        //Options - Change Item Icon size/setting
        private void UpdateItemIconSize(object sender, EventArgs e)
        {
            Properties.Settings.Default.IconSize = iconSizeToolStripMenuItem.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        //Options - Load hidden items when loading items.xml
        private void ToggleAutoItemLoads(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowHiddenItems = showNamesInItemViewToggle.Checked;
            Properties.Settings.Default.Save();
        }

        //Options - Remove items from the item list if theyre in pools
        private void ToggleShowItemListDuplicates(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowDuplicates = showNamesInItemViewToggle.Checked;
            Properties.Settings.Default.Save();
        }

        //Options - Allow duplicate items to be added to pools
        private void ToggleAllowDuplicatesInPools(object sender, EventArgs e)
        {
            Properties.Settings.Default.AllowDuplicates = showNamesInItemViewToggle.Checked;
            Properties.Settings.Default.Save();
        }

        //Help - How To
        private void ClickHowTo(object sender, EventArgs e)
        {
            MessageBox.Show("Start by importing an items.xml file from a mod of your choice." +
                "\nThen, load that mod's respective itempools.xml file." +
                "\nClick items in the left panel to add them to the selected itempool." +
                "\n" +
                "\nNOTE: This tool can ONLY read items.xml files that are properly situated in their mod's files (I.E. in the 'content' folder that the game will read from.)" +
                "\nAny improperly formatted entries in either items.xml or itempools.xml will be skipped over, so make sure xmls are properly formatted and up-to-date with a mod's content. If they are not, consider fixing them, or contacting the mod author.", "How to use", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Help - About
        private void ClickAbout(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Spearkiller\nSpecial thanks to Wofsauge for creating 'Itempool Editor+' and giving permission to update it.\n \nThank you for using this tool! You're very cool!\nIf you encounter any bugs, please post them on the github link.\n \nCopyright 2023 lololol", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Select itempool
        private void OnItemPoolChange(object sender, EventArgs e)
        {
            RenderList(Pools[itemPoolSelection.SelectedIndex].Value, poolView);
        }

        //Search
        private void OnSearchUpdate(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                RenderList(MasterItemsList, itemView);
            }
            else
            {
                List<ListViewItem> searchList = new List<ListViewItem>();
                foreach (ListViewItem item in MasterItemsList)
                {
                    if (item.Name.ToLower().Contains(searchBox.Text.ToLower()))
                    {
                        searchList.Add(item);
                    }
                }
                RenderList(searchList, itemView);
                if (searchList.Count == 0)
                {
                    Console.WriteLine("Bepsi");
                    MessageBox.Show("No items were found that match the search.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //itemView -- Can only select one item at a time
        private void SelectedItemUpdate(object sender, EventArgs e)
        {
            if (itemView.SelectedItems.Count > 0)
            {
                ListViewItem item = getItemByName(itemView.SelectedItems[0].Name);
                addItemToPool(item);
            }
        }

        //poolView -- selects multiple items
        private void SelectedItemsUpdate(object sender, EventArgs e)
        {
            //Update the three item counter things.
            updateSelectCountDisplay();
            if (poolView.SelectedItems.Count > 1)
            {
                bool read1 = true;
                bool read2 = true;
                bool read3 = true;

                for (int i = 0; i < poolView.SelectedItems.Count; i++)
                {
                    print(poolView.SelectedItems[i].ToString() + " || " + i);
                    if (read1 && !readField(read1, 1, i, weightChanger)) read1 = false;
                    if (read2 && !readField(read2, 2, i, decreaseChanger)) read2 = false;
                    if (read3 && !readField(read3, 3, i, removeChanger)) read3 = false;
                }
            }
            else if (poolView.SelectedItems.Count == 1) //Only one item selected
            {
                weightChanger.Text = poolView.SelectedItems[0].SubItems[1].Text;
                decreaseChanger.Text = poolView.SelectedItems[0].SubItems[2].Text;
                removeChanger.Text = poolView.SelectedItems[0].SubItems[3].Text;
            }
            else //No items selected
            {
                weightChanger.ResetText();
                decreaseChanger.ResetText();
                removeChanger.ResetText();
            }
        }

        private bool readField(bool read, int field, int index, NumericUpDown box)
        {
            //print(poolView.SelectedItems[index].ToString());
            //If item's value doesnt match the first element in the list.
            if (read && (poolView.SelectedItems[index].SubItems[field] != poolView.SelectedItems[0].SubItems[field])) //Weight
            {
                box.ResetText();
                return false;
            }
            else
            {
                box.Text = poolView.SelectedItems[index].SubItems[field].Text;
                return true;
            }
        }

        //Weight
        private void OnWeightUpdate(object sender, EventArgs e)
        {
            updateAllSubItems(1, weightChanger.Value.ToString());
        }

        //Decrease By
        private void OnDecreaseUpdate(object sender, EventArgs e)
        {
            updateAllSubItems(2, decreaseChanger.Value.ToString());
        }

        //Remove On
        private void OnRemoveUpdate(object sender, EventArgs e)
        {
            updateAllSubItems(3, removeChanger.Value.ToString());
        }

        private void updateAllSubItems(int subItem, string value)
        {
            foreach (ListViewItem i in poolView.SelectedItems)
            {
                i.SubItems[subItem].Text = value;
            }
        }

        //Add Random Item
        private void ClickRandomItem(object sender, EventArgs e)
        {
            if (MasterItemsList.Count == 0)
            {
                MessageBox.Show("Please import an items.xml file first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var rand = new Random();
            addItemToPool(MasterItemsList[rand.Next(MasterItemsList.Count)]);
        }

        //Remove Selected Items
        private void ClickRemoveSelected(object sender, EventArgs e)
        {
            if (poolView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show($"Are you sure?\nThis will remove all {poolView.SelectedItems.Count} item(s) from the current pool!", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<ListViewItem> currentList = new List<ListViewItem>();
                    foreach (ListViewItem item in poolView.SelectedItems)
                    {
                        currentList.Add(item);
                    }
                    removeItemsFromPool(currentList);
                }
            }
        }

        //Remove ALL Items
        private void ClickRemoveAll(object sender, EventArgs e)
        {
            if (Pools[itemPoolSelection.SelectedIndex].Value.Count > 0)
            {
                if (MessageBox.Show($"Are you sure?\nThis will remove all {Pools[itemPoolSelection.SelectedIndex].Value.Count} item(s) from the current pool!", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<ListViewItem> currentList = new List<ListViewItem>();
                    foreach (ListViewItem item in Pools[itemPoolSelection.SelectedIndex].Value)
                    {
                        currentList.Add(item);
                    }
                    removeItemsFromPool(currentList);
                }
            }
        }

        private void greedAutoFillButton(object sender, EventArgs e)
        {
            if (itemPoolSelection.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Are you sure?\nClicking 'yes' will overwrite all greed-specific item pools with their non-greed counterparts.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<string> greedPools = new List<string>();
                    List<string> regPools = new List<string>();
                    //First, save all the pool names.
                    foreach (KeyValuePair<string, List<ListViewItem>> kvp in Pools)
                    {
                        if (kvp.Key.StartsWith("greed"))
                        {
                            string greedName = kvp.Key;
                            greedPools.Add(greedName);
                            regPools.Add(greedName.Replace("greed", "").ToLower());
                        }
                    }
                    //For each saved name
                    for (int i = 0; i < regPools.Count; i++)
                    {
                        List<ListViewItem> clonedPool = new List<ListViewItem>();
                        //Copy the regular list into a new list
                        foreach(ListViewItem item in Pools[getPoolIDByName(regPools[i])].Value)
                        {
                            clonedPool.Add(item);
                        }

                        //Update the Pools with the new pool.
                        Pools[getPoolIDByName(greedPools[i])] 
                            = new KeyValuePair<String, List<ListViewItem>>(greedPools[i], clonedPool);
                    }
                    RenderList(Pools[itemPoolSelection.SelectedIndex].Value, poolView);
                }
            }
        }

        private void RegisterPools()
        {
            Pools = new List<KeyValuePair<String, List<ListViewItem>>>();
            itemPoolSelection.Items.Clear();
            string[] poolNames = new string[] {
                "treasure",
                "shop",
                "boss",
                "devil",
                "angel",
                "secret",
                "library",
                "shellGame",
                "goldenChest",
                "redChest",
                "beggar",
                "demonBeggar",
                "curse",
                "keyMaster",
                "batteryBum",
                "momsChest",
                "greedTreasure",
                "greedBoss",
                "greedShop",
                "greedCurse",
                "greedDevil",
                "greedAngel",
                "greedSecret",
                "craneGame",
                "ultraSecret",
                "bombBum",
                "planetarium",
                "oldChest",
                "babyShop",
                "woodenChest",
                "rottenBeggar"
            };

            foreach (string name in poolNames)
            {
                Pools.Add(new KeyValuePair<String, List<ListViewItem>>(name, new List<ListViewItem>()));
                itemPoolSelection.Items.Add(name);
            }
        }

        private void print(string s)
        {
            System.Diagnostics.Debug.WriteLine(s);
        }
    }
}