# TAMS Version 4.0.3.3
* Updates to generic module.  This module is still considered beta quality
	* Added new default items for generic module
* Other bug fixes

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



