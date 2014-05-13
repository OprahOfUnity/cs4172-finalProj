cs4172-finalProj
================

COMS W4172: 3D User Interfaces and Augmented Reality

Steven Feiner 

Team 1: Oprah of Unity
======================

Dan Garzon ([@dgarzon](https://github.com/dgarzon))

Hila Gutfreund ([@hilagutfreund](https://github.com/hilagutfreund))

Josh Lieberman ([@JALsnipe](https://github.com/JALsnipe))

Will McAulliff ([@will-mcauliff-IV](https://github.com/will-mcauliff-IV))

Final Project: Breach

Date of Submission: 5/11/2014

Development Environment
========================

Unity 4.3.4f1

Vuforia v2.8.9

Mac OS X Mavericks Version 10.9.2

LG Nexus 5 running Android version 4.4.2

iPhone 5s running iOS 7.1.1

Unity Scene Info
=================
Project Title: cs4172-finalProj

Scene 0 Title: MainMenu.unity

Scene 1 Title: MainScene.unity

Directory Overview
===================

OprahOfUnity-csw4172-finalProj-written.pdf - written description

Targets/ - folder containing printable image targets

Assets/ - contains all project assets

Assets/_Scenes/ - contains all scenes used in the project

Assets/Cannon/ - contains all necessary files to use the cannon object

Assets/Cartoon Soldier/ - contains all necessary files to use the soldier object

Assets/Models/ - contains all models used

Assets/Materials/ - contains all materials used

Assets/Scripts/ - contains all necessary C# script files

Assets/Qualcomm Augmented Reality/ - AR SDK

Assets/Textures/ - contains all textures used

Special Instructions
=====================

Make sure that our MainMenu.unity scene is set to scene 0, and our MainScene.unity is set to scene 1.  App should run in landscape mode.

Preparing Targets
==================

Print chips target fit-to-page.  Print gravel toolbar target at its current size (not stretched to fit the page).  Print cylinder soda target fit-to-page and mount to cylinder-shaped object.

Video Demo
===========
https://www.youtube.com/watch?v=fpQO8rwmXYs

App Instructions
=================
Start the app and press “Start” on the main menu to begin the game.

Missing features
=================
Archer may hit solder too soon after being reparented to image target. This may cause an issue where the soldier game object may not be destroyed.  Because we’re using extended tracking, sometimes when we lose track of the cylindrical target the game plane renders in the wrong place, causing issues.

Bugs in Code
=============
Nothing that would halt compilation.

Asset Sources
==============
Cannon:

https://www.assetstore.unity3d.com/#/content/1803

Soldiers:

https://www.assetstore.unity3d.com/#/content/1727

Textures:

Stone:

http://seamless-pixels.blogspot.com/p/stone.html

Grass:

http://www.pageresource.com/wallpapers/4262/dark-green-grass-texture-and-high-resolution-hd-wallpaper.html

Targets: Vuforia Developer Portal

Written Description Sources
=============================

We used these written sources to help us look up 3D object manipulation techniques and terminology:

Class slides

D. Bowman, E. Kruijff, J. LaViola Jr., and I. Poupyrev. 3D User Interfaces: Theory and Practice. Addison-Wesley, Boston, 2005, ISBN 0-201-75867-9.

Green, Mark; Jacob, Robert (July 1991). "SIGGRAPH '90 Workshop Report: Software Architectures and Metaphors for Non-WIMP User Interfaces". SIGGRAPH '90. SIGGRAPH. Dallas: ACM

