# TAMS 4.1.x

# Version 4.2.0.0
CHANGES
----------------------------------------------------
* Completely redesigned the road analysis tool

# Version 4.1.7.0
CHANGES
----------------------------------------------------
* Added a sheeting information guide for signs
* TAMS projects openned from the project file should open directly now
* Added ability to toggle the visibility of shape layers
* Unsaved changes for signs and landmarks with prompt a warning when changing selection
* Added a warning when changing road surface for multiple roads
* The mount height number box now increments by 0.1 in.
* Added 'Name,' 'From Address,' and 'To Address' to roads with sidewalks report
* Added surface property to sidewalks
* Certain fault values will autofill the sidewalk recommendations
* Photos for different objects can now be stored in separate folders which are specified by the user
* Photo file names are now present in reports

BUG FIXES
----------------------------------------------------
* Fixed highlighting results on map for custom reports
* Map snapshot captures the actual dimentions of the map window

# Version 4.1.6.0
CHANGES
----------------------------------------------------
* Adding new sign supports and landmarks is now toggled on/off

BUG FIXES
----------------------------------------------------
* Deleting sign support option is disabled if no supports are selected
* After panning when curront mode is moving a sign support/landmark the current mode returns to moving

# Version 4.1.5.0
CHANGES
----------------------------------------------------
* Landmark reports now work as expected
* Landmark reports can now be imported
* Added sign supports to the custom report builder
* Added landmarks to the custom report builder

# Version 4.1.3.0
CHANGES
----------------------------------------------------
* Sign reports now work as expected
* Sign reports can now be imported
* Sign descriptions and sign panel options are now capitalized
* Separated recommendations for signs and sign supports
* Exported files now open immediatly
* Added the ability to move posts and landmarks on the map
* Added default favorite signs
* Added signs to the custom report builder

BUG FIXES
----------------------------------------------------
* Fixed symbols of sign posts not loading correctly
* Selecting survey date in signs no longer crashes TAMS

# Version 4.1.2.0
CHANGES
----------------------------------------------------
* Improved functionality of the search feature in the main window tool bar
* New setting to toggle zooming to selection on the map
* Added various keyboard shortcuts
* Custom report has a new option to select roads on the map
* Keys in the legend can be selected to display only selected colors on the map

BUG FIXES
----------------------------------------------------
* Fixed legend not repositioning when shrinking the map
* Saving changes when editing/ importing a table is much faster
* Sorting tables by numeric values now sorts as expected

# Version 4.1.1.1
CHANGES
----------------------------------------------------
* Added a loading splash animation when building a new project. This may also be used in other places in the future

# Version 4.1.1.0
CHANGES
----------------------------------------------------
* A legend is present in the bottom right corner of the map
* Roads can be colored by treatment
* There is a display option under the "Project" dropdown (replacing the theme option) that allows users to change display settings
* Warning prevents users from accidentally changing surface type
* For projects made after this release, changes in shape field settings are reflected in road database
* Exported csv files no longer have a space before every entry
* Changes made to a report opened with TAMS can be saved
* New advanced option for csv files to be imported and overwrite datatables in TAMS

BUG FIXES
----------------------------------------------------
* Panning with right click works again
* Generating a report on selected roads is working

# Version 4.1.0.2
CHANGES
----------------------------------------------------
* All reports can be exported as either a CSV or PNG file
* Road "Type" is now "Functional Classification"
* Custom Reports now work
* Added theme settings under "Project" dropdown
* Graph and table data now round to nearest tenth
* Notes in reports now truncate to fit table better

BUG FIXES
----------------------------------------------------
* Fixed issues with histroy reports resizing

# Version 4.1.0.1
CHANGES
----------------------------------------------------
* Improved performance when changing sign selection

BUG FIXES
----------------------------------------------------
* Fixed signs not saving all data
* Fixed issues with removing signs and deleting posts
* Fixed bug with two signs with the same description on a post

# Version 4.0.10.0
CHANGES
----------------------------------------------------
* Add 'Other' option for road type
* Reordered road type dropdown
* Changed graphs color scheme

# Version 4.0.9.0
CHANGES
----------------------------------------------------
* Notes are displayed in a more readable manner in the notes form and general report

# Version 4.0.8.1
CHANGES
----------------------------------------------------
* Made windows render in center of screen

BUG FIXES
----------------------------------------------------
* Sign lookup is no longer cut off when rendering on a smaller screen

# Version 4.0.8.0
CHANGES
----------------------------------------------------
* Added road type, notes, and distresses to general road report


# Version 4.0.7.0
BUG FIXES
----------------------------------------------------
* Fixed sign height not saving

# Version 4.0.6.0
----------------------------------------------------
* Fixes issue where Miscellaneous points were not saved to TAMS file on creation
* Reverts change to drop own buttons. The no longer have a click behavior beyond opening list
* Fixed typos in road module error messages
* Refined column display on some tables
* Adds data view in analysis tool to show actual vs expected maintenance based on rsl

# Version 4.0.5.0
----------------------------------------------------
* recommendation box on sidewalks is now a combo box with four options
* and the module panel drop down buttons now open the menu on mouse over
* The add sign/feature buttons can now be directly clicked, and clicking it is the same as clicking click map
* The order of menu items under those buttons was rearranged for clarity

# Version 4.0.4.1
BUG FIXES
----------------------------------------------------
* Guard and error handling

# Version 4.0.4.0
CHANGES
-----------------------------------------------------
* Refactor & Bug-fix of modules base
* Other bug fixes
* Picturebox bug fixes

# TAMS Version 4.0.3.6
CHANGES
------------------------------------------------------
* Fixed bug in roads module

# TAMS Version 4.0.3.5
CHANGES
------------------------------------------------------
* Added Distribution Graphs to Roads Module
* User can make a graph based on Road Type, Surface, Governing Distress, and RSL

BUG FIXES
-----------------------------------------------------
* Other Items now correctly show what item is empty rather than "signs"
* Fixed an issue where tams files were incorrectly Identified as 'broken'
* Improved Maintainability

# TAMS Version 4.0.3.4
* Updates to generic module.  This module is still considered beta quality
* Added new default items for generic module
* Other bug fixes

BUG FIXES
------------------------------------------------------
* Fixes a critical bug in generic module that could have caused loss of data.
* Fixed a bug in the signs module where date selection actually did nothing, now correctly selects the date.
* Refactored table modifacation into its own fuction.
* Function is in the base class project module since it is used by all the modules in TAMS.
* Made refinements to the roads import tool.

# TAMS version 4.0.3.0
CHANGES
------------------------------------------------------
* Implemnts Generic module
* generic module behaves the same as the signs module in most reguards
* generic module currently supports 4 specific types and 1 fully generic type.
* generic moudle must create a new shape file when used.
* Changes auto suggestion table to better reflect common treatment reccomenations.
* Database now up to version 8



