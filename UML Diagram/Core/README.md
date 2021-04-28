# Core UML

## Piece and Board Design 

The following snippet was implemented to provide basic implementation of piece ownership.

```csharp
using System.IO;
using System;
using System.Collections.Generic;

class Program
{
    public interface IPiece 
    {
        bool Color { get; }
    }
    
    public class Piece: IPiece
    {
        public bool Color {get; set;}
        
        public Piece(bool c) { Color = c; }
        
    }
    
    
    static void Main()
    {
        
        IPiece p = new Piece(false);
        
        Console.WriteLine("Test IPiece Implementation.");
        Console.WriteLine(p.Color);
        
        Dictionary<int, IPiece> Pieces = new Dictionary<int, IPiece>();
        
        Pieces.Add(1, new Piece(true));
        Pieces.Add(2, null);
        Pieces.Add(3, new Piece(false));
        
        Console.WriteLine("Test Dictionary Implementation.");
        
        foreach (var pair in Pieces)
        {
            if (pair.Value == null)
                Console.WriteLine("Square is Empty");
            else
                Console.WriteLine(pair.Value.Color);
        }
        
        Console.WriteLine("Test IReadOnlyDictionary Implementation.");
        
        IReadOnlyDictionary<int,IPiece> IPieces = Pieces;
        
        foreach (var pair in IPieces)
        {
            if (pair.Value == null)
                Console.WriteLine("Square is Empty");
            else
                Console.WriteLine(pair.Value.Color);
        }
        
        Console.WriteLine("Change Original Dictionary.");
        
        Pieces[3] = null;
        
        foreach (var pair in Pieces)
        {
            if (pair.Value == null)
                Console.WriteLine("Square is Empty");
            else
                Console.WriteLine(pair.Value.Color);
        }
        
        Console.WriteLine("What about the IReadOnlyCollection?");
        
        foreach (var pair in IPieces)
        {
            if (pair.Value == null)
                Console.WriteLine("Square is Empty");
            else
                Console.WriteLine(pair.Value.Color);
        }
        
        Console.WriteLine(
                "Can I change the IReadOnlyCollection? - No");
        
        Console.WriteLine(
                "Can I change the IReadOnlyCollection " + 
                "Value's Property? - No");
        
        
    }
}
```

The output of `Main()` was:

```
Test IPiece Implementation.
False
Test Dictionary Implementation.
True
Square is Empty
False
Test IReadOnlyDictionary Implementation.
True
Square is Empty
False
Change Original Dictionary.
True
Square is Empty
Square is Empty
What about the IReadOnlyCollection?
True
Square is Empty
Square is Empty
Can I change the IReadOnlyCollection? - No
Can I change the IReadOnlyCollection Value's Property? - No
```

We need to check the how will we implement an `Square` object as an key. Or do we need a `<Files,Ranks>` pair as a `Key`?

## Checking if `Square` operates as a `TKey`

It doesn't. The following code proves.

```csharp
using System.IO;
using System;
using System.Collections.Generic;

public class Square
{
    public Files File { get; set; }
    public Ranks Rank { get; set; }

    public bool Color { get => GetColor(); }  

    public Square(Files f, Ranks r)
    {
        File = f;
        Rank = r;
    }

    public bool IsSameFileAs(Square p) => (this.File == p.File);
    public bool IsSameRankAs(Square p) => (this.Rank == p.Rank);
    public bool IsSameSquareAs(Square p) => 
        (IsSameFileAs(p) && IsSameRankAs(p));
    
    private bool GetColor() =>
        ((int) File % 2 == 0) ^ 
        ((int) Rank % 2 == 0);        
}

public enum Files
{
    a = 1,
    b = 2
}

public enum Ranks
{
    one = 1,
    two = 2
}

class Program
{
    
    static void Main()
    {
        var s1 = new Square(Files.a, Ranks.one);
        var s2 = new Square(Files.a, Ranks.one);
        var s3 = new Square(Files.b, Ranks.one);
        
        Console.WriteLine("Test if s1 and s2 are equal");
        
        Console.WriteLine(s1 == s2);
        Console.WriteLine(s1.IsSameSquareAs(s2));
        
        var board = new Dictionary<Square,int>();
        
        Console.WriteLine(
            "\nCreate a board, in a dictionary storing ints");
        
        int i = 1;
        
        foreach (Files f in Enum.GetValues(typeof(Files)))
            foreach (Ranks r in Enum.GetValues(typeof(Ranks)))
                board.Add(new Square(f,r), i++);
        
        Console.WriteLine("\nAccess all elements in the board");
        
        foreach(var entry in board)
        {
            Console.WriteLine("\tSquare {0}{1}"
                ,entry.Key.File, (int)entry.Key.Rank);
            Console.WriteLine("\t\tValue stored = {0}"
                , entry.Value);
        }
        
        Console.WriteLine("\nAccess element via key");
        
        Console.WriteLine(board[s3]); // Error: the given key was not present in dictionary
    
    }
}
```

