# Extensions

## Extensions Enumerations

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

## Attacking

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

## Helper

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

## Legality 

```mermaid
    classDiagram
    class Legality{
        <<static>>
        +IsChecked(this IChess, bool)$ bool
        +IsLegal(this Chess, Move)$ bool 
    }
```
## Maneuverability

```mermaid
    classDiagram
    class Maneuverability{
        <<static>>
        +MovePlus(this Square, int, int)$ Square
        +Maneuver(this Square, Through, int)$ Square
    }
```

## Setup

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

# Specialized Moves

## Pawn Passant

```mermaid
    classDiagram
    class PawnPassant{
        <<static>>
        +EnPassant(this IPiece, IReadOnlyDictionary~Square,IPiece~, IReadOnlyCollection~MoveEntry~)$ IReadOnlyCollection~Move~
    }
```

## Pawn Rush

```mermaid
    classDiagram
    class PawnRush{
        <<static>>
        +PawnFirstMove(this IPiece, IReadOnlyDictionary~Square,IPiece~)$ IReadOnlyCollection~Move~
    }
```

## Castling

```mermaid
    classDiagram
    class Castling{
        <<static>>
        +Castles(this IPiece, IReadOnlyDictionary~Square,IPiece, IReadOnlyCollection~MoveEntry~)$ IReadOnlyCollection~Move~
    }
```
