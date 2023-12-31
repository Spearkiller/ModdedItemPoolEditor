# ModdedItemPoolEditor
 A visual itempool editor for The Binding of Isaac Repentance mods!
 This was mainly created as a means to edit item pools without having to fluff around with .xml files. I've often found myself forgetting whether or not I've added items I've made to pools or not. Sometimes I haven't. Sometimes, I've added duplicates. If there was a way to visualise this, It'd be a heck of a lot easier if I could visualise it, and, so, I knocked out a prototype in a week, sat on my hands for a few months, and decided to publish it on literally the last day of 2023.

 The following features are currently available:
 
 - Reading modded items and itempools.xml
 - Exporting itempools.
 - Adding items to pools.
 - Removing items from pools.
 - Removing only duplicates.
 - Automatic filling of Greed pools.
 - Changing item weights, decrease and removal amounts.

The following features are not available: 
 - Creating an empty itempools.xml
 - Everything in the Options tab (With the exception of auto-loading itempools.xml based off the items.xml)
 - Custom itempool names (But the API doesn't support that either so I don't feel bad!)
 - Different ways of sorting items.

## IMPORTANT NOTES
- This editor does NOT support editing vanilla item pools!
- This editor can only read and write to/from .xmls that are in the appropriate places in mod folders. At best, item sprites may not be read, and at worst, it just won't work. So please keep that in mind.
- This editor will show hidden items from the items.xml; They will be denoted with a red name. These will not appear in game, mind.
- No refunds!

## How to install
- Click 'releases' to the left (or click here: https://github.com/Spearkiller/ModdedItemPoolEditor/releases )
- Click MIPE.zip
- Wait for it to download, and then unzip it.

## How do I use it?
- Run ModdedItemPoolEditor.exe
- Go to File > Import Items.xml
- Navigate to your mod of choice's content folder and click the items.xml
- By default, the editor will now auto-import that mods associated itempools.xml. If not, go to File > Load itempools.xml.
- Click items in the left pane to add them to the selected item pool on the right.
- Change item pools by clicking the dropdown in the top right of the window.
- Select items in the item pool pane on the right to change the weight, decreaseby and removeon values, or to remove them, using the appropriate buttons.
- When finished, go to File > Save itempools.xml and your changes will be exported. You can now use this for your mod!
  
  ## I found a bug!
I'm sure there are plenty. 
I'm not gonna pretend I will be super vigilant with dealing with bugs. I don't know when or if I'll even finish the missing feautures. Either way, just go to 'Issues' up the top and submit a new issue.
