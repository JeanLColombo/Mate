![Chess Class Diagram](Figures/chess.svg)
<details>
    <summary>Chess Class Diagram</summary>
    
```mermaid
    classDiagram
    class IChess{
        <<Interface>>
        IReadOnlyDictionary~Square,IPiece~ Position
        IReadOnlyCollection~MoveEntry~ MoveEntries
        AvailableMoves(bool)* IReadOnlyCollection~Move~
        Process(Move, out IPiece)* bool
    }
    class Chess{
        <<Abstract>>
        -Board Board
        -List~MoveEntry~ _moveEntries
        +IReadOnlyDictionary~Square,IPiece~ Position
        +IReadOnlyCollection~MoveEntry~ MoveEntries
        +Chess()
        +Chess(+IReadOnlyDictionary~Square,IPiece~)
        +Chess(IReadOnlyDictionary~Square,IPiece~,IReadOnlyCollection~MoveEntry~)
        +PlaceAt(Square, IPiece) 
        +Clear(Square)
        +Add(MoveEntry) 
        +AllMoves(bool) IReadOnlyCollection~Move~
        +AvailableMoves(bool)* IReadOnlyCollection~Move~
        +Process(Move, out IPiece)* bool
    }
    class Board{
        -Dictionary~Square,IPiece~ Pieces
        +IReadOnlyDictionary~Square,IPiece~ Position 
        +Board()
        +Board(+IReadOnlyDictionary~Square,IPiece~)
    }
    class MoveEntry{
        +Move Move
        +IReadOnlyDictionary~Square,IPiece~ Position
        -Board board
        +MoveEntry(Move, IReadOnlyDictionary~Square,IPiece~)
        +MoveEntry(Move, Board)
    }
    class Custom{
        +IEnumerable~MoveType~ BannedMoves
        +Custom(IReadOnlyDictionary~Square,IPiece~)
        +Custom(IReadOnlyDictionary~Square,IPiece~, HashSet~MoveType~)
        +Custom(Custom)
        +AllMoves(bool) IReadOnlyCollection~Move~
        +AvailableMoves(bool) IReadOnlyCollection~Move~
        +Process(Move, out IPiece) bool
        -ProcessNormal(Move)
        -ProcessCapture(Move)
        -ProcessEnPassant(Move, out IPiece)
        -ProcessCastle(Move)
        -ProcessPromotion(Move, out IPiece)
    }
    class Classical{
        -IReadOnlyDictionary~Square, IPiece~ StandardPosition
        +Classical()
    }
    Board --* "1" IChess
    MoveEntry --* "*" IChess
    Chess ..|> IChess
    Custom --|> Chess
    Classical --|> Custom
```
</details>