# ARC-System

As more is thought up or figured out to need to be added, this README will be extended and grow to reflect the current mentality, thought process, progress

This holds the work, thoughts, and plans for the ARC System (Augmented Reality Card System). The goal is to be able to first create a fully working Duel Disk relative to how they work in Yu-Gi-Oh!. Afterwards, be able to adjust the program/system to work with other TCGs such as: Magic the Gathering and Pokemon

The program itself is being developed in C# with Visual C as a way to build the field quickly.
The cards and their information is being used/held using Microsoft SQL Server as that is the system I am most familiar with and can manipulate easily.

Currently, I am working on creating a proper workflow/needs of any and all functions needed to be created in order to handle/resolve the monumental task of the logic needed. The current progress can be viewed in the workflow item.
A secondary file is available to show what has been worked on, what has been finished, and what is coming.
A tertiary file is being worked on with a materials list on what hardware will be used, and how they will be connected.

The reason for this project is that everything needed to create the final product has been developed and created. The biggest hurdle is combining everything and making them communicate together effectively.

I have been able to create multiple failed attempts, and now I am starting from square one with a better understanding of what needs to be done and how to better tackle everything. Below are the programs/attempts I have done:
-Using Visual Studio's Image Recognition internal abilities, I was able to create a program that can recognize one card at a time. With this, it could recognize a few cards relatively consistently, some were hit or miss, and others were never correct. The recognized cards were able to have all their information pulled from the SQL Server and applied to the Card variable where they can be manipulated/seen.
-Redoing the recognition on my end, the recognition could be better but then I was able to work on activating effects and voice commands, but to no avail
