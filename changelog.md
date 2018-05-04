TAMS version 4.0.2

CHANGES
------------------------------------------------------

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

KOWN ISSUES
------------------------------------------------------

* Sign posts can be added but not removed
* Map view (such as open street map) not availible
* Recommends adding sign by gps coordinate, as adding sign by click by produce interesting results.
* No legend availabe when saving a snapshot of map.
* rsl may not be calculated if when directly typing in a number into distress box unless the enter key is pressed or another box is clicked.
* When toggling road colors on and off in project settings, colors do not update until a road has been saved or until tams has been reloaded.