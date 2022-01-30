
![Match Class Diagram](docs/UML/Core/Figures/match.svg)
<details>
    <summary>Match Class Diagram</summary>
    
```mermaid
    classDiagram
    class IMatch{
        <<interface>>
        IReadOnlyList~IGame~ PlayedGames
        IGame CurrentGame
        int MaximumNumberOfGames
        int TotalGamesFinished
        bool MatchIsOver
    }
    class Match{
        <<abstract>>
        -List<Player> _players
        IReadOnlyList~IPlayer~ Players 
    }
    Match ..|> IMatch
    Player --* "1..*" Match
```
</details>
