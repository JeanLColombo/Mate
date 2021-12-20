<a name='assembly'></a>
# Mate

## Contents

- [Attacking](#T-Core-Extensions-Attacking 'Core.Extensions.Attacking')
  - [Attack(piece,orientation,position,sense,range)](#M-Core-Extensions-Attacking-Attack-Core-Abstractions-Piece,Core-Abstractions-Through,System-Boolean,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece},System-UInt32- 'Core.Extensions.Attacking.Attack(Core.Abstractions.Piece,Core.Abstractions.Through,System.Boolean,System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece},System.UInt32)')
  - [Attack(originSquare,orientation,sense,position)](#M-Core-Extensions-Attacking-Attack-Core-Abstractions-Square,Core-Abstractions-Through,System-Boolean,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Extensions.Attacking.Attack(Core.Abstractions.Square,Core.Abstractions.Through,System.Boolean,System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
  - [AttackSquare(piece,square,position)](#M-Core-Extensions-Attacking-AttackSquare-Core-Abstractions-Piece,Core-Abstractions-Square,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Extensions.Attacking.AttackSquare(Core.Abstractions.Piece,Core.Abstractions.Square,System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
  - [AttackSquare(originSquare,square,position)](#M-Core-Extensions-Attacking-AttackSquare-Core-Abstractions-Square,Core-Abstractions-Square,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Extensions.Attacking.AttackSquare(Core.Abstractions.Square,Core.Abstractions.Square,System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
- [Bishop](#T-Core-Elements-Pieces-Bishop 'Core.Elements.Pieces.Bishop')
  - [#ctor(color)](#M-Core-Elements-Pieces-Bishop-#ctor-System-Boolean- 'Core.Elements.Pieces.Bishop.#ctor(System.Boolean)')
  - [AvailableMoves(position)](#M-Core-Elements-Pieces-Bishop-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Elements.Pieces.Bishop.AvailableMoves(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
- [Board](#T-Core-Elements-Board 'Core.Elements.Board')
  - [#ctor()](#M-Core-Elements-Board-#ctor 'Core.Elements.Board.#ctor')
  - [#ctor(position)](#M-Core-Elements-Board-#ctor-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Elements.Board.#ctor(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
  - [Pieces](#P-Core-Elements-Board-Pieces 'Core.Elements.Board.Pieces')
  - [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position')
- [Castling](#T-Core-Extensions-SpecializedMoves-Castling 'Core.Extensions.SpecializedMoves.Castling')
  - [Castles(king,position,moveEntries)](#M-Core-Extensions-SpecializedMoves-Castling-Castles-Core-Abstractions-IPiece,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece},System-Collections-Generic-IReadOnlyCollection{Core-Abstractions-MoveEntry}- 'Core.Extensions.SpecializedMoves.Castling.Castles(Core.Abstractions.IPiece,System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece},System.Collections.Generic.IReadOnlyCollection{Core.Abstractions.MoveEntry})')
- [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess')
  - [#ctor()](#M-Core-Abstractions-Chess-#ctor 'Core.Abstractions.Chess.#ctor')
  - [#ctor(position)](#M-Core-Abstractions-Chess-#ctor-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Abstractions.Chess.#ctor(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
  - [Board](#P-Core-Abstractions-Chess-Board 'Core.Abstractions.Chess.Board')
  - [Core#Abstractions#IChess#MoveEntries](#P-Core-Abstractions-Chess-Core#Abstractions#IChess#MoveEntries 'Core.Abstractions.Chess.Core#Abstractions#IChess#MoveEntries')
  - [Core#Abstractions#IChess#Position](#P-Core-Abstractions-Chess-Core#Abstractions#IChess#Position 'Core.Abstractions.Chess.Core#Abstractions#IChess#Position')
  - [MoveEntries](#P-Core-Abstractions-Chess-MoveEntries 'Core.Abstractions.Chess.MoveEntries')
  - [Position](#P-Core-Abstractions-Chess-Position 'Core.Abstractions.Chess.Position')
  - [_moveEntries](#P-Core-Abstractions-Chess-_moveEntries 'Core.Abstractions.Chess._moveEntries')
  - [AllMoves(color)](#M-Core-Abstractions-Chess-AllMoves-System-Boolean- 'Core.Abstractions.Chess.AllMoves(System.Boolean)')
  - [AvailableMoves(color)](#M-Core-Abstractions-Chess-AvailableMoves-System-Boolean- 'Core.Abstractions.Chess.AvailableMoves(System.Boolean)')
  - [Clear(square)](#M-Core-Abstractions-Chess-Clear-Core-Abstractions-Square- 'Core.Abstractions.Chess.Clear(Core.Abstractions.Square)')
  - [Core#Abstractions#IChess#AvailableMoves(c)](#M-Core-Abstractions-Chess-Core#Abstractions#IChess#AvailableMoves-System-Boolean- 'Core.Abstractions.Chess.Core#Abstractions#IChess#AvailableMoves(System.Boolean)')
  - [PlaceAt(square,piece)](#M-Core-Abstractions-Chess-PlaceAt-Core-Abstractions-Square,Core-Abstractions-IPiece- 'Core.Abstractions.Chess.PlaceAt(Core.Abstractions.Square,Core.Abstractions.IPiece)')
- [Custom](#T-Core-Elements-Rules-Custom 'Core.Elements.Rules.Custom')
  - [#ctor(position)](#M-Core-Elements-Rules-Custom-#ctor-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Elements.Rules.Custom.#ctor(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
  - [#ctor(position,bannedMoves)](#M-Core-Elements-Rules-Custom-#ctor-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece},System-Collections-Generic-HashSet{Core-Abstractions-MoveType}- 'Core.Elements.Rules.Custom.#ctor(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece},System.Collections.Generic.HashSet{Core.Abstractions.MoveType})')
  - [BannedMoves](#F-Core-Elements-Rules-Custom-BannedMoves 'Core.Elements.Rules.Custom.BannedMoves')
  - [AllMoves(color)](#M-Core-Elements-Rules-Custom-AllMoves-System-Boolean- 'Core.Elements.Rules.Custom.AllMoves(System.Boolean)')
  - [AvailableMoves(color)](#M-Core-Elements-Rules-Custom-AvailableMoves-System-Boolean- 'Core.Elements.Rules.Custom.AvailableMoves(System.Boolean)')
- [Files](#T-Core-Abstractions-Files 'Core.Abstractions.Files')
  - [a](#F-Core-Abstractions-Files-a 'Core.Abstractions.Files.a')
  - [b](#F-Core-Abstractions-Files-b 'Core.Abstractions.Files.b')
  - [c](#F-Core-Abstractions-Files-c 'Core.Abstractions.Files.c')
  - [d](#F-Core-Abstractions-Files-d 'Core.Abstractions.Files.d')
  - [e](#F-Core-Abstractions-Files-e 'Core.Abstractions.Files.e')
  - [f](#F-Core-Abstractions-Files-f 'Core.Abstractions.Files.f')
  - [g](#F-Core-Abstractions-Files-g 'Core.Abstractions.Files.g')
  - [h](#F-Core-Abstractions-Files-h 'Core.Abstractions.Files.h')
- [Game](#T-Core-Abstractions-Game 'Core.Abstractions.Game')
  - [Chess](#P-Core-Abstractions-Game-Chess 'Core.Abstractions.Game.Chess')
  - [CurrentMove](#P-Core-Abstractions-Game-CurrentMove 'Core.Abstractions.Game.CurrentMove')
  - [CurrentPlayer](#P-Core-Abstractions-Game-CurrentPlayer 'Core.Abstractions.Game.CurrentPlayer')
  - [ProcessMove(move)](#M-Core-Abstractions-Game-ProcessMove-Core-Abstractions-Move- 'Core.Abstractions.Game.ProcessMove(Core.Abstractions.Move)')
- [Helper](#T-Core-Extensions-Helper 'Core.Extensions.Helper')
  - [AddNonNull\`\`1(list,value)](#M-Core-Extensions-Helper-AddNonNull``1-System-Collections-Generic-HashSet{``0},``0- 'Core.Extensions.Helper.AddNonNull``1(System.Collections.Generic.HashSet{``0},``0)')
  - [HasMoved(piece,position,moveEntries)](#M-Core-Extensions-Helper-HasMoved-Core-Abstractions-IPiece,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece},System-Collections-Generic-IReadOnlyCollection{Core-Abstractions-MoveEntry}- 'Core.Extensions.Helper.HasMoved(Core.Abstractions.IPiece,System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece},System.Collections.Generic.IReadOnlyCollection{Core.Abstractions.MoveEntry})')
  - [InBetweenSquares(s1,s2)](#M-Core-Extensions-Helper-InBetweenSquares-Core-Abstractions-Square,Core-Abstractions-Square- 'Core.Extensions.Helper.InBetweenSquares(Core.Abstractions.Square,Core.Abstractions.Square)')
  - [Unify\`\`1(firstCollection,secondCollection)](#M-Core-Extensions-Helper-Unify``1-System-Collections-Generic-IReadOnlyCollection{``0},System-Collections-Generic-IReadOnlyCollection{``0}- 'Core.Extensions.Helper.Unify``1(System.Collections.Generic.IReadOnlyCollection{``0},System.Collections.Generic.IReadOnlyCollection{``0})')
- [IChess](#T-Core-Abstractions-IChess 'Core.Abstractions.IChess')
  - [MoveEntries](#P-Core-Abstractions-IChess-MoveEntries 'Core.Abstractions.IChess.MoveEntries')
  - [Position](#P-Core-Abstractions-IChess-Position 'Core.Abstractions.IChess.Position')
  - [AvailableMoves(color)](#M-Core-Abstractions-IChess-AvailableMoves-System-Boolean- 'Core.Abstractions.IChess.AvailableMoves(System.Boolean)')
- [IGame](#T-Core-Abstractions-IGame 'Core.Abstractions.IGame')
  - [Chess](#P-Core-Abstractions-IGame-Chess 'Core.Abstractions.IGame.Chess')
  - [CurrentMove](#P-Core-Abstractions-IGame-CurrentMove 'Core.Abstractions.IGame.CurrentMove')
  - [CurrentPlayer](#P-Core-Abstractions-IGame-CurrentPlayer 'Core.Abstractions.IGame.CurrentPlayer')
  - [ProcessMove(move)](#M-Core-Abstractions-IGame-ProcessMove-Core-Abstractions-Move- 'Core.Abstractions.IGame.ProcessMove(Core.Abstractions.Move)')
- [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece')
  - [Color](#P-Core-Abstractions-IPiece-Color 'Core.Abstractions.IPiece.Color')
  - [AvailableMoves(position)](#M-Core-Abstractions-IPiece-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Abstractions.IPiece.AvailableMoves(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
- [King](#T-Core-Elements-Pieces-King 'Core.Elements.Pieces.King')
  - [#ctor(color)](#M-Core-Elements-Pieces-King-#ctor-System-Boolean- 'Core.Elements.Pieces.King.#ctor(System.Boolean)')
  - [AvailableMoves(position)](#M-Core-Elements-Pieces-King-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Elements.Pieces.King.AvailableMoves(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
- [Knight](#T-Core-Elements-Pieces-Knight 'Core.Elements.Pieces.Knight')
  - [#ctor(color)](#M-Core-Elements-Pieces-Knight-#ctor-System-Boolean- 'Core.Elements.Pieces.Knight.#ctor(System.Boolean)')
  - [AvailableMoves(position)](#M-Core-Elements-Pieces-Knight-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Elements.Pieces.Knight.AvailableMoves(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
- [Legality](#T-Core-Extensions-Legality 'Core.Extensions.Legality')
  - [IsChecked(chess,player)](#M-Core-Extensions-Legality-IsChecked-Core-Abstractions-IChess,System-Boolean- 'Core.Extensions.Legality.IsChecked(Core.Abstractions.IChess,System.Boolean)')
  - [IsLegal(chess,move)](#M-Core-Extensions-Legality-IsLegal-Core-Abstractions-IChess,Core-Abstractions-Move- 'Core.Extensions.Legality.IsLegal(Core.Abstractions.IChess,Core.Abstractions.Move)')
- [Maneuverability](#T-Core-Extensions-Maneuverability 'Core.Extensions.Maneuverability')
  - [Maneuver(square,orientation,numberOfSquares)](#M-Core-Extensions-Maneuverability-Maneuver-Core-Abstractions-Square,Core-Abstractions-Through,System-Int32- 'Core.Extensions.Maneuverability.Maneuver(Core.Abstractions.Square,Core.Abstractions.Through,System.Int32)')
  - [MovePlus(square,numberOfFiles,numberOfRanks)](#M-Core-Extensions-Maneuverability-MovePlus-Core-Abstractions-Square,System-Int32,System-Int32- 'Core.Extensions.Maneuverability.MovePlus(Core.Abstractions.Square,System.Int32,System.Int32)')
  - [NormalMove(chess,move)](#M-Core-Extensions-Maneuverability-NormalMove-Core-Abstractions-Chess,Core-Abstractions-Move- 'Core.Extensions.Maneuverability.NormalMove(Core.Abstractions.Chess,Core.Abstractions.Move)')
  - [Process(chess,move)](#M-Core-Extensions-Maneuverability-Process-Core-Abstractions-Chess,Core-Abstractions-Move- 'Core.Extensions.Maneuverability.Process(Core.Abstractions.Chess,Core.Abstractions.Move)')
- [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move')
  - [#ctor(origin,destination,type)](#M-Core-Abstractions-Move-#ctor-Core-Abstractions-Square,Core-Abstractions-Square,Core-Abstractions-MoveType- 'Core.Abstractions.Move.#ctor(Core.Abstractions.Square,Core.Abstractions.Square,Core.Abstractions.MoveType)')
  - [FromSquare](#P-Core-Abstractions-Move-FromSquare 'Core.Abstractions.Move.FromSquare')
  - [ToSquare](#P-Core-Abstractions-Move-ToSquare 'Core.Abstractions.Move.ToSquare')
  - [Type](#P-Core-Abstractions-Move-Type 'Core.Abstractions.Move.Type')
- [MoveEntry](#T-Core-Abstractions-MoveEntry 'Core.Abstractions.MoveEntry')
  - [#ctor(move,position)](#M-Core-Abstractions-MoveEntry-#ctor-Core-Abstractions-Move,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Abstractions.MoveEntry.#ctor(Core.Abstractions.Move,System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
  - [#ctor(move)](#M-Core-Abstractions-MoveEntry-#ctor-Core-Abstractions-Move,Core-Elements-Board- 'Core.Abstractions.MoveEntry.#ctor(Core.Abstractions.Move,Core.Elements.Board)')
  - [Move](#P-Core-Abstractions-MoveEntry-Move 'Core.Abstractions.MoveEntry.Move')
  - [Position](#P-Core-Abstractions-MoveEntry-Position 'Core.Abstractions.MoveEntry.Position')
  - [board](#P-Core-Abstractions-MoveEntry-board 'Core.Abstractions.MoveEntry.board')
- [MoveType](#T-Core-Abstractions-MoveType 'Core.Abstractions.MoveType')
  - [Capture](#F-Core-Abstractions-MoveType-Capture 'Core.Abstractions.MoveType.Capture')
  - [Castle](#F-Core-Abstractions-MoveType-Castle 'Core.Abstractions.MoveType.Castle')
  - [Normal](#F-Core-Abstractions-MoveType-Normal 'Core.Abstractions.MoveType.Normal')
  - [Passant](#F-Core-Abstractions-MoveType-Passant 'Core.Abstractions.MoveType.Passant')
  - [PromotToBishop](#F-Core-Abstractions-MoveType-PromotToBishop 'Core.Abstractions.MoveType.PromotToBishop')
  - [PromoteToKnight](#F-Core-Abstractions-MoveType-PromoteToKnight 'Core.Abstractions.MoveType.PromoteToKnight')
  - [PromoteToQueen](#F-Core-Abstractions-MoveType-PromoteToQueen 'Core.Abstractions.MoveType.PromoteToQueen')
  - [PromoteToRook](#F-Core-Abstractions-MoveType-PromoteToRook 'Core.Abstractions.MoveType.PromoteToRook')
  - [Rush](#F-Core-Abstractions-MoveType-Rush 'Core.Abstractions.MoveType.Rush')
- [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn')
  - [#ctor(color)](#M-Core-Elements-Pieces-Pawn-#ctor-System-Boolean- 'Core.Elements.Pieces.Pawn.#ctor(System.Boolean)')
  - [AvailableMoves(position)](#M-Core-Elements-Pieces-Pawn-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Elements.Pieces.Pawn.AvailableMoves(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
  - [PawnAttack(position)](#M-Core-Elements-Pieces-Pawn-PawnAttack-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Elements.Pieces.Pawn.PawnAttack(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
  - [PawnMoveForward(position)](#M-Core-Elements-Pieces-Pawn-PawnMoveForward-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Elements.Pieces.Pawn.PawnMoveForward(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
  - [UpdateToPromotions(move)](#M-Core-Elements-Pieces-Pawn-UpdateToPromotions-Core-Abstractions-Move- 'Core.Elements.Pieces.Pawn.UpdateToPromotions(Core.Abstractions.Move)')
- [PawnPassant](#T-Core-Extensions-SpecializedMoves-PawnPassant 'Core.Extensions.SpecializedMoves.PawnPassant')
  - [EnPassant(piece,position,moveEntries)](#M-Core-Extensions-SpecializedMoves-PawnPassant-EnPassant-Core-Abstractions-IPiece,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece},System-Collections-Generic-IReadOnlyCollection{Core-Abstractions-MoveEntry}- 'Core.Extensions.SpecializedMoves.PawnPassant.EnPassant(Core.Abstractions.IPiece,System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece},System.Collections.Generic.IReadOnlyCollection{Core.Abstractions.MoveEntry})')
- [PawnRush](#T-Core-Extensions-SpecializedMoves-PawnRush 'Core.Extensions.SpecializedMoves.PawnRush')
  - [PawnFirstMove(piece,position)](#M-Core-Extensions-SpecializedMoves-PawnRush-PawnFirstMove-Core-Abstractions-IPiece,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Extensions.SpecializedMoves.PawnRush.PawnFirstMove(Core.Abstractions.IPiece,System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
- [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece')
  - [#ctor(color)](#M-Core-Abstractions-Piece-#ctor-System-Boolean- 'Core.Abstractions.Piece.#ctor(System.Boolean)')
  - [Color](#P-Core-Abstractions-Piece-Color 'Core.Abstractions.Piece.Color')
  - [Core#Abstractions#IPiece#Color](#P-Core-Abstractions-Piece-Core#Abstractions#IPiece#Color 'Core.Abstractions.Piece.Core#Abstractions#IPiece#Color')
  - [AvailableMoves(position)](#M-Core-Abstractions-Piece-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Abstractions.Piece.AvailableMoves(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
  - [Core#Abstractions#IPiece#AvailableMoves()](#M-Core-Abstractions-Piece-Core#Abstractions#IPiece#AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Abstractions.Piece.Core#Abstractions#IPiece#AvailableMoves(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
  - [GetSquareFrom(position)](#M-Core-Abstractions-Piece-GetSquareFrom-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Abstractions.Piece.GetSquareFrom(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
- [Queen](#T-Core-Elements-Pieces-Queen 'Core.Elements.Pieces.Queen')
  - [#ctor(color)](#M-Core-Elements-Pieces-Queen-#ctor-System-Boolean- 'Core.Elements.Pieces.Queen.#ctor(System.Boolean)')
  - [AvailableMoves(position)](#M-Core-Elements-Pieces-Queen-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Elements.Pieces.Queen.AvailableMoves(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
- [Ranks](#T-Core-Abstractions-Ranks 'Core.Abstractions.Ranks')
  - [eight](#F-Core-Abstractions-Ranks-eight 'Core.Abstractions.Ranks.eight')
  - [five](#F-Core-Abstractions-Ranks-five 'Core.Abstractions.Ranks.five')
  - [four](#F-Core-Abstractions-Ranks-four 'Core.Abstractions.Ranks.four')
  - [one](#F-Core-Abstractions-Ranks-one 'Core.Abstractions.Ranks.one')
  - [seven](#F-Core-Abstractions-Ranks-seven 'Core.Abstractions.Ranks.seven')
  - [six](#F-Core-Abstractions-Ranks-six 'Core.Abstractions.Ranks.six')
  - [three](#F-Core-Abstractions-Ranks-three 'Core.Abstractions.Ranks.three')
  - [two](#F-Core-Abstractions-Ranks-two 'Core.Abstractions.Ranks.two')
- [Rook](#T-Core-Elements-Pieces-Rook 'Core.Elements.Pieces.Rook')
  - [#ctor(color)](#M-Core-Elements-Pieces-Rook-#ctor-System-Boolean- 'Core.Elements.Pieces.Rook.#ctor(System.Boolean)')
  - [AvailableMoves(position)](#M-Core-Elements-Pieces-Rook-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Elements.Pieces.Rook.AvailableMoves(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
- [Royalty](#T-Core-Abstractions-Royalty 'Core.Abstractions.Royalty')
  - [#ctor(color)](#M-Core-Abstractions-Royalty-#ctor-System-Boolean- 'Core.Abstractions.Royalty.#ctor(System.Boolean)')
  - [RoyalAttack(position,numberOfSquares)](#M-Core-Abstractions-Royalty-RoyalAttack-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece},System-UInt32- 'Core.Abstractions.Royalty.RoyalAttack(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece},System.UInt32)')
- [Setup](#T-Core-Extensions-Setup 'Core.Extensions.Setup')
  - [AddPiece(chess,square,piece)](#M-Core-Extensions-Setup-AddPiece-Core-Abstractions-Chess,Core-Abstractions-Square,Core-Abstractions-IPiece- 'Core.Extensions.Setup.AddPiece(Core.Abstractions.Chess,Core.Abstractions.Square,Core.Abstractions.IPiece)')
  - [AddPiece\`\`1(board,square,color)](#M-Core-Extensions-Setup-AddPiece``1-Core-Elements-Board,Core-Abstractions-Square,System-Boolean- 'Core.Extensions.Setup.AddPiece``1(Core.Elements.Board,Core.Abstractions.Square,System.Boolean)')
  - [Copy(board,position)](#M-Core-Extensions-Setup-Copy-Core-Elements-Board,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Extensions.Setup.Copy(Core.Elements.Board,System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})')
  - [RemovePiece(chess,square,piece)](#M-Core-Extensions-Setup-RemovePiece-Core-Abstractions-Chess,Core-Abstractions-Square,Core-Abstractions-IPiece@- 'Core.Extensions.Setup.RemovePiece(Core.Abstractions.Chess,Core.Abstractions.Square,Core.Abstractions.IPiece@)')
- [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square')
  - [#ctor(f,r)](#M-Core-Abstractions-Square-#ctor-Core-Abstractions-Files,Core-Abstractions-Ranks- 'Core.Abstractions.Square.#ctor(Core.Abstractions.Files,Core.Abstractions.Ranks)')
  - [#ctor(square)](#M-Core-Abstractions-Square-#ctor-Core-Abstractions-Square- 'Core.Abstractions.Square.#ctor(Core.Abstractions.Square)')
  - [Color](#P-Core-Abstractions-Square-Color 'Core.Abstractions.Square.Color')
  - [File](#P-Core-Abstractions-Square-File 'Core.Abstractions.Square.File')
  - [Rank](#P-Core-Abstractions-Square-Rank 'Core.Abstractions.Square.Rank')
  - [GetColor()](#M-Core-Abstractions-Square-GetColor 'Core.Abstractions.Square.GetColor')
  - [IsSameFileAs(p)](#M-Core-Abstractions-Square-IsSameFileAs-Core-Abstractions-Square- 'Core.Abstractions.Square.IsSameFileAs(Core.Abstractions.Square)')
  - [IsSameRankAs(p)](#M-Core-Abstractions-Square-IsSameRankAs-Core-Abstractions-Square- 'Core.Abstractions.Square.IsSameRankAs(Core.Abstractions.Square)')
  - [IsSameSquareAs(p)](#M-Core-Abstractions-Square-IsSameSquareAs-Core-Abstractions-Square- 'Core.Abstractions.Square.IsSameSquareAs(Core.Abstractions.Square)')
- [Through](#T-Core-Abstractions-Through 'Core.Abstractions.Through')
  - [Files](#F-Core-Abstractions-Through-Files 'Core.Abstractions.Through.Files')
  - [MainDiagonal](#F-Core-Abstractions-Through-MainDiagonal 'Core.Abstractions.Through.MainDiagonal')
  - [OppositeDiagonal](#F-Core-Abstractions-Through-OppositeDiagonal 'Core.Abstractions.Through.OppositeDiagonal')
  - [Ranks](#F-Core-Abstractions-Through-Ranks 'Core.Abstractions.Through.Ranks')

<a name='T-Core-Extensions-Attacking'></a>
## Attacking `type`

##### Namespace

Core.Extensions

##### Summary

Provide extension methods for [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') attack logic in a
given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position').

<a name='M-Core-Extensions-Attacking-Attack-Core-Abstractions-Piece,Core-Abstractions-Through,System-Boolean,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece},System-UInt32-'></a>
### Attack(piece,orientation,position,sense,range) `method`

##### Summary

Attack all squares through a certain direction.

##### Returns

A read-only [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| piece | [Core.Abstractions.Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') | Attacking [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece'). |
| orientation | [Core.Abstractions.Through](#T-Core-Abstractions-Through 'Core.Abstractions.Through') | Attack orientation. |
| position | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |
| sense | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | True if the attack sense follows the orientation.
False otherwise. |
| range | [System.UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') | The range of the attack. Indicates how deep the attack is
relative to [GetSquareFrom](#M-Core-Abstractions-Piece-GetSquareFrom-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Abstractions.Piece.GetSquareFrom(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})'). |

<a name='M-Core-Extensions-Attacking-Attack-Core-Abstractions-Square,Core-Abstractions-Through,System-Boolean,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### Attack(originSquare,orientation,sense,position) `method`

##### Summary

Attack all squares through a certain direction, based on their distance from 
`originSquare`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| originSquare | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | Attacker square, based on 
`position`. |
| orientation | [Core.Abstractions.Through](#T-Core-Abstractions-Through 'Core.Abstractions.Through') | Attack orientation. |
| sense | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True if the attack sense follows the orientation.
False otherwise. |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='M-Core-Extensions-Attacking-AttackSquare-Core-Abstractions-Piece,Core-Abstractions-Square,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### AttackSquare(piece,square,position) `method`

##### Summary

Returns the corresponding [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') associated with 
`piece`, attacking a `square`, based on the
given `position`.

##### Returns

The corresponding [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') associated with 
this attack.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| piece | [Core.Abstractions.Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') | Attacking [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece'). |
| square | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | Attacked [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square'). |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='M-Core-Extensions-Attacking-AttackSquare-Core-Abstractions-Square,Core-Abstractions-Square,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### AttackSquare(originSquare,square,position) `method`

##### Summary

Internal logic for determing the corresponding [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') for an attack being mounted
from `originSquare` to `square`, based on the given
`position`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| originSquare | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | Attacker square, based on 
`position`. |
| square | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | Attacked [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square'). |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='T-Core-Elements-Pieces-Bishop'></a>
## Bishop `type`

##### Namespace

Core.Elements.Pieces

##### Summary

Implements the [Bishop](#T-Core-Elements-Pieces-Bishop 'Core.Elements.Pieces.Bishop') piece.

<a name='M-Core-Elements-Pieces-Bishop-#ctor-System-Boolean-'></a>
### #ctor(color) `constructor`

##### Summary

Creates a [Bishop](#T-Core-Elements-Pieces-Bishop 'Core.Elements.Pieces.Bishop') piece of given `color`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True for white. Black otherwise. |

<a name='M-Core-Elements-Pieces-Bishop-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### AvailableMoves(position) `method`

##### Summary

Returns all moves available for a [Bishop](#T-Core-Elements-Pieces-Bishop 'Core.Elements.Pieces.Bishop') based on a board `position`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='T-Core-Elements-Board'></a>
## Board `type`

##### Namespace

Core.Elements

##### Summary

Defines a chess [Board](#T-Core-Elements-Board 'Core.Elements.Board') and its properties.

<a name='M-Core-Elements-Board-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new [Board](#T-Core-Elements-Board 'Core.Elements.Board') object with no [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece')'s.

##### Returns



##### Parameters

This constructor has no parameters.

<a name='M-Core-Elements-Board-#ctor-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### #ctor(position) `constructor`

##### Summary

Creates a new instance of [Board](#T-Core-Elements-Board 'Core.Elements.Board'), containing a complete 
copy of given `position`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A read-only dictionary of [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') instances
placed in [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') instances. |

<a name='P-Core-Elements-Board-Pieces'></a>
### Pieces `property`

##### Summary

The Dictionary of [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece')'s on the board, based on their
[Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square').

##### Returns



<a name='P-Core-Elements-Board-Position'></a>
### Position `property`

##### Summary

Get the current position on the [Board](#T-Core-Elements-Board 'Core.Elements.Board').

<a name='T-Core-Extensions-SpecializedMoves-Castling'></a>
## Castling `type`

##### Namespace

Core.Extensions.SpecializedMoves

##### Summary

Provides extension methods for castling, both king and queen side.

<a name='M-Core-Extensions-SpecializedMoves-Castling-Castles-Core-Abstractions-IPiece,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece},System-Collections-Generic-IReadOnlyCollection{Core-Abstractions-MoveEntry}-'></a>
### Castles(king,position,moveEntries) `method`

##### Summary

Return available castling options for `king`, given
a `position` and `moveEntries`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| king | [Core.Abstractions.IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') | Must be [King](#T-Core-Elements-Pieces-King 'Core.Elements.Pieces.King'). |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |
| moveEntries | [System.Collections.Generic.IReadOnlyCollection{Core.Abstractions.MoveEntry}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyCollection 'System.Collections.Generic.IReadOnlyCollection{Core.Abstractions.MoveEntry}') | A read-only [MoveEntry](#T-Core-Abstractions-MoveEntry 'Core.Abstractions.MoveEntry') collection of 
previously proccessed moves. |

<a name='T-Core-Abstractions-Chess'></a>
## Chess `type`

##### Namespace

Core.Abstractions

##### Summary

Implements [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess'), and it's basic rules.

<a name='M-Core-Abstractions-Chess-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess') object, with no pieces.

##### Parameters

This constructor has no parameters.

<a name='M-Core-Abstractions-Chess-#ctor-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### #ctor(position) `constructor`

##### Summary

Creates a new [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess') object with a given 
`position`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given position. |

<a name='P-Core-Abstractions-Chess-Board'></a>
### Board `property`

##### Summary

Chessboard, invisible to users.

<a name='P-Core-Abstractions-Chess-Core#Abstractions#IChess#MoveEntries'></a>
### Core#Abstractions#IChess#MoveEntries `property`

##### Summary

Associates [MoveEntries](#P-Core-Abstractions-IChess-MoveEntries 'Core.Abstractions.IChess.MoveEntries') with [MoveEntries](#P-Core-Abstractions-Chess-MoveEntries 'Core.Abstractions.Chess.MoveEntries').

<a name='P-Core-Abstractions-Chess-Core#Abstractions#IChess#Position'></a>
### Core#Abstractions#IChess#Position `property`

##### Summary

Associates [Position](#P-Core-Abstractions-IChess-Position 'Core.Abstractions.IChess.Position') with [Position](#P-Core-Abstractions-Chess-Position 'Core.Abstractions.Chess.Position').

<a name='P-Core-Abstractions-Chess-MoveEntries'></a>
### MoveEntries `property`

##### Summary

A [MoveEntry](#T-Core-Abstractions-MoveEntry 'Core.Abstractions.MoveEntry') read-only collection of all past 
[Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') instances processed by the [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess')
game.

##### Returns



<a name='P-Core-Abstractions-Chess-Position'></a>
### Position `property`

##### Summary

The current position on the [Board](#P-Core-Abstractions-Chess-Board 'Core.Abstractions.Chess.Board').

<a name='P-Core-Abstractions-Chess-_moveEntries'></a>
### _moveEntries `property`

##### Summary

List of [MoveEntry](#T-Core-Abstractions-MoveEntry 'Core.Abstractions.MoveEntry') objects, invisible to users.

##### Returns



<a name='M-Core-Abstractions-Chess-AllMoves-System-Boolean-'></a>
### AllMoves(color) `method`

##### Summary

All moves, legal or illegal, currently available to a player, based on
the given `color` of their pieces.

##### Returns

A read-only collection of [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') instances.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | `true` for white, `false` for black. |

<a name='M-Core-Abstractions-Chess-AvailableMoves-System-Boolean-'></a>
### AvailableMoves(color) `method`

##### Summary

Currently available moves to a player, based on the given 
`color` of their pieces.

##### Returns

A read-only collection of [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') instances.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | `true` for white, `false` for black. |

<a name='M-Core-Abstractions-Chess-Clear-Core-Abstractions-Square-'></a>
### Clear(square) `method`

##### Summary

Clears the given `square` from its [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| square | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | A given [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | If the given `square`
is unoccupied, an exception is thrown. |

<a name='M-Core-Abstractions-Chess-Core#Abstractions#IChess#AvailableMoves-System-Boolean-'></a>
### Core#Abstractions#IChess#AvailableMoves(c) `method`

##### Summary

Associates [AvailableMoves](#M-Core-Abstractions-IChess-AvailableMoves-System-Boolean- 'Core.Abstractions.IChess.AvailableMoves(System.Boolean)') with [AvailableMoves](#M-Core-Abstractions-Chess-AvailableMoves-System-Boolean- 'Core.Abstractions.Chess.AvailableMoves(System.Boolean)').

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| c | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='M-Core-Abstractions-Chess-PlaceAt-Core-Abstractions-Square,Core-Abstractions-IPiece-'></a>
### PlaceAt(square,piece) `method`

##### Summary

Places a given `piece` at a given 
`square`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| square | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | A given [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square'). |
| piece | [Core.Abstractions.IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') | A given [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') instance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | If the given `square`
is taken, an exception is thrown. |

<a name='T-Core-Elements-Rules-Custom'></a>
## Custom `type`

##### Namespace

Core.Elements.Rules

##### Summary

Defines a fully customizable game of chess. Special moves can be enabled and / or disabled and 
pieces can be set to any given configuration. 

Configuration are passed through via constructor.

<a name='M-Core-Elements-Rules-Custom-#ctor-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### #ctor(position) `constructor`

##### Summary

Instantiate a new [Custom](#T-Core-Elements-Rules-Custom 'Core.Elements.Rules.Custom') game of chess with the give  on the board.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A read-only dictionary of pieces. |

<a name='M-Core-Elements-Rules-Custom-#ctor-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece},System-Collections-Generic-HashSet{Core-Abstractions-MoveType}-'></a>
### #ctor(position,bannedMoves) `constructor`

##### Summary

Instantiate a new [Custom](#T-Core-Elements-Rules-Custom 'Core.Elements.Rules.Custom') game of chess with the give  on the board,
as well as a given list of banned  entries.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A read-only dictionary of pieces. |
| bannedMoves | [System.Collections.Generic.HashSet{Core.Abstractions.MoveType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.HashSet 'System.Collections.Generic.HashSet{Core.Abstractions.MoveType}') | A list of banned [MoveType](#T-Core-Abstractions-MoveType 'Core.Abstractions.MoveType') entries. |

<a name='F-Core-Elements-Rules-Custom-BannedMoves'></a>
### BannedMoves `constants`

##### Summary

List of banned moves. Instanced on construction. [MoveType](#T-Core-Abstractions-MoveType 'Core.Abstractions.MoveType')'s on this list are not allowed.

<a name='M-Core-Elements-Rules-Custom-AllMoves-System-Boolean-'></a>
### AllMoves(color) `method`

##### Summary

All possible moves for player with pieces of the given `color`, whether or not their are
legal.

##### Returns

A read-only collection of [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') instances.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | `true` for white, `false for black` for black. |

<a name='M-Core-Elements-Rules-Custom-AvailableMoves-System-Boolean-'></a>
### AvailableMoves(color) `method`

##### Summary

Currently available moves for player with pieces of the given , based on the
list of banned moves.

##### Returns

A read-only collection of [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') instances.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | `true` for white, `false for black` for black. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NotImplementedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotImplementedException 'System.NotImplementedException') | This method is not yet implemented. |

<a name='T-Core-Abstractions-Files'></a>
## Files `type`

##### Namespace

Core.Abstractions

##### Summary

Defines all Files within a Chess board.

<a name='F-Core-Abstractions-Files-a'></a>
### a `constants`

##### Summary

A File.

<a name='F-Core-Abstractions-Files-b'></a>
### b `constants`

##### Summary

B File

<a name='F-Core-Abstractions-Files-c'></a>
### c `constants`

##### Summary

C File

<a name='F-Core-Abstractions-Files-d'></a>
### d `constants`

##### Summary

D File

<a name='F-Core-Abstractions-Files-e'></a>
### e `constants`

##### Summary

E File

<a name='F-Core-Abstractions-Files-f'></a>
### f `constants`

##### Summary

F File

<a name='F-Core-Abstractions-Files-g'></a>
### g `constants`

##### Summary

G File

<a name='F-Core-Abstractions-Files-h'></a>
### h `constants`

##### Summary

H File

<a name='T-Core-Abstractions-Game'></a>
## Game `type`

##### Namespace

Core.Abstractions

##### Summary

Abstract implementation of a game of [Chess](#P-Core-Abstractions-Game-Chess 'Core.Abstractions.Game.Chess').

<a name='P-Core-Abstractions-Game-Chess'></a>
### Chess `property`

##### Summary



<a name='P-Core-Abstractions-Game-CurrentMove'></a>
### CurrentMove `property`

##### Summary



<a name='P-Core-Abstractions-Game-CurrentPlayer'></a>
### CurrentPlayer `property`

##### Summary



<a name='M-Core-Abstractions-Game-ProcessMove-Core-Abstractions-Move-'></a>
### ProcessMove(move) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| move | [Core.Abstractions.Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') |  |

<a name='T-Core-Extensions-Helper'></a>
## Helper `type`

##### Namespace

Core.Extensions

##### Summary

Provide helper extensions for managing the core library.

<a name='M-Core-Extensions-Helper-AddNonNull``1-System-Collections-Generic-HashSet{``0},``0-'></a>
### AddNonNull\`\`1(list,value) `method`

##### Summary

Adds a non-null value at the end of the `list`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [System.Collections.Generic.HashSet{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.HashSet 'System.Collections.Generic.HashSet{``0}') |  |
| value | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Core-Extensions-Helper-HasMoved-Core-Abstractions-IPiece,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece},System-Collections-Generic-IReadOnlyCollection{Core-Abstractions-MoveEntry}-'></a>
### HasMoved(piece,position,moveEntries) `method`

##### Summary

Checks if `piece` has moved.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| piece | [Core.Abstractions.IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') |  |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |
| moveEntries | [System.Collections.Generic.IReadOnlyCollection{Core.Abstractions.MoveEntry}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyCollection 'System.Collections.Generic.IReadOnlyCollection{Core.Abstractions.MoveEntry}') | A read-only [MoveEntry](#T-Core-Abstractions-MoveEntry 'Core.Abstractions.MoveEntry') collection of 
previously proccessed moves. |

<a name='M-Core-Extensions-Helper-InBetweenSquares-Core-Abstractions-Square,Core-Abstractions-Square-'></a>
### InBetweenSquares(s1,s2) `method`

##### Summary

Returns all [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square')'s on the same rank between two files.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| s1 | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') |  |
| s2 | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throws an exception when s1 are s2
ar on the different [Ranks](#T-Core-Abstractions-Ranks 'Core.Abstractions.Ranks') or when they are the same 
[Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square'). |

<a name='M-Core-Extensions-Helper-Unify``1-System-Collections-Generic-IReadOnlyCollection{``0},System-Collections-Generic-IReadOnlyCollection{``0}-'></a>
### Unify\`\`1(firstCollection,secondCollection) `method`

##### Summary

Creates a new read-only collection containing all 
`T` items in `firstCollection` and 
in `secondCollection`, while excluding duplicates.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| firstCollection | [System.Collections.Generic.IReadOnlyCollection{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyCollection 'System.Collections.Generic.IReadOnlyCollection{``0}') |  |
| secondCollection | [System.Collections.Generic.IReadOnlyCollection{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyCollection 'System.Collections.Generic.IReadOnlyCollection{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-Core-Abstractions-IChess'></a>
## IChess `type`

##### Namespace

Core.Abstractions

##### Summary

[IChess](#T-Core-Abstractions-IChess 'Core.Abstractions.IChess') interface.

<a name='P-Core-Abstractions-IChess-MoveEntries'></a>
### MoveEntries `property`

##### Summary

A collection of all the move entries in a game o [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess').

<a name='P-Core-Abstractions-IChess-Position'></a>
### Position `property`

##### Summary

A position on the [Board](#T-Core-Elements-Board 'Core.Elements.Board').

<a name='M-Core-Abstractions-IChess-AvailableMoves-System-Boolean-'></a>
### AvailableMoves(color) `method`

##### Summary

Currently available moves to a player, based on the given 
`color` of their pieces.

##### Returns

A read-only collection of [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') objects.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True for white, false for black. |

<a name='T-Core-Abstractions-IGame'></a>
## IGame `type`

##### Namespace

Core.Abstractions

##### Summary

[IGame](#T-Core-Abstractions-IGame 'Core.Abstractions.IGame') interface.

<a name='P-Core-Abstractions-IGame-Chess'></a>
### Chess `property`

##### Summary

The rules of [IChess](#T-Core-Abstractions-IChess 'Core.Abstractions.IChess') that are currently being played.

<a name='P-Core-Abstractions-IGame-CurrentMove'></a>
### CurrentMove `property`

##### Summary

The current move being played on this [IGame](#T-Core-Abstractions-IGame 'Core.Abstractions.IGame') instance.

<a name='P-Core-Abstractions-IGame-CurrentPlayer'></a>
### CurrentPlayer `property`

##### Summary

The current player to make the next move.

<a name='M-Core-Abstractions-IGame-ProcessMove-Core-Abstractions-Move-'></a>
### ProcessMove(move) `method`

##### Summary

Process the given `move`, if it is possible.

##### Returns

True if the move was properly processed. Otherwise, 
False.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| move | [Core.Abstractions.Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') | A given [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move'). |

<a name='T-Core-Abstractions-IPiece'></a>
## IPiece `type`

##### Namespace

Core.Abstractions

##### Summary

[Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') interface.

<a name='P-Core-Abstractions-IPiece-Color'></a>
### Color `property`

##### Summary

Associated color of [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece').

<a name='M-Core-Abstractions-IPiece-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### AvailableMoves(position) `method`

##### Summary

Return all basic [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move')'s available for [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') at
a given `position`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | Dictionary containing [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece')'s at
various [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square')'s. |

<a name='T-Core-Elements-Pieces-King'></a>
## King `type`

##### Namespace

Core.Elements.Pieces

##### Summary

Implements the [King](#T-Core-Elements-Pieces-King 'Core.Elements.Pieces.King') piece.

<a name='M-Core-Elements-Pieces-King-#ctor-System-Boolean-'></a>
### #ctor(color) `constructor`

##### Summary

Creates a [King](#T-Core-Elements-Pieces-King 'Core.Elements.Pieces.King') piece of given `color`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True for white. Black otherwise. |

<a name='M-Core-Elements-Pieces-King-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### AvailableMoves(position) `method`

##### Summary

Returns all moves available for a [King](#T-Core-Elements-Pieces-King 'Core.Elements.Pieces.King') based on a board `position`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='T-Core-Elements-Pieces-Knight'></a>
## Knight `type`

##### Namespace

Core.Elements.Pieces

##### Summary

Implements the [Knight](#T-Core-Elements-Pieces-Knight 'Core.Elements.Pieces.Knight') piece.

<a name='M-Core-Elements-Pieces-Knight-#ctor-System-Boolean-'></a>
### #ctor(color) `constructor`

##### Summary

Creates a [Knight](#T-Core-Elements-Pieces-Knight 'Core.Elements.Pieces.Knight') piece of given `color`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True for white. Black otherwise. |

<a name='M-Core-Elements-Pieces-Knight-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### AvailableMoves(position) `method`

##### Summary

Returns all moves available for a [Knight](#T-Core-Elements-Pieces-Knight 'Core.Elements.Pieces.Knight') based on a board `position`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='T-Core-Extensions-Legality'></a>
## Legality `type`

##### Namespace

Core.Extensions

##### Summary

Provides extension methods for check and [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') legality checking in 
a [Game](#T-Core-Abstractions-Game 'Core.Abstractions.Game') of [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess').

<a name='M-Core-Extensions-Legality-IsChecked-Core-Abstractions-IChess,System-Boolean-'></a>
### IsChecked(chess,player) `method`

##### Summary

Checks if `player` is currently under check.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| chess | [Core.Abstractions.IChess](#T-Core-Abstractions-IChess 'Core.Abstractions.IChess') | A [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess') board. |
| player | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True for player with white pieces. Otherwise, blank. |

<a name='M-Core-Extensions-Legality-IsLegal-Core-Abstractions-IChess,Core-Abstractions-Move-'></a>
### IsLegal(chess,move) `method`

##### Summary

Checks if a `move` is legal (does not place own king under check).

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| chess | [Core.Abstractions.IChess](#T-Core-Abstractions-IChess 'Core.Abstractions.IChess') | A [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess') board. |
| move | [Core.Abstractions.Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') | A given [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move'). |

<a name='T-Core-Extensions-Maneuverability'></a>
## Maneuverability `type`

##### Namespace

Core.Extensions

##### Summary

Provides extension methods for maneuvers in a chess [Board](#T-Core-Elements-Board 'Core.Elements.Board').

<a name='M-Core-Extensions-Maneuverability-Maneuver-Core-Abstractions-Square,Core-Abstractions-Through,System-Int32-'></a>
### Maneuver(square,orientation,numberOfSquares) `method`

##### Summary

Returns the destination [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') by moving a certain `numberOfSquares`
through an `orientation` from origin `square`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| square | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | Origin square. |
| orientation | [Core.Abstractions.Through](#T-Core-Abstractions-Through 'Core.Abstractions.Through') | The move orientation. |
| numberOfSquares | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of squares. A negative number indicates a change in sense. |

<a name='M-Core-Extensions-Maneuverability-MovePlus-Core-Abstractions-Square,System-Int32,System-Int32-'></a>
### MovePlus(square,numberOfFiles,numberOfRanks) `method`

##### Summary

Returns the destination [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') by moving a certain `numberOfFiles`
and a certain `numberOfRanks` from origin `square`.

##### Returns

Destination square.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| square | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | Origin square. |
| numberOfFiles | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of [Files](#T-Core-Abstractions-Files 'Core.Abstractions.Files'). A negative number indicates a change
in sense. |
| numberOfRanks | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of [Ranks](#T-Core-Abstractions-Ranks 'Core.Abstractions.Ranks'). A negative number indicates a change
in sense. |

<a name='M-Core-Extensions-Maneuverability-NormalMove-Core-Abstractions-Chess,Core-Abstractions-Move-'></a>
### NormalMove(chess,move) `method`

##### Summary

Process a [Normal](#F-Core-Abstractions-MoveType-Normal 'Core.Abstractions.MoveType.Normal')`move`, according to the
given `chess` rules.

##### Returns

`true` if the move was processed correctly. Otherwise, 
returns `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| chess | [Core.Abstractions.Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess') | The [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess') game rules. |
| move | [Core.Abstractions.Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') | A given [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move'). |

<a name='M-Core-Extensions-Maneuverability-Process-Core-Abstractions-Chess,Core-Abstractions-Move-'></a>
### Process(chess,move) `method`

##### Summary

Process the given `move`, according to the rules of a given 
game of `chess`.

##### Returns

`true` if the move was processed correctly. Otherwise, 
returns `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| chess | [Core.Abstractions.Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess') | The [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess') game rules. |
| move | [Core.Abstractions.Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') | A given [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move'). |

<a name='T-Core-Abstractions-Move'></a>
## Move `type`

##### Namespace

Core.Abstractions

##### Summary

Defines a Move available for a given [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece').

<a name='M-Core-Abstractions-Move-#ctor-Core-Abstractions-Square,Core-Abstractions-Square,Core-Abstractions-MoveType-'></a>
### #ctor(origin,destination,type) `constructor`

##### Summary

A move must contain the `origin` of a [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece'), 
the destination `destination`, and the associated
[MoveType](#T-Core-Abstractions-MoveType 'Core.Abstractions.MoveType').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| origin | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') original [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square'). |
| destination | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | The new [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') |
| type | [Core.Abstractions.MoveType](#T-Core-Abstractions-MoveType 'Core.Abstractions.MoveType') | The [MoveType](#T-Core-Abstractions-MoveType 'Core.Abstractions.MoveType'), so that it can be properly
managed. |

<a name='P-Core-Abstractions-Move-FromSquare'></a>
### FromSquare `property`

##### Summary

Origin [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square').

<a name='P-Core-Abstractions-Move-ToSquare'></a>
### ToSquare `property`

##### Summary

Destination [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square').

<a name='P-Core-Abstractions-Move-Type'></a>
### Type `property`

##### Summary

Associated [MoveType](#T-Core-Abstractions-MoveType 'Core.Abstractions.MoveType').

<a name='T-Core-Abstractions-MoveEntry'></a>
## MoveEntry `type`

##### Namespace

Core.Abstractions

##### Summary

Records a [Move](#P-Core-Abstractions-MoveEntry-Move 'Core.Abstractions.MoveEntry.Move') entry applied to a [Board](#T-Core-Elements-Board 'Core.Elements.Board') state.

<a name='M-Core-Abstractions-MoveEntry-#ctor-Core-Abstractions-Move,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### #ctor(move,position) `constructor`

##### Summary

Creates a new `move` entry applied to 
a given `position`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| move | [Core.Abstractions.Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') | A [Move](#P-Core-Abstractions-MoveEntry-Move 'Core.Abstractions.MoveEntry.Move') applied to 
`position`. |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='M-Core-Abstractions-MoveEntry-#ctor-Core-Abstractions-Move,Core-Elements-Board-'></a>
### #ctor(move) `constructor`

##### Summary

Creates a new `move` entry applied to 
a given `board`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| move | [Core.Abstractions.Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') | A [Move](#P-Core-Abstractions-MoveEntry-Move 'Core.Abstractions.MoveEntry.Move') applied to 
A given [Board](#T-Core-Elements-Board 'Core.Elements.Board'). |

<a name='P-Core-Abstractions-MoveEntry-Move'></a>
### Move `property`

##### Summary

The recorded [Move](#P-Core-Abstractions-MoveEntry-Move 'Core.Abstractions.MoveEntry.Move') entry.

<a name='P-Core-Abstractions-MoveEntry-Position'></a>
### Position `property`

##### Summary

The recorded [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position').

<a name='P-Core-Abstractions-MoveEntry-board'></a>
### board `property`

##### Summary

The recorded [Board](#T-Core-Elements-Board 'Core.Elements.Board').

<a name='T-Core-Abstractions-MoveType'></a>
## MoveType `type`

##### Namespace

Core.Abstractions

##### Summary

Defines all types of moves in a Chess game.

<a name='F-Core-Abstractions-MoveType-Capture'></a>
### Capture `constants`

##### Summary

When a [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') moves to an [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') occupied another [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') of opposite 
[Color](#P-Core-Abstractions-Piece-Color 'Core.Abstractions.Piece.Color').

<a name='F-Core-Abstractions-MoveType-Castle'></a>
### Castle `constants`

##### Summary

A [King](#T-Core-Elements-Pieces-King 'Core.Elements.Pieces.King') move hides behind a 
[Rook](#T-Core-Elements-Pieces-Rook 'Core.Elements.Pieces.Rook') of same [Color](#P-Core-Abstractions-Piece-Color 'Core.Abstractions.Piece.Color').

<a name='F-Core-Abstractions-MoveType-Normal'></a>
### Normal `constants`

##### Summary

When a [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') moves to an unoccupied [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square').

<a name='F-Core-Abstractions-MoveType-Passant'></a>
### Passant `constants`

##### Summary

A [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn') move executed under special circumstances.

<a name='F-Core-Abstractions-MoveType-PromotToBishop'></a>
### PromotToBishop `constants`

##### Summary

A move where a [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn') promotes to a [Bishop](#T-Core-Elements-Pieces-Bishop 'Core.Elements.Pieces.Bishop').

<a name='F-Core-Abstractions-MoveType-PromoteToKnight'></a>
### PromoteToKnight `constants`

##### Summary

A move where a [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn') promotes to a [Knight](#T-Core-Elements-Pieces-Knight 'Core.Elements.Pieces.Knight').

<a name='F-Core-Abstractions-MoveType-PromoteToQueen'></a>
### PromoteToQueen `constants`

##### Summary

A move where a [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn') promotes to a [Queen](#T-Core-Elements-Pieces-Queen 'Core.Elements.Pieces.Queen').

<a name='F-Core-Abstractions-MoveType-PromoteToRook'></a>
### PromoteToRook `constants`

##### Summary

A move where a [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn') promotes to a [Rook](#T-Core-Elements-Pieces-Rook 'Core.Elements.Pieces.Rook').

<a name='F-Core-Abstractions-MoveType-Rush'></a>
### Rush `constants`

##### Summary

A [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn') rush move, available if the pawn has not yet
moved.

<a name='T-Core-Elements-Pieces-Pawn'></a>
## Pawn `type`

##### Namespace

Core.Elements.Pieces

##### Summary

Implements the [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn') piece.

<a name='M-Core-Elements-Pieces-Pawn-#ctor-System-Boolean-'></a>
### #ctor(color) `constructor`

##### Summary

Creates a [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn') piece of given `color`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True for white. Black otherwise. |

<a name='M-Core-Elements-Pieces-Pawn-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### AvailableMoves(position) `method`

##### Summary

Returns all moves available for a [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn') based on a board `position`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='M-Core-Elements-Pieces-Pawn-PawnAttack-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### PawnAttack(position) `method`

##### Summary

Given a `position`, attacks adjacent diagonals, 
according to [Color](#P-Core-Abstractions-IPiece-Color 'Core.Abstractions.IPiece.Color').

##### Returns

Returns only [Capture](#F-Core-Abstractions-MoveType-Capture 'Core.Abstractions.MoveType.Capture').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='M-Core-Elements-Pieces-Pawn-PawnMoveForward-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### PawnMoveForward(position) `method`

##### Summary

Given a `position`, checks for pawn single [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') 
move, according to [Color](#P-Core-Abstractions-IPiece-Color 'Core.Abstractions.IPiece.Color').

##### Returns

Returns only [Normal](#F-Core-Abstractions-MoveType-Normal 'Core.Abstractions.MoveType.Normal').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='M-Core-Elements-Pieces-Pawn-UpdateToPromotions-Core-Abstractions-Move-'></a>
### UpdateToPromotions(move) `method`

##### Summary

Updates a [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn')`move` to a list of all available promotions,
depending on their [ToSquare](#P-Core-Abstractions-Move-ToSquare 'Core.Abstractions.Move.ToSquare') and [Color](#P-Core-Abstractions-IPiece-Color 'Core.Abstractions.IPiece.Color').

##### Returns

Either a read-only collection containing `move` or a list of
updated moves.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| move | [Core.Abstractions.Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move') |  |

<a name='T-Core-Extensions-SpecializedMoves-PawnPassant'></a>
## PawnPassant `type`

##### Namespace

Core.Extensions.SpecializedMoves

##### Summary

Provides extension methods for special [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn')'s
En Passant logic.

<a name='M-Core-Extensions-SpecializedMoves-PawnPassant-EnPassant-Core-Abstractions-IPiece,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece},System-Collections-Generic-IReadOnlyCollection{Core-Abstractions-MoveEntry}-'></a>
### EnPassant(piece,position,moveEntries) `method`

##### Summary

[Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn')'s En Passant move.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| piece | [Core.Abstractions.IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') | Must inherit from [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn'). |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |
| moveEntries | [System.Collections.Generic.IReadOnlyCollection{Core.Abstractions.MoveEntry}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyCollection 'System.Collections.Generic.IReadOnlyCollection{Core.Abstractions.MoveEntry}') | A read-only [MoveEntry](#T-Core-Abstractions-MoveEntry 'Core.Abstractions.MoveEntry') collection of 
previously proccessed moves. |

<a name='T-Core-Extensions-SpecializedMoves-PawnRush'></a>
## PawnRush `type`

##### Namespace

Core.Extensions.SpecializedMoves

##### Summary

Provides extension methods for [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn') first move.

<a name='M-Core-Extensions-SpecializedMoves-PawnRush-PawnFirstMove-Core-Abstractions-IPiece,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### PawnFirstMove(piece,position) `method`

##### Summary

[Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn')'s first move is doubled.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| piece | [Core.Abstractions.IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') | Must inherit from [Pawn](#T-Core-Elements-Pieces-Pawn 'Core.Elements.Pieces.Pawn'). |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='T-Core-Abstractions-Piece'></a>
## Piece `type`

##### Namespace

Core.Abstractions

##### Summary

Proxies [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') and hides its members.

<a name='M-Core-Abstractions-Piece-#ctor-System-Boolean-'></a>
### #ctor(color) `constructor`

##### Summary

Creates a new [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') object, of a given `color`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | White if `true`. Black otherwise. |

<a name='P-Core-Abstractions-Piece-Color'></a>
### Color `property`

##### Summary

Associated color of [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece').

<a name='P-Core-Abstractions-Piece-Core#Abstractions#IPiece#Color'></a>
### Core#Abstractions#IPiece#Color `property`

##### Summary

Associate [Color](#P-Core-Abstractions-IPiece-Color 'Core.Abstractions.IPiece.Color') to [Color](#P-Core-Abstractions-Piece-Color 'Core.Abstractions.Piece.Color').

<a name='M-Core-Abstractions-Piece-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### AvailableMoves(position) `method`

##### Summary

Return all basic [Move](#T-Core-Abstractions-Move 'Core.Abstractions.Move')'s available for [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') at
a given `position`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | Dictionary containing [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece')'s at
various [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square')'s |

<a name='M-Core-Abstractions-Piece-Core#Abstractions#IPiece#AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### Core#Abstractions#IPiece#AvailableMoves() `method`

##### Summary

Associate [AvailableMoves](#M-Core-Abstractions-IPiece-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Abstractions.IPiece.AvailableMoves(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})') to [AvailableMoves](#M-Core-Abstractions-Piece-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}- 'Core.Abstractions.Piece.AvailableMoves(System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece})').

##### Parameters

This method has no parameters.

<a name='M-Core-Abstractions-Piece-GetSquareFrom-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### GetSquareFrom(position) `method`

##### Summary

Gets the [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') where [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') is
placed, based on a given `position`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A read-only [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') dictionary. |

<a name='T-Core-Elements-Pieces-Queen'></a>
## Queen `type`

##### Namespace

Core.Elements.Pieces

##### Summary

Implements the [Queen](#T-Core-Elements-Pieces-Queen 'Core.Elements.Pieces.Queen') piece.

<a name='M-Core-Elements-Pieces-Queen-#ctor-System-Boolean-'></a>
### #ctor(color) `constructor`

##### Summary

Creates a [Queen](#T-Core-Elements-Pieces-Queen 'Core.Elements.Pieces.Queen') piece of given `color`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True for white. Black otherwise. |

<a name='M-Core-Elements-Pieces-Queen-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### AvailableMoves(position) `method`

##### Summary

Returns all moves available for a [Queen](#T-Core-Elements-Pieces-Queen 'Core.Elements.Pieces.Queen') based on a board `position`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='T-Core-Abstractions-Ranks'></a>
## Ranks `type`

##### Namespace

Core.Abstractions

##### Summary

Defines all Ranks within a Chess board.

<a name='F-Core-Abstractions-Ranks-eight'></a>
### eight `constants`

##### Summary

Eighth Rank

<a name='F-Core-Abstractions-Ranks-five'></a>
### five `constants`

##### Summary

Fifth Rank

<a name='F-Core-Abstractions-Ranks-four'></a>
### four `constants`

##### Summary

Forth Rank

<a name='F-Core-Abstractions-Ranks-one'></a>
### one `constants`

##### Summary

First Rank

<a name='F-Core-Abstractions-Ranks-seven'></a>
### seven `constants`

##### Summary

Seventh Rank

<a name='F-Core-Abstractions-Ranks-six'></a>
### six `constants`

##### Summary

Sixth Rank

<a name='F-Core-Abstractions-Ranks-three'></a>
### three `constants`

##### Summary

Third Rank

<a name='F-Core-Abstractions-Ranks-two'></a>
### two `constants`

##### Summary

Second Rank

<a name='T-Core-Elements-Pieces-Rook'></a>
## Rook `type`

##### Namespace

Core.Elements.Pieces

##### Summary

Implements the [Rook](#T-Core-Elements-Pieces-Rook 'Core.Elements.Pieces.Rook') piece.

<a name='M-Core-Elements-Pieces-Rook-#ctor-System-Boolean-'></a>
### #ctor(color) `constructor`

##### Summary

Creates a [Rook](#T-Core-Elements-Pieces-Rook 'Core.Elements.Pieces.Rook') piece of given `color`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True for white. Black otherwise. |

<a name='M-Core-Elements-Pieces-Rook-AvailableMoves-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### AvailableMoves(position) `method`

##### Summary

Returns all moves available for a [Rook](#T-Core-Elements-Pieces-Rook 'Core.Elements.Pieces.Rook') based on a board `position`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | A given [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |

<a name='T-Core-Abstractions-Royalty'></a>
## Royalty `type`

##### Namespace

Core.Abstractions

##### Summary

Implements a [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') belonging to royalty.

<a name='M-Core-Abstractions-Royalty-#ctor-System-Boolean-'></a>
### #ctor(color) `constructor`

##### Summary

Creates a new [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece') belonging to royalty.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True for white. Black otherwise. |

<a name='M-Core-Abstractions-Royalty-RoyalAttack-System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece},System-UInt32-'></a>
### RoyalAttack(position,numberOfSquares) `method`

##### Summary

Attacks a certain `numberOfSquares`[Through](#T-Core-Abstractions-Through 'Core.Abstractions.Through') 
all directions, based on a given `position`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') | An [Position](#P-Core-Elements-Board-Position 'Core.Elements.Board.Position'). |
| numberOfSquares | [System.UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') | A number of squares. |

<a name='T-Core-Extensions-Setup'></a>
## Setup `type`

##### Namespace

Core.Extensions

##### Summary

Provide extension methods for setting up new pieces on the [Board](#T-Core-Elements-Board 'Core.Elements.Board').

<a name='M-Core-Extensions-Setup-AddPiece-Core-Abstractions-Chess,Core-Abstractions-Square,Core-Abstractions-IPiece-'></a>
### AddPiece(chess,square,piece) `method`

##### Summary

Places an existing `piece` at a given `square`,
according to the given `chess` rules.

##### Returns

`true` if the piece was properly placed. 
Otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| chess | [Core.Abstractions.Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess') | The [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess') game rules. |
| square | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | A given [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square'). |
| piece | [Core.Abstractions.IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') | A given [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') instance. |

<a name='M-Core-Extensions-Setup-AddPiece``1-Core-Elements-Board,Core-Abstractions-Square,System-Boolean-'></a>
### AddPiece\`\`1(board,square,color) `method`

##### Summary

Add a new `TPiece` of a given `color` to a 
given `square`.

##### Returns

`true` if a new `TPiece` was 
properly created.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| board | [Core.Elements.Board](#T-Core-Elements-Board 'Core.Elements.Board') | A [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess')[Board](#T-Core-Elements-Board 'Core.Elements.Board'). |
| square | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | A given [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square'). |
| color | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | `true` if `TPiece` is white. 
`false` otherwise. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TPiece | `TPiece` must inherited 
from [Piece](#T-Core-Abstractions-Piece 'Core.Abstractions.Piece'). |

<a name='M-Core-Extensions-Setup-Copy-Core-Elements-Board,System-Collections-Generic-IReadOnlyDictionary{Core-Abstractions-Square,Core-Abstractions-IPiece}-'></a>
### Copy(board,position) `method`

##### Summary

Copies the give `position` to `board`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| board | [Core.Elements.Board](#T-Core-Elements-Board 'Core.Elements.Board') |  |
| position | [System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyDictionary 'System.Collections.Generic.IReadOnlyDictionary{Core.Abstractions.Square,Core.Abstractions.IPiece}') |  |

<a name='M-Core-Extensions-Setup-RemovePiece-Core-Abstractions-Chess,Core-Abstractions-Square,Core-Abstractions-IPiece@-'></a>
### RemovePiece(chess,square,piece) `method`

##### Summary

Removes `piece` from the given `square`,
according to the given `chess` rules.

##### Returns

`true` if the piece was properly removed. 
Otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| chess | [Core.Abstractions.Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess') | The [Chess](#T-Core-Abstractions-Chess 'Core.Abstractions.Chess') game rules. |
| square | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | A given [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square'). |
| piece | [Core.Abstractions.IPiece@](#T-Core-Abstractions-IPiece@ 'Core.Abstractions.IPiece@') | A given [IPiece](#T-Core-Abstractions-IPiece 'Core.Abstractions.IPiece') instance. |

<a name='T-Core-Abstractions-Square'></a>
## Square `type`

##### Namespace

Core.Abstractions

##### Summary

Defines a [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square'), and its basic properties.

<a name='M-Core-Abstractions-Square-#ctor-Core-Abstractions-Files,Core-Abstractions-Ranks-'></a>
### #ctor(f,r) `constructor`

##### Summary

Builds a new [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') with given [Files](#T-Core-Abstractions-Files 'Core.Abstractions.Files') File and [Ranks](#T-Core-Abstractions-Ranks 'Core.Abstractions.Ranks') Rank.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| f | [Core.Abstractions.Files](#T-Core-Abstractions-Files 'Core.Abstractions.Files') | Set the [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square')'s File. |
| r | [Core.Abstractions.Ranks](#T-Core-Abstractions-Ranks 'Core.Abstractions.Ranks') | Set the [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square')'s Rank. |

<a name='M-Core-Abstractions-Square-#ctor-Core-Abstractions-Square-'></a>
### #ctor(square) `constructor`

##### Summary

Builds a new [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') from a given `square`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| square | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') | New [File](#P-Core-Abstractions-Square-File 'Core.Abstractions.Square.File') and [File](#P-Core-Abstractions-Square-File 'Core.Abstractions.Square.File') will be 
the same as `square.File.File` and 
`square.Rank.Rank`. |

<a name='P-Core-Abstractions-Square-Color'></a>
### Color `property`

##### Summary

Returns value indicating the [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square')' color.

##### Returns

`true` if the [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') is white. `false` otherwise.

<a name='P-Core-Abstractions-Square-File'></a>
### File `property`

##### Summary

Returns a value indicating the [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square')'s [Files](#T-Core-Abstractions-Files 'Core.Abstractions.Files').

<a name='P-Core-Abstractions-Square-Rank'></a>
### Rank `property`

##### Summary

Returns a value indicating the [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square')'s [Ranks](#T-Core-Abstractions-Ranks 'Core.Abstractions.Ranks').

<a name='M-Core-Abstractions-Square-GetColor'></a>
### GetColor() `method`

##### Summary

[Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') color is a function of its [File](#P-Core-Abstractions-Square-File 'Core.Abstractions.Square.File') and [Rank](#P-Core-Abstractions-Square-Rank 'Core.Abstractions.Square.Rank').

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Core-Abstractions-Square-IsSameFileAs-Core-Abstractions-Square-'></a>
### IsSameFileAs(p) `method`

##### Summary

Indicates if two [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square')'s have the same File.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| p | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') |  |

<a name='M-Core-Abstractions-Square-IsSameRankAs-Core-Abstractions-Square-'></a>
### IsSameRankAs(p) `method`

##### Summary

Indicates if two [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square')'s have the same Rank.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| p | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') |  |

<a name='M-Core-Abstractions-Square-IsSameSquareAs-Core-Abstractions-Square-'></a>
### IsSameSquareAs(p) `method`

##### Summary

Indicates if two [Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square')'s have the same File and Rank.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| p | [Core.Abstractions.Square](#T-Core-Abstractions-Square 'Core.Abstractions.Square') |  |

<a name='T-Core-Abstractions-Through'></a>
## Through `type`

##### Namespace

Core.Abstractions

##### Summary

Defines all possible orientations of movements through the board.

<a name='F-Core-Abstractions-Through-Files'></a>
### Files `constants`

##### Summary

Along the [Files](#F-Core-Abstractions-Through-Files 'Core.Abstractions.Through.Files').

<a name='F-Core-Abstractions-Through-MainDiagonal'></a>
### MainDiagonal `constants`

##### Summary

Advancing through [Files](#F-Core-Abstractions-Through-Files 'Core.Abstractions.Through.Files') and [Ranks](#F-Core-Abstractions-Through-Ranks 'Core.Abstractions.Through.Ranks') simultaneously.

<a name='F-Core-Abstractions-Through-OppositeDiagonal'></a>
### OppositeDiagonal `constants`

##### Summary

Retreating through [Files](#F-Core-Abstractions-Through-Files 'Core.Abstractions.Through.Files') and advancing through [Ranks](#F-Core-Abstractions-Through-Ranks 'Core.Abstractions.Through.Ranks') simultaneously.

<a name='F-Core-Abstractions-Through-Ranks'></a>
### Ranks `constants`

##### Summary

Along the [Ranks](#F-Core-Abstractions-Through-Ranks 'Core.Abstractions.Through.Ranks').
