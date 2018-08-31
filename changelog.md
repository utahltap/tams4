# TAMS 4.0.x
# Version 4.0.8.0
CHANGES
----------------------------------------------------
* Made windows render in center of screen

BUG FIXES
----------------------------------------------------
* Sign lookup is no longer cut off when rendering on a smaller screen

# Version 4.0.7.0
BUG FIXES
----------------------------------------------------
* Fixed sign height not saving

# Version 4.0.6.0
----------------------------------------------------
* Fixes issue where Miscellaneous points were not saved to TAMS file on creation.
* Reverts change to drop own buttons. The no longer have a click behavior beyond opening list.
* Fixed typos in road module error messages.
* Refined column display on some tables.
* Adds data view in analysis tool to show actual vs expected maintenance based on rsl.


# Version 4.0.5.0
----------------------------------------------------
* recommendation box on sidewalks is now a combo box with four options
* and the module panel drop down buttons now open the menu on mouse over
* The add sign/feature buttons can now be directly clicked, and clicking it is the same as clicking click map
* The order of menu items under those buttons was rearranged for clarity.


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



