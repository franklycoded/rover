# Pluto Rover

Programming language: C#

.NET Framework version: 4.6.2

Testing framework: NUnit

The Rover's API is implemented in the Rover.API.Communication project's Antenna class. It expects an instance of the NavigationConfig and RoverEngine classes via their interfaces. The former is not implemented because it wasn't the objective of the exercise.

To demonstrate familiarity with the concept of Separation of Concerns, the Rover's control functions (MoveForward, MoveBack, TurnLeft, TurnRight) are implemented in the RoverEngine class of the Rover.API.Service project.

The two test projects include 53 Unit Tests alltogether, and guarantee coverage for normal and edge cases.
