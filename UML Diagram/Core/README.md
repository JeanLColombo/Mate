# Core UML

# Piece and Board Design 

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
        
        Console.WriteLine("Can I change the IReadOnlyCollection? - No");
        
        Console.WriteLine("Can I change the IReadOnlyCollection Value's Property? - No");
        
        
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