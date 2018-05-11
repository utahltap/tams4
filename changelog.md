# TAMS version 4.0.2.2 

Please note that the signs manager is still in the beta stages of development and some features may not work correctly. If you encounter any problems please contact the Utah LTAP center.

BUG FIXES
------------------------------------------------------
* Enforces Web Mercator projections on shapeflies and maps. This allows clicking to add signs to work with more more projections. 
	* Also added the means of handling the remaining edge cases where click to add signs might not work.
* Fixes a bug where changes the database would not get the correct entry if multiple edits where made in the same day.
* Refactored the means of determining governing distress into it's own method on ModuleRoads, This allows it to be called more freely provided the function receives the correct parameters.
* Minor adjustments to the database to improve search for signs by MUTCD code. 

CHANGES
------------------------------------------------------

* Implemented an automatic suggestion table, though the suggestions themselves may still be subject to change.
* Now allows a user to specify an RSL other than the one computed from distress rating. This does not affect the governing distress.
* Added Signs Module
	* Supports both importing existing shapefiles and creating new ones
	* Sign posts can be added to shapefile
	* Signs can be added or removed from post.
	* Reports can be generated for the signs in the form of CSV lists.
* Fixed a bug where TAMS would crash of the wrong kind of shapefile was opened (roads need line, signs need point files)
* Treatment editor can now be closed.
* Database updated to version 6.
	* primarily to support Signs module.
	* New blank database template added so new projects could be created faster.
	* Also added photos for a few more concrete distresses. Only Patch remains without photo.
* Fixed a bug regarding event bindings.

