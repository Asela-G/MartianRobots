# Martian Robots Command Centre
A .NET console application that simulates robots exploring the surface of Mars on a rectangular grid. The system tracks robot positions, orientations, and handles scenarios where robots fall off the grid, leaving scents to warn future robots.

## Overview
This application tracks the movement of robots on a grid based on a series of commands and report the final positions of each robot including a 'LOST' status if they fall off the grid.

## key features:
- Robots navigate a rectangular grid representing the surface of Mars
- Each robot has a position (X, Y coordinates) and orientation (N, S, E, W)
- Robots can receive commands to turn left (L), turn right (R), or move forward (F)
- When a robot falls off the grid, it leaves a scent at its last position
- Future robots detect these scents and ignore commands that would cause them to fall off at the same location

## Setup Instructions

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later

### Steps to run the Application
1. Clone the repository:
   ```
   git clone https://github.com/Asela-G/MartianRobots.git
   cd MartianRobots
   ```
2. Build the project using the command:
   ```
   dotnet build
   ```
5. Run the application with:
   ```
   dotnet run --project MartianRobots
   ```
6. Follow the prompts to input grid size, robot starting positions, and movement commands.

### Input Format

1. **Grid Size**: Two space-separated integers representing the upper-right corner (e.g., `5 3`)
   - Maximum coordinate value: 50
   - Minimum is always (0, 0)

2. **Robot Position**: Three space-separated values (e.g., `1 1 E`)
   - X coordinate (integer)
   - Y coordinate (integer)
   - Orientation (N, S, E, or W)

3. **Commands**: String of characters (e.g., `RFRFRFRF`)
   - L = Turn Left
   - R = Turn Right
   - F = Move Forward
   - Maximum commands: 100

4. **Exit**: Press Enter without input on the robot position prompt

- Sample Input:
  ```
  5 3
  1 1 E
  RFRFRFRF
  3 2 N
  FRRFLLFFRRFLL
  0 3 W
  LLFFFLFLFL
  ```

### Output Format

The application outputs the final status of each robot:
```
RobotStatus: X Y Orientation [LOST]
```
- X, Y: Final coordinates
- Orientation: Final direction (N, S, E, W)
- LOST: If the robot fell off the grid
- Sample Output:
  ```
  1 1 E
  3 3 N LOST
  2 3 S
  ```

## Assumptions
- Robots operate independently and can move over previous robots finishing positions.
- Each robot will receive atleast one command and a maximum of 100 commands.
- The grid size will not exceed 50 x 50.

## Technology Choices

### Framework & Language
**.NET 8.0 C# 12.0** Provides modern C# features and performance improvements including:
  - Record types for immutable value objects
  - Pattern matching in switch expressions
  - C# 12 features for cleaner syntax

### Architecture & Design Patterns
- **Strategy Pattern**: Command processing uses strategy pattern for extensibility (although for 3 commands I would normally use a simple switch statement, this was done to demonstrate the pattern as it was mentioned that additional command types maybe required in future.)
- **Factory Pattern**: `CommandTypeStrategyFactory` provides centralized strategy creation
- **Domain-Driven Design**: Core business logic isolated in the Domain project

### Testing Framework
- **NUnit**: Modern, widely-adopted and established testing framework


## Development Approach

Given the size of the problem I got the core model working relatively quickly including the overall project structure first.
Then I iteratively added logic and unit tests in the following stages:

- Stage 1: Setup the project structure allowing the separation of concerns between client console app, domain logic, and tests
- Stage 2: Created core domain models mapping the domain entities and basic business rules e.g. Robot, Grid, Coordinates, Orientation
- Stage 3: Added scent tracking to Grid and implement robot movement logic including handling of lost robots along with related tests.
- Stage 4: Created 'CommandCentre' and moved the domain validation logic from client app to command centre within domain layer (in a larger business app I might have defined this upfront though).
- Stage 5: Added edge case unit tests, refined code style and input validation/error handling. 


## Future Enhancements

Potential areas for extension:
- **Input validation**: In a business app I would incoporate input validation in all layers not just the domain layer.
- **User Interface**: Web or desktop interface for visualization
- **Persistence**: Save/load robot missions and grid states
- **Advanced Commands**: Add new command types (e.g. backward movement)
- **Logging**: Add structured logging for debugging and observability
- **API**: REST API for programmatic access
- **Performance**: Optimize for very large grids or command sequences
