# TAMS version 4.0.3.3
* Corrected version number

CHANGES
------------------------------------------------------
* Adds reports for Miscellaneous tracked objects in TAMS
* Added reccomendation input box for Sidewalk distress
* Adds a means of tracking which roads have sidewalk to the roads module
	* this feature is only availible of roads and other tabs are both active
	* is accessed via button that appears on the road controls once that stated condition is met
* Reorganizes main window menu items for user clarity

BUG FIXES
------------------------------------------------------

* Fixes various display issues in the gui
* Fixes inputs on other module to correctly map properties to the database for Accidents and Other

# TAMS version 4.0.3.2
* Corrected version number

# TAMS version 4.0.3.1

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