It returns:

```
Test if s1 and s2 are equal
False
True

Create a board, in a dictionary storing ints

Access all elements in the board
	Square a1
		Value stored = 1
	Square a2
		Value stored = 2
	Square b1
		Value stored = 3
	Square b2
		Value stored = 4

Access element via key

Unhandled Exception:
System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary.
  at System.Collections.Generic.Dictionary`2[TKey,TValue].get_Item (TKey key) [0x0001e] in <902ab9e386384bec9c07fa19aa938869>:0 
  at Program.Main () [0x0018d] in <49510240740047a3a73e3bbe069e7b66>:0 
[ERROR] FATAL UNHANDLED EXCEPTION: System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary.
  at System.Collections.Generic.Dictionary`2[TKey,TValue].get_Item (TKey key) [0x0001e] in <902ab9e386384bec9c07fa19aa938869>:0 
  at Program.Main () [0x0018d] in <49510240740047a3a73e3bbe069e7b66>:0 
```

We need to implement a `Square` that can behave as a `Key`. Or use another approach.

## Solution: Make `Square` inherit from `Tuple<Files,Ranks>`

The following changes were added to `Square`.

```csharp
public class Square : Tuple<Files, Ranks>
{
    public Files File { get => this.Item1;}
    public Ranks Rank { get => this.Item2;}

    public bool Color { get => GetColor(); }  

    public Square(Files f, Ranks r) : base(f,r) { }

    public bool IsSameFileAs(Square p) => (this.File == p.File);
    public bool IsSameRankAs(Square p) => (this.Rank == p.Rank);
    public bool IsSameSquareAs(Square p) => 
        (IsSameFileAs(p) && IsSameRankAs(p));
    
    private bool GetColor() =>
        ((int) File % 2 == 0) ^ 
        ((int) Rank % 2 == 0);        
}
```

`Program.Main()` was executed, yilding the following output:

```
Test if s1 and s2 are equal
False
True

Create a board, in a dictionary storing ints

Access all elements in the board
	Square a1
		Value stored = 1
	Square a2
		Value stored = 2
	Square b1
		Value stored = 3
	Square b2
		Value stored = 4

Access element via key
3
```

`Square`'s `s1` and `s2` were still not equals, because they are different objetcs, and the `==` operator was not overridden. 

To further ilustrate, the following code was implemented:

```csharp
foreach (Files f in Enum.GetValues(typeof(Files)))
    foreach (Ranks r in Enum.GetValues(typeof(Ranks)))
    {
        var value = board[new Square(f,r)];
        Console.WriteLine("\tSquare {0}{1}",
            f, 
            (int)r);
        Console.WriteLine("\t\tValue stored = {0}", 
            value);
    }
```

Which outputs:

```
    Square a1
		Value stored = 1
	Square a2
		Value stored = 2
	Square b1
		Value stored = 3
	Square b2
		Value stored = 4
```


## Testing the code 

The previous code was implementd andd tested using [Conding Ground's C# online compiler (Mono v5.2.2)](https://www.tutorialspoint.com/compile_csharp_online.php).