
![Match Class Diagram](docs/UML/Core/Figures/match.svg)
<details>
    <summary>Match Class Diagram</summary>
    
```mermaid
    classDiagram
    class IMatch{
        <<interface>>
        int NumberOfGames
        IGame CurrentGame
        IReadOnlyList~IGame~ playedGames
        IReadOnlyDictionary~TPlayer, int~ Score 
        Forfeit() bool
        OfferDraw() bool
        AcceptDraw() bool
    }
    class Match{
        <<abstract>>
    }
    Match ..|> IMatch
```
</details>
