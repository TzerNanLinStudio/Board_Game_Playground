# Board Game Playground

# 1. Introduction

**The project has reached the completion of its staged development but this markdown file is still being edited and not all content has been completed yet.**

This project was developed in my spare time, inspired by my and a few friends' love for board games. However, due to the restrictions of the pandemic, we were unable to meet in person. Consequently, I created this simple online board game software, allowing us to continue enjoying our gaming sessions through the internet. I use C# and WPF as my development tools. Initially, to quickly share this joy with my friends, I only designed some basic features, and the language is Chinese. In the future, if the opportunity and time arise, I hope to further improve and optimize this software, such as more functionalities and different languages support.

I will briefly introduce the functionality and usage of this software in the following section. Everyone is welcome to download and test it from GitHub. If there are any questions, feel free to email me.

# 2. Software Application Description

## 2.1. Game Menu

![Image Error](./Other/Image/image_01.png)

This is a simple game lobby. Currently, there are two games available to choose from. One is Blokus and the other is Chinese Checkers.

## 2.2. The First Game - Blokus

![Image Error](./Other/Image/image_02.png)

The above image shows the opening stage of the game. The game starts with the blue player, followed by the green player, the red player, and then the yellow player.

![Image Error](./Other/Image/image_03.png)

The above image shows the early-middle stage of the game.

![Image Error](./Other/Image/image_04.png)

The above image shows the late-middle stage of the game.

![Image Error](./Other/Image/image_05.png)

The above image shows the endgame stage. The game's outcome message is displayed in the message bar.

**Game Instructions**
 - **Board and Pieces**
    - Blokus uses a 20x20 grid game board. Each player has 21 pieces of various shapes, with each piece made up of 1 to 5 squares.
 - **Objective** 
   - The objective of the game is to place as many of your pieces on the board as possible while blocking your opponents from doing the same.
 - **Placement Rules**
    - Each player starts by placing their first piece in a corner of the board.
    - Each subsequent piece must touch at least one corner of the same player's previously placed pieces but cannot share an edge with them.
    - Pieces can be rotated and flipped to fit the available spaces on the board.
 - **Victory Conditions**
    - Calculate the number of squares occupied by each player’s pieces. Each square counts as 1 point. The player with the highest score wins the game.

## 2.3. The Second Game - Chinese Checkers

![Image Error](./Other/Image/image_06.png)

Currently, parts of the frontend and backend for this game have been implemented as shown in the above image. Further development and testing will be completed soon.

# 3. References

 - Integrated Development Environment: Visual Studio 2019
 - Frontend Development: WPF (Windows Presentation Foundation)
 - Backend Development: C#

# 4. Future Work

 - Add the Config class to record the parameters required for software operation to ensure that the software's state when opened is consistent with its state when it was last closed.
 - Add the LogRecorder to record the software's running status.
 - Complete the development of Chinese Checkers.
 - Design more various board games.
 - Enable multiplayer connectivity for games, such as via TCP or UDP.
 - Establish test and GitHub Actions workflows related to CI/CD.
