# Abstract classes and methods

The purpose of this exercise is to practice building class structures using abstract classes and methods and using encapsulation, inheritance, and polymorphism.

## Learning objectives

After completing the exercise, students will be able to:

- Define and use abstract classes and methods
- Reinforce the concepts of Encapsulation, Inheritance, and Polymorphism

## Evaluation criteria and functional requirements

* The project must not have any build errors.
* Code is presented in a clean, organized format.
* Code is appropriately encapsulated.
* Inheritance is used appropriately to avoid code duplication.
* Abstraction is used appropriately to prevent object creation and enforce needed method creation on inheritance.
* The code meets the specifications defined below.

**Notes for all classes**
- Readonly properties don't require a `set` accessor.

### Paint calculator

Your goal is to create classes for a paint calculator. The calculator works by having a customer input dimensions of walls. Then, the calculator lets them know how many gallons of paint they need to purchase. Much of the UI is already complete. You need to implement the underlying `Wall` classes that make the calculations possible.

Each wall has a name, a color, and dimensions. The dimensions needed are based on the shape of the wall. The application supports rectangular walls, square walls, and triangular walls.

To allow polymorphism and reuse common code, a `Wall` class is implemented that all other walls inherit from. But it doesn't include any dimensions of its own and, therefore, can't be used in the application as a wall.

### Instructions

#### Step One: Implement the `Wall` class

The `Wall` class can't be instantiated. 

The wall class has two `string` properties, `Name` and `Color`, that have only a public getter. 

Add a constructor that looks like this:

``` csharp
public Wall(string name, string color)
```

It also has one public method that subclasses must explicitly implement. `GetArea()` takes no parameters and returns an `int` representing the total area of the wall.

If you implemented the class correctly, the `WallTests` pass.

#### Step Two: Implement the `RectangleWall` class

`RectangleWall` extends `Wall` and adds two new `int` properties, `Length` and `Height`, that are readonly (only have a getter). Add a constructor that looks like this:

``` csharp
public RectangleWall(string name, string color, int length, int height)
```

Implement `GetArea()` to return the `Length` multiplied by the `Height`.

Add a `ToString()` method that returns a `string` in the following format:

```
Name (LengthxHeight) rectangle
```

For example, a `RectangleWall` created as `new RectangleWall("Office", "Green", 5, 10);` would return `Office (5x10) rectangle` from `ToString()`.

If you implemented the class correctly, the `RectangleWallTests` pass.

#### Step Three: Implement the `TriangleWall` class

`TriangleWall` extends `Wall` and adds two new `int` properties, `Base` and `Height`, that are readonly. Add a constructor that looks like this:

``` csharp
public TriangleWall(string name, string color, int baseLength, int height)
```

Implement `GetArea()` to return the `Base` multiplied by the `Height` and then divided by two.

>Note: The answer is rounded down to the nearest whole number because you're dividing an `int` by another `int`. This is fine.

Add a `ToString()` method that returns a `string` in the following format:

```
Name (BasexHeight) triangle
```

For example, a `TriangleWall` created as `new TriangleWall("Hall", "Green", 2, 3);` would return `Hall (2x3) triangle` from `ToString()`.

If you implemented the class correctly, the `TriangleWallTests` pass.

#### Step Four: Implement the `SquareWall` class

`SquareWall` extends `RectangleWall` (**not** `Wall`). Add a constructor that looks like this:

``` csharp
public SquareWall(string name, string color, int sideLength)
```

Add a `ToString()` method that returns a `string` in the following format:

```
Name (SideLengthxSideLength) square
```

For example, a `SquareWall` created as `new SquareWall("Bathroom", "Orange", 5);` would return `Bathroom (5x5) square` from `ToString()`.

If you implemented the class correctly, the `SquareWallTests` pass.

## Tips and tricks

- You've been given less explicit details for this exercise, but you have everything you need to complete it. Do your best, and let the unit tests guide your work.
- If a class can't be instantiated, that means that it's an abstract class.
- If a method must be implemented by a non-abstract class, that means that the method must be abstract.
