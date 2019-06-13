# MineSweeper

## Solution
Is a .NET Core 2.1 Console app written in vs2019 Community.
Solution is called MineSweeper.sln.
Publish setting are self-contained deployment mode.

## Principles used
* Interface Segregation - Each interface should only have what is needed.
* Single class responsibility - Game, Board, BoardRules, Player, Position, GameMineSweeperRules.
* Dependency injection.
* Refactoring with unit tests and Resharper.
* Seperate libraries for Logic and tests away from Console Application

## Guide to classes
A game consists of a board and a player. The game listens to events from the player.
The GenerateGame static class is creating the dependencies, could use a IOC container but felt overkill for this.

A board has a size, some mines and a Horizontal axis reference. Is also responsible for removing it's own mines.

BoardRules have a board that they are applied.
The BoardMineSweeperRules are, 
ValidPosition on the board
is that position a mine and remove from board if it is.
BoardRules return BoardResults. 

A player has a game, boardrules that apply to a board and a way to move and GameRules on how to react.
A player is also responsible for implementing board rules and game rules that are started with its movement.
The player will also know the number of lives and number of moves.

A move is responsible for processing a key stroke and working out how far to move.
Could potentially be extended with other moves.

GameRules changes the state of the player and decides on the game outcome.
Could potentially be extended with other rules.
Current GameMineSweeperRules
If I perform a valid Move by number of moves increases otherwise I stay where I am.
If I hit a mine I lose a life.
If I run out of lives it's game over.
If the board tells me I have reached the end I have won.

## Assumptions
* Other side of board means the edge, so you reach the final square on the right but have to move again to leave.
* A Chessboard is 8x8.
* The Horizontal Axis has to be returned in Alpha's. E.g C2.
* Mines are removed once they are hit.
* Only using debug solution config with no deployment.

## Niggles,
* BoardResults.ValidHorizontal and BoardResults.ValidVertical could be viewed as superfluous but are usefull to work out the board edges.
* BoardResults itself could of been put onto player as properties but there already feels too much on player.
* HorizontalArray of Letter to number, feels like there should be a better way of doing this, currently limited to 8 characters.
* No Test coverage in Console Application but trying to keep this simple could also pass a stream into Game from Console.
* Rules classes(BoardMineSweeperRules and GameMineSweep
