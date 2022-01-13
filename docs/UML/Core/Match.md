
![Match Class Diagram](docs/UML/Core/Figures/match.svg)
<details>
    <summary>Match Class Diagram</summary>
    
```mermaid
    classDiagram
    class IMatch{
        <<interface>>
        IReadOnlyList~IGame~ PlayedGames
        IReadOnlyList~IPlayer~ Players 
        IGame CurrentGame
        int MaximumNumberOfGames
        int TotalGamesFinished
        bool MatchIsOver
    }
    class Match{
        <<abstract>>
    }
    class IPlayer{
        <<interface>
        Outcome Resign(IMatch)
        Outcome Draw(IMatch)
        bool Play(IMatch, Move)
    }
    class Player{
        <<abstract>>
    }
    Match ..|> IMatch
    IPlayer --* "1..*" IMatch
    Player ..|> IPlayer
```
</details>
