![Enumerations Class Diagram](Figures/ext_enums.svg)
<details>
    <summary>Enumerations Class Diagram</summary>
    
```mermaid
    classDiagram
    class Through{
        <<enumeration>>
        Files
        Ranks
        MainDiagonal
        OppositeDiagonal
    }
```
</details>

![Attacking Class Diagram](Figures/ext_attacking.svg)
<details>
    <summary>Attacking Class Diagram</summary>
    
```mermaid
    classDiagram
    class Attacking{
        <<static>>
        +AttackSquare(this Piece, Square, IReadOnlyDictionary~Square,IPiece~)$ Move
        +Attack(this Piece, Square, bool, IReadOnlyDictionary~Square,IPiece~)$ IReadOnlyCollection~Move~
        -AttackSquare(this Square, Square, IReadOnlyDictionary~Square,IPiece~)$ Move
        -Attack(this Square, Through, bool, int, IReadOnlyDictionary~Square,IPiece~)$ HashSet~Move~
    }
```
</details>

![Helper Class Diagram](Figures/ext_helper.svg)
<details>
    <summary>Helper Class Diagram</summary>
    
```mermaid
    classDiagram
    class Helper{
        <<static>>
        +AddNonNull(this List~T~, T)$ bool
        +Unify(this IReadOnlyCollection~T~, IReadOnlyCollection~T~)$ IReadOnlyCollection~T~
        +HasMoved(this IPiece, IReadOnlyDictionary~Square,IPiece~, IReadOnlyCollection~MoveEntry~)$ bool 
        +InBetweenSquares(this Square, Square)$ IReadOnlyCollection~Square~
    }
```
</details>

![Legality Class Diagram](Figures/ext_legality.svg)
<details>
    <summary>Legality Class Diagram</summary>
    
```mermaid
    classDiagram
    class Legality{
        <<static>>
        +IsChecked(this IChess, bool)$ bool
        +IsLegal<TChess>(this IChess, Move)$ bool 
        +IsCastlingLegal<TChess>(this IChess, Move)$ bool 
    }
```
</details>

![Maneuverability Class Diagram](Figures/ext_maneuver.svg)
<details>
    <summary>Maneuverability Class Diagram</summary>
    
```mermaid
    classDiagram
    class Maneuverability{
        <<static>>
        +MovePlus(this Square, int, int)$ Square
        +Maneuver(this Square, Through, int)$ Square
    }
```
</details>

![Setup Class Diagram](Figures/ext_setup.svg)
<details>
    <summary>Setup Class Diagram</summary>
    
```mermaid
    classDiagram
    class Setup{
        <<static>>
        +AddPiece(this Board, Square, bool)$ bool
        +AddPiece(this Chess, Square, IPiece)$ bool
        +RemovePiece(this Chess, Square, out IPiece)$ bool
        +Copy(this Board, IReadOnlyDictionary~Square,IPiece~)$
    }
```
</details>


![Passant Class Diagram](Figures/ext_passant.svg)
<details>
    <summary>Passant Class Diagram</summary>
    
```mermaid
    classDiagram
    class PawnPassant{
        <<static>>
        +EnPassant(this IPiece, IReadOnlyDictionary~Square,IPiece~, IReadOnlyCollection~MoveEntry~)$ IReadOnlyCollection~Move~
    }
```
</details>

![Rush Class Diagram](Figures/ext_rush.svg)
<details>
    <summary>Rush Class Diagram</summary>
    
```mermaid
    classDiagram
    class PawnRush{
        <<static>>
        +PawnFirstMove(this IPiece, IReadOnlyDictionary~Square,IPiece~)$ IReadOnlyCollection~Move~
    }
```
</details>

![Castles Class Diagram](Figures/ext_castles.svg)
<details>
    <summary>Castles Class Diagram</summary>
    
```mermaid
    classDiagram
    class Castling{
        <<static>>
        +Castles(this IPiece, IReadOnlyDictionary~Square,IPiece, IReadOnlyCollection~MoveEntry~)$ IReadOnlyCollection~Move~
    }
```
</details>