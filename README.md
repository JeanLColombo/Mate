# Mate

Mate is a passion project. It is my very own chess C# library and related API's. 

# Contents

* [Core UML Class Diagrams](#core-uml-class-diagrams)
    * [Board](#board)
    * [Chess](#chess)
    * [Game](#game)
    * [Moves](#moves)
    * [Pieces](#pieces)
    * [Extensions](#extensions)

# Core UML Class Diagrams

The core library can be found in `Source\Core`. It implements a chess match between players. It contains several different classes, representing multiple aspects of a game o chess. Bellow is a subdivision of each specific design choices for this class:
* Board;
* Chess;
* Game;
* Moves;
* Pieces.

Afterwards, a brief description of all extension classes is presented.

## Board

Represents a board of chess, containing several different pieces, placed at specific squares.

### Classes

* [Source\Core\Abstractions\Enumerations.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/Enumerations.cs);
    * Implements `Files` and `Ranks` enums;
* [Source\Core\Abstractions\IPiece.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/IPiece.cs);
* [Source\Core\Abstractions\Square.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/Square.cs);
    * Inherits from `Tuple`;
* [Source\Core\Elements\Board.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Elements/Board.cs).

### Diagrams

![Board Class Diagram](docs/Figures/board.svg)
<details>
    <summary>Board Class Diagram</summary>
    
```mermaid
    classDiagram
    class Files{
        <<enumeration>>
        a
        b
        c
        d
        e
        f
        g
        h
    }
    class Ranks{
        <<enumeration>>
        one
        two
        three
        four
        five 
        six
        seven
        eight
    }
    class Tuple~Files,Ranks~{
        +Files Item1
        +Ranks Item2    
    }
    class Square{
        +Files File
        +Ranks Rank
        +bool Color
        +Square(Files, Ranks)
        +Square(Square)
        +IsSameFileAs(Square) bool
        +IsSameRankAs(Square) bool
        +IsSameSquareAs(Square) bool
        -GetColor() bool
    }
    class Board{
        -Dictionary~Square,IPiece~ Pieces
        +IReadOnlyDictionary~Square,IPiece~ Position 
        +Board()
        +Board(+IReadOnlyDictionary~Square,IPiece~)
    }
    class IPiece{
        <<interface>>
        bool Color
        AvailableMoves(IReadOnlyDictionary~Square,IPiece~) IReadOnlyCollection~Move~  
    }
    Ranks --* "1"  Tuple~Files,Ranks~
    Files --* "1"  Tuple~Files,Ranks~
    Tuple~Files,Ranks~ <|-- Square
    Square --* "0..64" Board
    IPiece --* "0..64" Board
```
</details>

## Chess

Represents the chess rules.

### Classes

* [Source\Core\Abstractions\Chess.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/Chess.cs);
* [Source\Core\Abstractions\IChess.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/IChess.cs);
* [Source\Core\Abstractions\MoveEntry.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/MoveEntry.cs);
* [Source\Core\Elements\Board.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Elements/Board.cs);
* [Source\Core\Elements\Rules\Custom.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Elements/Rules/Custom.cs).
* [Source\Core\Elements\Rules\Classical.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Elements/Rules/Classical.cs)

### Diagrams

![Chess Class Diagram](docs/Figures/chess.svg)
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

## Game

Represents the game dynamics and outcome.

### Classes

* [Source\Core\Abstractions\Enumerations.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/Enumerations.cs);
* [Source\Core\Abstractions\Game.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/Game.cs);
* [Source\Core\Abstractions\IChess.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/IChess.cs);
* [Source\Core\Abstractions\IGame.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/IGame.cs);
* [Source\Core\Elements\Games\Standard.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Elements/Games/Standard.cs);

### Diagrams

![Game Class Diagram](docs/Figures/game.svg)
<details>
    <summary>Game Class Diagram</summary>
    
```mermaid
    classDiagram
    class Outcome{
        <<enumeration>>
        Game
        Checked
        Stalemate
        Checkmate
    }
    class IChess{
        <<Interface>>
        IReadOnlyDictionary~Square,IPiece~ Position
        IReadOnlyCollection~MoveEntry~ MoveEntries
        AvailableMoves(bool)* IReadOnlyCollection~Move~
        Process(Move, out IPiece)* bool
    }
    class IGame{
        <<Interface>>
        Outcome Outcome
        int MoveCount
        bool CurrentPlayer
        IReadOnlyDictionary~Square, IPiece~ Position
        IReadOnlyCollection~MoveEntry~ MoveEntries
        IReadOnlyList~IReadOnlyList~Move~~ Moves
        IReadOnlyCollection~IPiece~ CapturedPieces
        int Score
        ProcessMove(Move) bool
        AvailableMoves() IReadOnlyCollection~Move~
    }
    class Game{
        <<abstract>>
        ~Outcome Outcome
        +int MoveCount
        +bool CurrentPlayer
        ~IChess Chess
        ~List _moves
        ~List _captured
        +Game(int, bool, IChess)
        ~GetScore() int
        +ProcessMove(Move)*
    }
    class Standard~TChess~{
        +Standard()
        +ProcessMove(Move)
    }
    Outcome --* "1" IGame
    IChess --* "1" IGame
    Game ..|> IGame
    Standard~TChess~ --|> Game
```
</details>

## Moves

Describes piece maneuvers on the board, such as `MoveType.Capture` or `MoveType.Castle`.

### Classes

* [Source\Core\Abstractions\Enumerations.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/Enumerations.cs);
    * Implements `Files` and `Ranks` enums;
* [Source\Core\Abstractions\Move.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/Move.cs);
* [Source\Core\Abstractions\MoveEntry.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/MoveEntry.cs);
* [Source\Core\Abstractions\Square.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/Square.cs);
    * Inherits from `Tuple`;
* [Source\Core\Elements\Board.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Elements/Board.cs).

### Diagrams

![Move Class Diagram](docs/Figures/move.svg)
<details>
    <summary>Game Class Diagram</summary>
    
```mermaid
    classDiagram
    class MoveType{
        <<enumeration>>
        Normal
        Capture
        Passant
        Rush
        Castle
        PromoteToKnight
        PromoteToBishop
        PromoteToRook
        PromoteToQueen
    }
    class Square{
        +Files File
        +Ranks Rank
        +bool Color
        +Square(Files, Ranks)
        +Square(Square)
        +IsSameFileAs(Square) bool
        +IsSameRankAs(Square) bool
        +IsSameSquareAs(Square) bool
        -GetColor() bool
    }
    class Move{
        +Square FromSquare
        +Square ToSquare
        +MoveType Type
        +Move(Square, Square, MoveTye)
        +Equals(object) bool
        +GetHashCode() int
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
    MoveType --* Move
    Square --* "2" Move
    Move --* MoveEntry
    Board --* MoveEntry
```
</details>

## Pieces

Represents chess pieces.

### Classes

* [Source\Core\Abstractions\IPiece.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/IPiece.cs);
* [Source\Core\Abstractions\Piece.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/Piece.cs);
* [Source\Core\Abstractions\Royalty.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/Royalty.cs);
* [Source\Core\Elements\Pieces\Bishop.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Elements/Pieces/Bishop.cs);
* [Source\Core\Elements\Pieces\King.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Elements/Pieces/King.cs);
* [Source\Core\Elements\Pieces\Knight.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Elements/Pieces/Knight.cs);
* [Source\Core\Elements\Pieces\Pawn.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Elements/Pieces/Pawn.cs);
* [Source\Core\Elements\Pieces\Queen.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Elements/Pieces/Queen.cs);
* [Source\Core\Elements\Pieces\Rook.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Elements/Pieces/Rook.cs).

### Abstract Piece Definition

![Abstract Piece Class Diagram](docs/Figures/abstract_piece.svg)
<details>
    <summary>Abstract Piece Class Diagram</summary>
    
```mermaid
    classDiagram
    class IPiece{
        <<interface>>
        bool Color
        AvailableMoves(IReadOnlyDictionary~Square,IPiece~) IReadOnlyCollection~Move~  
    }
    class Piece{
        <<abstract>>
        +bool Color
        +Piece(bool)
        +GetSquareFrom(IReadOnlyDictionary~Square,IPiece~) Square
        +AvailableMoves(IReadOnlyDictionary~Square,IPiece~)* IReadOnlyCollection~Move~  
    }
    Piece ..|> IPiece
```
</details>

### Pawn and Knight

![Pawn and Knight Class Diagram](docs/Figures/pawn_knight.svg)
<details>
    <summary>Pawn and Knight Class Diagram</summary>
    
```mermaid
    classDiagram
    class Piece{
        <<abstract>>
        +bool Color
        +Piece(bool)
        +GetSquareFrom(IReadOnlyDictionary~Square,IPiece~) Square
        +AvailableMoves(IReadOnlyDictionary~Square,IPiece~)* IReadOnlyCollection~Move~  
    }
    class Pawn{
        +Pawn(bool)
        +AvailableMoves(IReadOnlyDictionary~Square,IPiece~) IReadOnlyCollection~Move~
        -PawnAttack(IReadOnlyDictionary~Square,IPiece~) IReadOnlyCollection~Move~
        -PawnMoveForward(IReadOnlyDictionary~Square,IPiece~) IReadOnlyCollection~Move~
        -UpdateToPromotions(Move) IReadOnlyCollection~Move~
    }
    class Knight{
        +Knight(bool)
        +AvailableMoves(IReadOnlyDictionary~Square,IPiece~) IReadOnlyCollection~Move~
    }
    Piece <|-- Pawn
    Piece <|-- Knight
```
</details>

### Bishop and Rook

![Bishop and Rook Class Diagram](docs/Figures/bishop_rook.svg)
<details>
    <summary>Bishop and Rook Class Diagram</summary>
    
```mermaid
    classDiagram
    class Piece{
        <<abstract>>
        +bool Color
        +Piece(bool)
        +GetSquareFrom(IReadOnlyDictionary~Square,IPiece~) Square
        +AvailableMoves(IReadOnlyDictionary~Square,IPiece~)* IReadOnlyCollection~Move~  
    }
    class Bishop{
        +Bishop(bool)
        +AvailableMoves(IReadOnlyDictionary~Square,IPiece~) IReadOnlyCollection~Move~
    }
    class Rook{
        +Rook(bool)
        +AvailableMoves(IReadOnlyDictionary~Square,IPiece~) IReadOnlyCollection~Move~
    }
    Piece <|-- Bishop
    Piece <|-- Rook
```
</details>

### King and Queen

![King and Queen Class Diagram](docs/Figures/king_queen.svg)
<details>
    <summary>King and Queen Class Diagram</summary>
    
```mermaid
    classDiagram
    class Piece{
        <<abstract>>
        +bool Color
        +Piece(bool)
        +GetSquareFrom(IReadOnlyDictionary~Square,IPiece~) Square
        +AvailableMoves(IReadOnlyDictionary~Square,IPiece~)* IReadOnlyCollection~Move~  
    }
    class Royalty{
        <<Abstract>>
        +Royalty(bool)
        #RoyalAttack(IReadOnlyDictionary~Square,IPiece~, int) IReadOnlyCollection~Move~
    }
    class Queen{
        +Queen(bool)
        +AvailableMoves(IReadOnlyDictionary~Square,IPiece~) IReadOnlyCollection~Move~
    }
    class King{
        +King(bool)
        +AvailableMoves(IReadOnlyDictionary~Square,IPiece~) IReadOnlyCollection~Move~
    }
    Piece <|-- Royalty
    Royalty <|-- Queen
    Royalty <|-- King
```
</details>

## Extensions

### Classes

* [Source\Core\Abstractions\Enumerations.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Abstractions/Enumerations.cs);
* [Source\Core\Extensions\Attacking.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Extensions/Attacking.cs);
* [Source\Core\Extensions\Helper.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Extensions/Helper.cs);
* [Source\Core\Extensions\Legality.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Extensions/Legality.cs);
* [Source\Core\Extensions\Maneuverability.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Extensions/Maneuverability.cs);
* [Source\Core\Extensions\Setup.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Extensions/Setup.cs);
* [Source\Core\Extensions\SpecializedMoves\Castling.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Extensions/SpecializedMoves/Castling.cs);
* [Source\Core\Extensions\SpecializedMoves\PawnPassant.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Extensions/SpecializedMoves/PawnPassant.cs);
* [Source\Core\Extensions\SpecializedMoves\PawnRush.cs](https://github.com/JeanLColombo/Mate/blob/main/Source/Core/Extensions/SpecializedMoves/PawnRush.cs).

### Extensions Enumerations

![Enumerations Class Diagram](docs/Figures/ext_enums.svg)
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

### Attacking

![Attacking Class Diagram](docs/Figures/ext_attacking.svg)
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

### Helper

![Helper Class Diagram](docs/Figures/ext_helper.svg)
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

### Legality 

![Legality Class Diagram](docs/Figures/ext_legality.svg)
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

### Maneuverability

![Maneuverability Class Diagram](docs/Figures/ext_maneuver.svg)
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

### Setup

![Setup Class Diagram](docs/Figures/ext_setup.svg)
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

## Specialized Moves

Specialized moves are moves that requires additional information, that the piece might not have, such as historical `MoveEntry` data.

### Pawn Passant

Requires information regarding other pawns maneuvers on the board.

![Passant Class Diagram](docs/Figures/ext_passant.svg)
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

### Pawn Rush

Pawns must not have been moved.

![Rush Class Diagram](docs/Figures/ext_rush.svg)
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

### Castling

Castling rules must apply.

![Castles Class Diagram](docs/Figures/ext_castles.svg)
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