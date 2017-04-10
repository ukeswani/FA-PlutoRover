# FA-PlutoRover
--
+ Implemented LocationManager that moves forward and backward and changes location (x, y) accordingly, depending on orientation.
+ LocationManager takes in a dependency, a module that reads current orientation, that helps it decide which co-ordinates to manipulate when moving.
+ Hence segregated IOrientationController interface, from last check-in, into IOrientationController and IOrientationReader.
+ IOrientationController and its implementation OrientationController have been renamed to IOrientationManager and OrientationManager respectively.
+ Have also partially implemented the WrapAround functionality.
+ Gave code more structure by creating one class per file, grouping files into folders, etc. More can be done e.g. Orientation and OrientationManager implementation go in a OrientationManager folder.
+ Not entirely happy with LocationManager design - switch case, code repetition, etc. Maybe can have a Location class.
+ Overall design idea was to have a InputController (taking input from console, file, etc.) feeding into a CommandsController (interprets sequence of commands to individual commands - LRFRB to TurnLeft, MoveRight, etc.), which calls a MovementController (MC) or PositionManager (PM). And MC/PM has two dependencies injected - LocationManager and OrientationManager.

Note about first code check-in:
1. Done after over an hour of work.
2. Included tests/interfaces/implementation for Orientation and OrientationController.
