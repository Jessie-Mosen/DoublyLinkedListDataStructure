# DoublyLinkedListDataStructure
This project implements a doubly linked list (DLL) in C# with various functionalities such as adding, deleting, searching nodes, and more. It also includes a command-line interface to interact with the list using different file sizes of words.

Features
Doubly Linked List Class (DLList)
The DLList class represents a doubly linked list with the following key functionalities:

Insert at Front: Add a new node at the beginning of the list.
Insert at Rear: Add a new node at the end of the list.
Delete at Front: Remove the node from the beginning of the list.
Delete at End: Remove the node from the end of the list.
Delete Node: Remove a specific node from the list.
Search: Find a node in the list and return its position.
Print: Print all nodes in the list.
Node Class (Node)
The Node class represents a node in the doubly linked list with the following properties:

Word: The data stored in the node.
Next: Pointer to the next node in the list.
Prev: Pointer to the previous node in the list.
Main Program (Program)
The main program provides a command-line interface for the user to interact with the doubly linked list. It allows the user to:

Choose a file size for loading words into the list.
Perform file manipulation operations such as:
Deleting a node.
Finding a node.
Printing the list.
Inserting a new word at the front of the list.
Performance Measurement
The program uses a Stopwatch to measure and display the time taken for different operations (insert, delete, find, print).

How to Use
Choose File Size: When prompted, choose a file size (1-11) to load words from the corresponding file into the doubly linked list.
Perform Operations: After the file is loaded, select the desired file manipulation operation:
  Delete a node
  Find a node
  Print the list
  Insert a word at the front
Measure Time: The program will display the time taken for the selected operation.
Example Usage
arduino
Copy code
Choose File size
Press 1 for 1000
Press 2 for 5000
...
Press 11 for 50000



File Structure
DLList.cs: Contains the DLList class implementation.
Node.cs: Contains the Node class implementation.

Program.cs: Contains the main program logic for user interaction and performance measurement.
Requirements
.NET Core or .NET Framework
Visual Studio or any C# IDE
How to Run
Clone the repository.
Open the project in your preferred C# IDE.
Build and run the project.
Follow the prompts in the console to interact with the doubly linked list.
